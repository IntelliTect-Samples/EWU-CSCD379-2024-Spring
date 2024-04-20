<template>
  <v-container>
    <v-card>
      <v-card class="text-center">
        <v-alert v-if="game.gameState != GameState.Playing"
          :color="game.gameState == GameState.Won ? 'sucess' : 'error'" tile>
          You {{ game.gameState == GameState.Won ? 'Won' : 'Lost' }}
          <v-card-text>
            The word was: {{ game.secretWord }}
          </v-card-text>
          <br />
          <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
        </v-alert>
      </v-card>
      <v-card-title>Wordle</v-card-title>

      <div v-if="game.gameState == GameState.Won">
        You've Won!
      </div>
      <div v-if="game.gameState == GameState.Lost">
        You've Lost!
      </div>

      <GameBoardGuess v-for="(guess, i) of game.guesses" :key="i" :guess="guess" />
      <div class="my-18">
        <Keyboard />
      </div>
      <v-btn color="secondary" class="justify-center" @click=game.submitGuess>Guess</v-btn>

      <v-card-actions>
        <v-spacer />
        <v-btn v-if="game.gameState !== GameState.Playing" variant="text" color="secondary" @click="game.startNewGame()">
          Restart Game
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
const game: Game = reactive(new Game());

provide("GAME", game);

const myGuess = ref("");

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    game.submitGuess();
  } else if (event.key == 'Backspace') {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    game.addLetter(event.key.toUpperCase());
  }
}
</script>
