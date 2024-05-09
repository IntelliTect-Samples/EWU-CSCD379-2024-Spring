<template>
  <v-container>
    <v-dialog v-model="isGameOver" class="mx-auto" max-width="500">
      <v-card
        :color="game.gameState == GameState.Won ? 'win' : 'lose'"
        tile
        class="pa-5 text-center text-white"
        rounded
      >
        <v-card-title class="text-h4">
          You've
          {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
        </v-card-title>

        <v-card-text class="my-3">
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-card-actions class="mx-auto">
          <v-btn variant="outlined" @click="closeGameDialog">
            <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Play Again
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-col class="d-flex flex-column align-end ga-3">
      <v-row>
        <v-sheet
          class="pa-2 cursor-pointer"
          color="primary"
          width="200"
          rounded
          elevation="4"
          @click="showNameDialog = !showNameDialog"
        >
          <strong>Username:</strong> {{ playerName }}
        </v-sheet>
      </v-row>
      <v-row>
        <v-sheet width="200" class="pa-2" color="primary" rounded elevation="4">
          <strong> Current Time:</strong> {{ stopwatch.getCurrentTime() }}
        </v-sheet>
      </v-row>
    </v-col>
    <GameBoardGuess
      v-for="(guess, i) of game.guesses"
      :key="i"
      :guess="guess"
    />
    <div class="d-flex justify-center my-3">
      <v-btn
        v-if="game.gameState !== GameState.Playing"
        @click="isGameOver = true"
        color="primary"
        text="RESULTS"
        height="40px"
        width="120px"
      />
    </div>

    <Keyboard />

    <WordList
      v-if="game.gameState === GameState.Playing"
      v-model="showWordsList"
    />
    <NameDialog
      v-model:show="showNameDialog"
      v-model:name="playerName"
      @entered="enterPlayerName"
    />
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import { Stopwatch } from "~/scripts/stopwtch";
import nuxtStorage from "nuxt-storage";
import Axios from "axios";

const showWordsList = ref(false);
const isGameOver = ref(false);
const playerName = ref("");
const showNameDialog = ref(false);
import {
  playClickSound,
  playEnterSound,
  playLoseSound,
  playWinSound,
} from "../scripts/soundUtils";

const game: Ref<Game> = ref(new Game("GAMES"));
provide("GAME", game);
const stopwatch = ref(new Stopwatch());

onMounted(() => {
  getWordFromApi().then((word) => {
    game.value = new Game(word);
  });
  window.addEventListener("keyup", onKeyup);
  const defaultName = nuxtStorage.localStorage.getData("name");
  showNameDialog.value = defaultName ? false : true;
  playerName.value = showNameDialog.value ? "Guest" : defaultName;

  stopwatch.value.start();
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (showWordsList.value) {
    return;
  }
  if (showNameDialog.value) {
    if (event.key === "Enter") {
      enterPlayerName();
    }
  } else {
    if (event.key === "Enter") {
      let currentGuessIndex = game.value?.guessIndex;
      game.value?.submitGuess();
      if (currentGuessIndex !== game.value?.guessIndex) {
        playEnterSound();
      }
    } else if (event.key == "Backspace") {
      playClickSound();
      game.value?.removeLastLetter();
    } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
      playClickSound();
      game.value?.addLetter(event.key.toUpperCase());
    }
  }
}

watch(
  () => game.value?.gameState,
  (newState) => {
    switch (newState) {
      case GameState.Won:
        playWinSound();

        stopwatch.value.stop();
        saveScore();

        isGameOver.value = true;
        break;
      case GameState.Lost:
        playLoseSound();
        stopwatch.value.stop();
        saveScore();

        isGameOver.value = true;
        break;
      case GameState.Playing:
        isGameOver.value = false;
        break;
    }
  }
);
function closeGameDialog() {
  isGameOver.value = false;
  setTimeout(() => {
    game.value?.startNewGame();
  }, 300);
}

function enterPlayerName() {
  if (playerName.value === "") {
    playerName.value = "Guest";
  } else {
    nuxtStorage.localStorage.setData("name", playerName.value);
  }
  showNameDialog.value = !showNameDialog.value;
}

async function getWordFromApi(): Promise<string> {
  let wordUrl = "word/wordOfTheDay";

  const response = await Axios.get(wordUrl);
  console.log("Response from API: " + response.data);
  return response.data;
}

async function saveScore() {
  let scoreUrl = "player/saveScore";
  let data = {
    name: playerName.value,
    averageAttempts: game.value?.guessIndex + 1,
    averageSeconds: stopwatch.value.getCurrentTime(),
  };
  await Axios.post(scoreUrl, data, {
    headers: { "Content-Type": "application/json" }, // config
  })
    .then((res) => console.log(res))
    .catch((err) => console.log(err));
}
</script>
