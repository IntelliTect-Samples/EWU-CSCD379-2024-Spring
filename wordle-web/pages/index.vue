<template>
  <v-container>
    <v-row>
      <v-col cols="12" class="d-flex justify-end">
        <v-sheet
          class="pa-2 cursor-pointer mt-3 d-flex"
          color="primary"
          min-width="150"
          max-width="900"
          @click="showNameDialog = !showNameDialog"
        >
          <div class="shrink-0 no-wrap pr-4">Player Name:</div>
          <div>
            {{ playerName }}
          </div>
        </v-sheet>
      </v-col>
    </v-row>
    <v-dialog v-model="isGameOn" class="mx-auto" max-width="500">
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
    <GameBoardGuess
      v-for="(guess, i) of game.guesses"
      :key="i"
      :guess="guess"
    />
    <div class="d-flex justify-center my-3">
      <v-btn
        v-if="game.gameState !== GameState.Playing"
        @click="isGameOn = true"
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
import nuxtStorage from "nuxt-storage";
import Axios from "axios";

const showWordsList = ref(false);
const isGameOn = ref(false);
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

onMounted(() => {
  // Get random word from word list
  getWordFromApi().then((word) => {
    game.value = new Game(word);
  });
  window.addEventListener("keyup", onKeyup);
  var defaultName = nuxtStorage.localStorage.getData("name");
  showNameDialog.value = defaultName ? false : true;
  playerName.value = showNameDialog.value ? "Guest" : defaultName;
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

watch(game.value, () => {
  if (game.value?.gameState !== GameState.Playing) {
    isGameOn.value = true;
  } else {
    isGameOn.value = false;
  }
});
watch(
  () => game.value?.gameState,
  (newState) => {
    switch (newState) {
      case GameState.Won:
        playWinSound();
        isGameOn.value = true;
        break;
      case GameState.Lost:
        playLoseSound();
        isGameOn.value = true;
        break;
      case GameState.Playing:
        isGameOn.value = false;
        break;
    }
  }
);
function closeGameDialog() {
  isGameOn.value = false;
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
</script>
