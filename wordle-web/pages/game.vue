<template>
  <v-container>
    <v-progress-linear
      v-if="game.loading"
      color="deep-purple accent-4"
      indeterminate
    />
    <v-card v-else class="text-center" elevation="2">
      <v-sheet color="amber darken-3" class="pa-3">
        <h1 class="display-1 white--text">LexiQuest!</h1>
        <v-btn @click="toggleNameDialog" color="green accent-4" text>
          {{ username }}
        </v-btn>
      </v-sheet>
      <v-alert
        v-if="game.gameState !== GameState.Playing"
        :color="game.gameState === GameState.Won ? 'green' : 'red'"
        dense>
        <h3>
          {{ game.gameState === GameState.Won ? "Victory! 🧙‍♂️" : "Defeat... 💀" }}
        </h3>
        <v-card-text>
          The secret rune was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn outlined color="amber" @click="restartGame">
          <v-icon left>mdi-restart</v-icon>
          Start a New Quest
        </v-btn>
      </v-alert>

      <GameBoardGuess
        v-for="(guess, i) in game.guesses"
        :key="i"
        :guess="guess" />

      <v-btn @click="submitGuess" color="purple darken-2" dark class="mb-3">
        Cast Spell!
      </v-btn>
      <v-btn @click="toggleLeaderboard" color="primary" dark class="mb-3">
        View Leaderboard
      </v-btn>
    </v-card>
    <NameDialog v-model:show="showNameDialog" v-model:name="username" />
  </v-container>
</template>

<script setup>
import { ref, reactive, onMounted, onUnmounted, watch } from 'vue';
import { Game, GameState } from '../scripts/game';
import NameDialog from '../components/NameDialog';
import nuxtStorage from 'nuxt-storage';
import Axios from 'axios';
import { useRouter } from 'vue-router';

const game = reactive(new Game());
const router = useRouter();
const showNameDialog = ref(false);
const username = ref(nuxtStorage.localStorage.getData('name') || 'Guest');

provide("GAME", game);

function submitGuess() {
  game.submitGuess();
  if (game.gameState === GameState.Won || game.gameState === GameState.Lost) {
    postScore();
  }
}

function toggleLeaderboard() {
  router.push('/leaderboard');
}

function restartGame() {
  game.startNewGame();
}

function toggleNameDialog() {
  showNameDialog.value = !showNameDialog.value;
}

function enterName() {
  username.value = username.value.trim() || 'Guest';
  nuxtStorage.localStorage.setData('name', username.value);
  showNameDialog.value = false;
}

function postScore() {
  const attempts = game.guessIndex + 1; 
  Axios.post('/leaderboard/postscore', {
    Name: username.value,
    GameCount: 1,
    AverageAttempts: attempts,
  });
}

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event) {
  if (event.key === "Enter") {
    submitGuess();
  } else if (event.key === "Backspace") {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    game.addLetter(event.key.toUpperCase());
  }
}
</script>

<style scoped>
.v-sheet {
  background-image: url('/images/lexiquest_background.jpg');
  background-size: cover;
}
</style>
