<template>
  <v-card
    class="mx-auto my-8 text-primary pa-5"
    color="tertiary"
    elevation="24"
    max-width="500"
  >
    <v-card-item>
      <v-card-title class="text-center font-weight-bold">Wordle</v-card-title>
      <v-card-subtitle class="text-center" color="secondary">
        This is our super basic Wordle game! Good luck
      </v-card-subtitle>
    </v-card-item>
    <v-spacer />
    <v-card-text>
      Hint: {{ game.wordToGuess }}
      <br />
      My Guess: {{ myGuess }}
      <v-text-field
        v-model="myGuess"
        label="Enter your guess"
        outlined
        clearable
      />
    </v-card-text>
    <v-spacer />

    <v-card-text>
      <div v-for="(guess, i) of game.guesses" :key="i">
        Guess: {{ guess.letters.map((x) => x.char).join("") }}
      </div>
    </v-card-text>

    <v-card-actions class="mx-auto">
      <v-spacer />
      <v-btn
        color="primary"
        variant="elevated"
        elevation="8"
        @click="submitGuess()"
      >
        Click Me!
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { Game } from "@/scripts/game"; // Adjust the import path as necessary
import { ref, reactive } from "vue";

const game: Game = reactive(new Game("JUMBO"));
const myGuess = ref("");

function submitGuess() {
  game.guess(myGuess.value.toUpperCase());
  myGuess.value = "";
}
</script>
