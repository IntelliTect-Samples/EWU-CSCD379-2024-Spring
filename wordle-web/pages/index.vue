<template>
  <v-container class="myFontDefault">
    <v-card class="text-center">
      <v-alert v-if="game.gameState != GameState.Playing" :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5" tile>
        <h3>
          You've
          {{ game.gameState == GameState.Won ? "Won" : "Lost" }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>
      <v-card-title v-else>Wordle</v-card-title>

      <GameBoardGuess v-for="(guess, i) of game.guesses" :key="i" :guess="guess" />

      <h3>
        <ValidWord />
      </h3>
      
        <!--<h3>
          <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props" icon>
              <v-icon>mdi-view-list</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="word in validWords" :key="word">
              <v-list-item-title>{{ word }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </h3>
      -->
      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn @click="game.submitGuess()" class="mb-5" color="primary">
        Guess!
      </v-btn>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import { findValidWords } from "~/scripts/ValidWordList";
const game: Game = reactive(new Game());

provide("GAME", game);

const myGuess = ref("");

const validWords = computed(() => {
  return findValidWords(game);
});

/*watch(game.guessedLetters, () => {
  findValidWords(game);
  console.log(validWordList().length);
});*/

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
