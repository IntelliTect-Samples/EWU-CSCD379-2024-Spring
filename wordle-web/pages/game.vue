<template>
  <v-card
    class="mx-auto my-8 w-75 pa-5 rounded"
    color="secondary text-primary"
    elevation="4"
  >
    <v-card-item class="text-center">
      <v-card-title class="font-weight-bold"
        >Pink Wordle <v-icon icon="mdi-heart"></v-icon
      ></v-card-title>
      <v-card-subtitle>
        This is our super basic Pink Wordle game! Good luck!
      </v-card-subtitle>
    </v-card-item>
    <v-spacer />

    <Gameboard :game="game" :guess="myGuess" />

    <v-card-text class="text-center font-weight-bold text-h6 my-2">
      {{ displayGameState() }}
    </v-card-text>
    <v-text-field
      v-model="myGuess"
      label="Enter your guess"
      outlined
      clearable
      :disabled="game.state !== GameState.Playing"
    />

    <v-card-actions class="justify-center">
      <v-btn
        color="secondary"
        class="bg-primary"
        :disabled="game.state !== GameState.Playing || myGuess.length !== 5"
        @click="submitGuess()"
      >
        Guess!
      </v-btn>
      <v-btn color="secondary" class="bg-primary" to="/"> Go Back Home! </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { Game, GameState } from "@/scripts/game"; // Adjust the import path as necessary
import { ref, reactive } from "vue";
const wordsList = [
  "HEART",
  "GRACE",
  "HONEY",
  "CANDY",
  "SWEET",
  "LOVES",
  "SMILE",
  "PEACH",
  "BLOOM",
  "BLUSH",
  "DAISY",
  "FAIRY",
  "ANGEL",
  "BLISS",
  "CUPID",
  "DREAM",
  "FLORA",
  "LILAC",
  "MAGIC",
  "PIXIE",
  "TULIP",
  "MINTY",
  "CHARM",
];
const game: Game = reactive(
  new Game(wordsList[Math.floor(Math.random() * wordsList.length)])
);
const myGuess = ref("");

function submitGuess(): void {
  game.guess(myGuess.value.toUpperCase());
  myGuess.value = "";
}

function displayGameState(): string {
  switch (game.state) {
    case GameState.Won:
      return "You won :)";
    case GameState.Loss:
      return "You lost :( The word was: " + game.wordToGuess;
    default:
      return "Good luck!!!";
  }
}
</script>
