<template>
  <v-container>
   
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
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
const game: Game = reactive(new Game());
const showWordsList = ref(false);
const isGameOn = ref(false);
const typedName = ref("");
const playerName = ref("");

import {
  playClickSound,
  playEnterSound,
  playLoseSound,
  playWinSound,
} from "../scripts/soundUtils";

provide("GAME", game);

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (showWordsList.value) {
    return;
  }

  if (event.key === "Enter") {
    let currentGuessIndex = game.guessIndex;
    game.submitGuess();
    if (currentGuessIndex !== game.guessIndex) {
      playEnterSound();
    }
  } else if (event.key == "Backspace") {
    playClickSound();
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    playClickSound();
    game.addLetter(event.key.toUpperCase());
  }
}
/*
function updatePlayerName() {
  playerName.value = typedName.value;
}
*/
watch(game, () => {
  if (game.gameState !== GameState.Playing) {
    isGameOn.value = true;
  } else {
    isGameOn.value = false;
  }
});
watch(
  () => game.gameState,
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
    game.startNewGame();
  }, 300);
}
</script>
