<template>
  <v-container style="max-width: 900px;">
    <v-progress-linear v-if="game.isBusy" color="primary" indeterminate />
    <v-card v-else class="text-center">
      <v-alert v-if="game.gameState != GameState.Playing" :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5" tile>
        <h3>
          You've
          {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-row v-if="game.stats" class="mb-1" justify="center">
          <v-col cols="auto">
            <v-progress-circular size="75" width="10" v-model="game.stats.winPercentage">
              {{ game.stats.winPercentage }}%
            </v-progress-circular>
            <br />
            <i class="text-caption">
              Success Rate
            </i>
          </v-col>
          <v-col cols="auto">
            <v-progress-circular size="75" width="10" :model-value="game.stats.averageGuessesPercent(game.maxAttempts)">
              {{ game.stats.averageGuessesPercent(game.maxAttempts).toFixed(0) }}%
            </v-progress-circular>
            <br />
            <i class="text-caption">
              Average Guesses
            </i>
          </v-col>
        </v-row>
        <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>
      <v-card-title v-else>Random Word Game</v-card-title>

      <v-card-text class="d-flex  flex-row justify-end">
        <v-row>
          <v-col cols="12" sm="8">
            <v-btn color="secondary" @click="showDatePicker = true">
                <v-icon> mdi-calendar-today </v-icon> {{ currentDate.toDateString() }}
            </v-btn>
          </v-col>
          <v-col cols="12" sm="4">
            <v-chip color="secondary" class="mr-2" @click="showUserNameDialog = true">
              <v-icon class="mr-2"> mdi-account </v-icon> {{ nameUserNameDialog }}
            </v-chip>
            <v-chip color="secondary" class="mr-2">
              <v-icon class="mr-2"> mdi-timer </v-icon> {{ seconds }} s.
            </v-chip>
          </v-col>
        </v-row>
      </v-card-text>

      <GameBoardGuess v-for="(guess, i) of game.guesses" :key="i" :guess="guess" />

      <div class="my-10">
        <Keyboard />
      </div>

      <v-row class="mb-5" justify="end">
        <v-col cols="12" sm="4">
          <WordList v-if="game.gameState === GameState.Playing" v-model="showWordsList" />
        </v-col>
        <v-col cols="12" sm="4">
          <v-btn @click="game.startNewGame()" color="primary">
            Guess!
          </v-btn>
        </v-col>
        <v-col cols="12" sm="4">
          <v-btn color="primary" @click="router.push('/Leaderboard')">Leaderboard</v-btn>
        </v-col>
      </v-row>
    </v-card>

    <UserNameDialog @okay="nameDialogClosed()" v-model:show="showUserNameDialog"
      v-model:userName="nameUserNameDialog" />

    <v-dialog v-model="showDatePicker" >
      <v-date-picker color="primary" v-model="currentDate" @input="showDatePicker = false" />
    </v-dialog>

  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import nuxtStorage from "nuxt-storage";
import Axios from 'axios'
import type { Player } from "../scripts/player";
import UserNameDialog from "~/components/UserNameDialog.vue";

// Date picker
const currentDate = ref(new Date());
const showDatePicker = ref(false);

console.log("Date: ", currentDate.value.);

const router = useRouter();
const game = reactive(new Game());
game.startNewGame();
provide("GAME", game);

// User name dialog
const showUserNameDialog = ref(false);
const nameUserNameDialog = ref("");

function nameDialogClosed() {
  showUserNameDialog.value = false;
  startStopwatch();
}

var showWordsList = ref(false);

onMounted(() => {

  window.addEventListener("keyup", onKeyup);

  if (!showUserNameDialog.value) {
    startStopwatch();
  }

});


onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

async function getWordFromApi(): Promise<string> {
  let wordUrl = "word/wordOfTheDay";
  const response = await Axios.get(wordUrl);
  return response.data;
}

function onKeyup(event: KeyboardEvent) {
  if (showUserNameDialog.value) {
    if (event.key === 'Enter') {
      showUserNameDialog.value = false;
      nuxtStorage.localStorage.setData("userName", nameUserNameDialog.value);
    }
  } else {
    if (event.key === "Enter") {
      game.submitGuess();
    } else if (event.key == "Backspace") {
      game.removeLastLetter();
    } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
      game.addLetter(event.key.toUpperCase());
    }
  }

}

async function checkUserNameLocalStorage() {

  if (nuxtStorage.localStorage.getData("userName") != null) {
    nameUserNameDialog.value = nuxtStorage.localStorage.getData("userName");
    showUserNameDialog.value = false;
  }
  else {
    nameUserNameDialog.value = "Guest";
    showUserNameDialog.value = true;
  }

}

async function checkUserName() {
  const response = await Axios.get("/Player/Player?playerName=" + nameUserNameDialog.value);
  const player: Player = response.data;

  if (player.name == "Guest") {
    showUserNameDialog.value = true;
  }
}

// Fix: Check if game is not busy before checking username
watch(() => game.isBusy, (value) => {
  if (!value) {
    checkUserNameLocalStorage();
    checkUserName();
  }
});

watch(() => game.gameState, (value) => {
  if (value == GameState.Won || value == GameState.Lost) {
    if (nameUserNameDialog.value == "Guest") {
      showUserNameDialog.value = true;
    }

    stopStopwatch();
  }

  if (value == GameState.Playing) {
    resetStopwatch();
  }
});

// Watch for showUserNameDialog, pause stopwatch if dialog is shown.
watch(() => showUserNameDialog.value, (value) => {
  if (value == false) {
    startStopwatch();
  } else {
    stopStopwatch();
  }
})


// Stopwatch implementation
let running = false;

const seconds = ref(0);
const interval = ref<number | undefined>();

function startStopwatch() {
  if (running) return;

  interval.value = setInterval(() => {
    seconds.value++;
  }, 1000);

  running = true;
}

function stopStopwatch() {
  if (interval.value) {
    clearInterval(interval.value);
    interval.value = undefined;
  }

  running = false;
}

function resetStopwatch() {
  seconds.value = 0;

  if (interval.value) {
    clearInterval(interval.value);
    interval.value = undefined;
  }

  running = false;
  startStopwatch();
}



</script>
