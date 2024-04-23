import {WordList} from "wordList.ts";
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

      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn @click="game.submitGuess()" class="mb-5" color="primary">
        Guess!
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn color="primary" class="mb-5">
        Available Words: {{ availableWords }}
      </v-btn>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
const game: Game = reactive(new Game());
const availableWords = ref(5);

provide("GAME", game);

const myGuess = ref("");
var list = ref(false);

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

function toggleList() {
  list.value = !list.value;
}

function wordList(item: String) {
  game.addLetter(item.charAt(0).toLocaleUpperCase());
  game.addLetter(item.charAt(1).toLocaleUpperCase());
  game.addLetter(item.charAt(2).toLocaleUpperCase());
  game.addLetter(item.charAt(3).toLocaleUpperCase());
  game.addLetter(item.charAt(4).toLocaleUpperCase());
}

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
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
</script>
