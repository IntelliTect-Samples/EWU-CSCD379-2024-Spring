<template>
  <v-container>
    <v-progress-linear
      v-if="game.gameState === GameState.Initializing"
      color="amber darken-2"
      indeterminate />
    <v-card v-else class="text-center" elevation="2">
      <v-sheet>
        <v-container height="150px">
          <v-sheet
            @click="toggleNameDialog"
            class="pa-2 mx-2 mt-2 cursor-pointer"
            color="deep-purple accent-4">
            {{ username || 'Set your name' }}
          </v-sheet>
        </v-container>
      </v-sheet>
      <v-alert
        v-if="game.gameState !== GameState.Playing"
        :color="game.gameState === GameState.Won ? 'green' : 'red'"
        class="mb-5"
        tile>
        <h3>
          You've
          {{ game.gameState === GameState.Won ? 'triumphed! 🏰' : 'been defeated... 🌑' }}
        </h3>
        <v-card-text>
          The secret word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn text @click="game.startNewGame()">
          <v-icon left>mdi-restart</v-icon>
          Restart Quest
        </v-btn>
      </v-alert>

      <div class="mt-5">
        <GameBoardGuess
          v-for="(guess, i) in game.guesses"
          :key="i"
          :guess="guess" />
      </div>

      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn
        @click="game.submitGuess"
        class="mb-5"
        color="primary">
        Cast Spell!
      </v-btn>
      <v-btn
        @click="$router.push('/leaderboard')"
        class="mb-5 mx-5"
        color="primary">
        View Hall of Heroes
      </v-btn>
      <NameDialog
        v-model:show="showNameDialog"
        v-model:name="username"
        @entered="enterName" />
      <GuestSaveDialog
        v-model:show="showGuestSaveDialog"
        @saveGuestScore="postScore" />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from '~/scripts/game';
import nuxtStorage from 'nuxt-storage';
import Axios from 'axios';

const game = reactive(new Game());
game.startNewGame();
provide('GAME', game);
const username = ref(nuxtStorage.localStorage.getData('name') || '');
const showNameDialog = ref(!username.value);
const showGuestSaveDialog = ref(false);

function toggleNameDialog() {
  showNameDialog.value = !showNameDialog.value;
}

onMounted(() => {
  window.addEventListener('keyup', onKeyup);
});

onUnmounted(() => {
  window.removeEventListener('keyup', onKeyup);
});

watch(() => game.gameState, (newState) => {
  if (newState === GameState.Won || newState === GameState.Lost) {
    showGuestSaveDialog.value = username.value === 'Guest';
    if (!showGuestSaveDialog.value) {
      postScore();
    }
  }
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === 'Enter' && showNameDialog.value) {
    enterName();
  }
}

function enterName() {
  if (username.value.trim() === '') {
    username.value = 'Guest';
  }
  nuxtStorage.localStorage.setData('name', username.value);
  showNameEDialog.value = false;
}

function postScore() {
  const attempts = game.gameState === GameState.Won ? game.guessIndex + 1 : game.maxAttempts;
  Axios.post('/leaderboard/postscore', {
    Name: username.value,
    GameCount: 1,
    AverageAttempts: attempts,
  });
}
</script>
