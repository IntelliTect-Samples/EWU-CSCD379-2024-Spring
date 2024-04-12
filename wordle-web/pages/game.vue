<template>
    <v-container>
      <v-card
        color="secondary text-primary"
        class="mx-auto mt-8 w-75 pa-8 rounded text-center"
        elevation="4"
      >
        <v-card-item class="text-center">
          <v-card-title class="font-weight-bold">
            Pink Wordle <v-icon>mdi-heart</v-icon>
          </v-card-title>
          <v-card-subtitle>
            This is our super basic Pink Wordle game! Good luck!
          </v-card-subtitle>
          <v-card-text class="font-italic">
            "Pink Wordle is a delightful twist on the classic word puzzle game,
            Wordle. In this charming variant, the game's interface is adorned with
            various shades of pink, offering a refreshing and visually pleasing
            experience to the players. The objective remains the same - guess the
            hidden word within six attempts. Pink Wordle combines the mental
            challenge of the original game with a unique aesthetic, making it a
            must-try for puzzle enthusiasts and pink lovers alike."
          </v-card-text>
        </v-card-item>
        <v-spacer />
  
        <div v-if="game.gameState === GameState.Won">You've Won!</div>
        <div v-if="game.gameState === GameState.Lost">You've Lost!</div>
  
        <GameBoardGuess
          v-for="(guess, i) of game.guesses"
          :key="i"
          :guess="guess"
        />
  
        <v-card-actions class="justify-center mx-2 my-4">
          <v-spacer />
          <v-btn v-if="game.gameState !== GameState.Playing" color="secondary" class="bg-primary" @click="game.startNewGame()">
            Restart Game
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { Game, GameState } from "../scripts/game";
  const game: Game = reactive(new Game());
  
  onMounted(() => {
    window.addEventListener("keyup", onKeyup);
  });
  
  onUnmounted(() => {
    window.removeEventListener("keyup", onKeyup);
  });
  
  function onKeyup(event: KeyboardEvent) {
    if(event.key === "Enter") {
      game.submitGuess();
    } else if(event.key == 'Backspace'){
      game.removeLastLetter();
    } else if(event.key.match(/[A-z]/)){
      game.addLetter(event.key.toUpperCase());
    }
  }
  </script>