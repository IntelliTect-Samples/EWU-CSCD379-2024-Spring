<template>
    <v-card elevation="16" min-width="344">
        <v-card-title>Hello Welcome to Pentagram</v-card-title>
        <v-card-subtitle> This is our super basic wordle game called Pentagram. Penta for five, and gram for letter</v-card-subtitle>
    </v-card>
    <v-card class="mx-auto my-8" elevation="16" min-width="344">
        <v-card-item>
          <v-card-title> Pentagram </v-card-title>
        </v-card-item>

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

        <v-card-text>
          <div v-for="(guess, i) of game.guesses" :key="i">
            Guess: {{ guess.letters.map(x => x.char).join("") }}
          </div>
        </v-card-text>

        <v-card-actions>
          <v-spacer />
          <v-btn
            color="pink"
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
import { Game } from "../scripts/game";
const game: Game = reactive(new Game("JUMBO"));

const myGuess = ref("");

function submitGuess() {
  game.guess(myGuess.value.toUpperCase());
  myGuess.value = "";
}
</script>
