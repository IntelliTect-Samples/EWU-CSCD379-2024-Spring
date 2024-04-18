<template>
  <v-container>
    <v-card class="text-center">
      <v-alert
        v-if="game.gameState != GameState.Playing"
        :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5"
        tile
      >
        <h3>
          You've
          {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>
      <v-card-title v-else>Wordle</v-card-title>

      <GameBoardGuess
        v-for="(guess, i) of game.guesses"
        :key="i"
        :guess="guess"
      />

      <Keyboard />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
const game: Game = reactive(new Game());

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
  } else if (event.key == "Backspace") {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/)) {
    game.addLetter(event.key.toUpperCase());
  }
}
</script>
