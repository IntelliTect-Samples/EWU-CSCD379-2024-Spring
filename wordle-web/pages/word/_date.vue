<template>
  <v-container>
    <v-progress-linear
      v-if="game.gameState === GameState.Initializing"
      color="amber darken-2"
      indeterminate
    />
    <v-card v-else class="text-center" elevation="2">
      <v-sheet>
        <v-container height="150px">
          <v-sheet
            @click="showNameDialog = !showNameDialog"
            class="pa-2 mx-2 mt-2 cursor-pointer"
            color="secondary"
          >
            {{ username }}
          </v-sheet>
        </v-container>
      </v-sheet>
      <v-alert
        v-if="game.gameState != GameState.Playing"
        :color="game.gameState == GameState.Won ? 'green' : 'red'"
        class="mb-5"
        tile
      >
        <h3>
          You've
          {{ game.gameState == GameState.Won ? 'triumphed! 🏰' : 'been defeated... 🌑' }}
        </h3>
        <v-card-text>
          The secret word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn variant="outlined" @click="startNewGame">
          <v-icon size="large" class="mr-2">mdi-restart</v-icon>
          Restart Quest
        </v-btn>
      </v-alert>

      <div class="mt-5">
        <GameBoardGuess
          v-for="(guess, i) of game.guesses"
          :key="i"
          :guess="guess"
        />
      </div>

      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn @click="game.submitGuess(); playAudio();" class="mb-5" color="amber darken-2">
        Cast Spell!
      </v-btn>
      <v-btn
        @click="$router.push('/leaderboard'); playAudio();"
        class="mb-5 mx-5"
        color="secondary"
      >
        View Hall of Heroes
      </v-btn>
      <NameDialog v-model:show="showNameDialog" v-model:name="username" @entered="enterName" />
      <GuestSaveDialog v-model="showGuestSaveDialog" @saveGuestScore="postScore" />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from '~/scripts/game';
import { ref, reactive, onMounted, onUnmounted, watch, provide } from 'vue';
import { useRoute } from 'vue-router';
import nuxtStorage from 'nuxt-storage';
import Axios from 'axios';

const game = reactive(new Game());
provide('GAME', game);
const username = ref('');
const showNameDialog = ref(false);
const showGuestSaveDialog = ref(false);

const route = useRoute();
const date = route.params.date; // Extract the date from the route parameters

function playAudio(): void {
  const audio = new Audio('/magic-spell.mp3');
  audio.volume = 0.8;
  audio.play();
}

async function startNewGame() {
  try {
    let wordOfTheDay;
    if (date) {
      const response = await Axios.get(`/word/WordOfTheDay/${date}`);
      wordOfTheDay = response.data;
    } else {
      const response = await Axios.get('/word/WordOfTheDay');
      wordOfTheDay = response.data;
    }
    console.log("Word of the Day:", wordOfTheDay); // Debug log to check the word of the day
    await game.startNewGame(wordOfTheDay);
  } catch (error) {
    console.error("Failed to fetch Word of the Day:", error); // Error handling
  }
}

onMounted(() => {
  window.addEventListener('keyup', onKeyup);
  const defaultName = nuxtStorage.localStorage.getData('name');
  showNameDialog.value = !defaultName;
  username.value = defaultName || 'Guest';
  startNewGame();
});

onUnmounted(() => {
  window.removeEventListener('keyup', onKeyup);
});

watch(() => game.gameState, () => {
  if (game.gameState == GameState.Won || game.gameState == GameState.Lost) {
    showGuestSaveDialog.value = username.value === 'Guest';
    if (!showGuestSaveDialog.value) {
      postScore();
    }
  }
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    game.submitGuess();
  } else if (event.key == "Backspace") {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    game.addLetter(event.key.toUpperCase());
  }
}

function enterName() {
  if (username.value.trim() === '') {
    username.value = 'Guest';
  } else {
    nuxtStorage.localStorage.setData('name', username.value);
  }
  showNameDialog.value = false;
}

function postScore() {
  const attempts = game.gameState == GameState.Won ? game.guessIndex + 1 : game.maxAttempts;
  Axios.post('/leaderboard/postscore', {
    Name: username.value,
    GameCount: 1,
    AverageAttempts: attempts,
  });
}
</script>
