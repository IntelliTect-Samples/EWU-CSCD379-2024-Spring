<template>
  <v-container>
    <v-card class="text-center" color="secondary">
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
      <v-card-title v-else style="font-size: xx-large;">Wordle</v-card-title>
      <v-card-subtitle style="font-size: medium;">Welcome, {{ userName }}</v-card-subtitle>

      <GameBoardGuess
        v-for="(guess, i) of game.guesses"
        :key="i"
        :guess="guess"
      />

      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn @click="game.submitGuess()" class="mb-5" elevation="5" color="primary">
        Guess!
      </v-btn>
    </v-card>
    <v-card color="primary" dark>
      <v-container>
        
        
        <ValidGuess
          v-model="engine"
          :game="game"
          @chooseWord="(word) => selectWord(word)"
        />
      </v-container>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import { provide, ref } from "vue";
const game: Game = reactive(new Game());
import nuxtStorage from 'nuxt-storage';


provide("GAME", game);

const myGuess = ref("");
const engine = ref(false);
const userName = ref(nuxtStorage.localStorage.getData("userName") ?? '');

function enterSound() 
{
  var sound = new Audio('/click.mp3');
  sound.play();
}

function backspaceSound() 
{
  var sound = new Audio('/backspace.mp3');
  sound.play();
}

function clickSound() 
{
  var sound = new Audio('/clicking.mp3');
  sound.play();
}

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    enterSound();
    game.submitGuess();
  } else if (event.key == "Backspace") {
    backspaceSound();
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    clickSound();
    game.addLetter(event.key.toUpperCase());
  }
}
</script>
