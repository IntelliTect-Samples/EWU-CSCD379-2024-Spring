<template>
  <v-card
    class="mx-auto my-8 w-75 pa-5 rounded"
    color="secondary text-primary"
    elevation="4"
  >
    <v-card-item class="text-center">
      <v-card-title class="font-weight-bold">Pink Wordle!</v-card-title>
      <v-card-subtitle>
        This is our super basic Pink Wordle game! Good luck!
      </v-card-subtitle>
      <v-card-text class="font-italic">
        "Pink Wordle is a delightful twist on the classic word puzzle game,
        Wordle. In this charming variant, the game's interface is adorned with
        various shades of pink, offering a refreshing and visually pleasing
        experience to the players. The objective remains the same - guess the
        hidden word within six attempts. Each correct letter in the right
        position is highlighted in a darker shade of pink, while a correct
        letter in the wrong position is shown in a lighter pink. Incorrect
        letters remain gray. Pink Wordle combines the mental challenge of the
        original game with a unique aesthetic, making it a must-try for puzzle
        enthusiasts and pink lovers alike."
      </v-card-text>
    </v-card-item>
    <v-spacer />

    <v-card-text class="text-center font-weight-bold text-h6">
      {{ displayGameState() }}
    </v-card-text>

    <v-card-text>
      <div v-for="(guess, i) of game.guesses" :key="i">
        Guess {{ i + 1 }}:
        <v-chip
          v-for="(letter, j) of guess.letters"
          :key="j"
          :color="displayLetterState(letter)"
          class="ma-1"
          >{{ letter.char }}
        </v-chip>
      </div>
    </v-card-text>

    <v-card-text class="text-h6">
      My Guess: {{ myGuess }}
      <v-text-field
        v-model="myGuess"
        label="Enter your guess"
        outlined
        clearable
        :disabled="game.state === GameState.Playing ? false : true"
      />
    </v-card-text>

    <v-card-actions class="justify-center align-center">
      <v-btn
        color="secondary"
        class="bg-primary"
        :disabled="
          game.state !== GameState.Playing
            ? true
            : myGuess === '' || myGuess.length !== game.wordToGuess.length
            ? true
            : false
        "
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
import { Letter, LetterState } from "@/scripts/letter"; // Adjust the import path as necessary

import { ref, reactive } from "vue";
const wordsList = ["HEART", "GRACE", "HONEY", "CANDY", "SWEET", "LOVES"];
const game: Game = reactive(
  new Game(wordsList[Math.floor(Math.random() * wordsList.length)])
);
const myGuess = ref("");

function submitGuess() {
  game.guess(myGuess.value.toUpperCase());
  myGuess.value = "";
}

function displayLetterState(letter: Letter) {
  switch (letter.state) {
    case LetterState.Correct:
      return "success";
    case LetterState.Misplaced:
      return "warning";
    case LetterState.Wrong:
      return "error";
  }
}

function displayGameState() {
  switch (game.state) {
    case GameState.Playing:
      return "";
    case GameState.Won:
      return "You won!";
    case GameState.Loss:
      return "You lost :( The word was: " + game.wordToGuess;
  }
}
</script>
