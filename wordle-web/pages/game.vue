<template>
  <v-card
    class="mx-auto my-8 pa-5"
    color="secondary text-primary"
    elevation="4"
    max-width="750"
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

    <v-card-actions>
      <v-spacer />
      <v-btn color="secondary" class="bg-primary" @click="submitGuess()">
        Click Me!
      </v-btn>
      <v-btn color="secondary" class="bg-primary" to="/"> Go Back Home! </v-btn>
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
