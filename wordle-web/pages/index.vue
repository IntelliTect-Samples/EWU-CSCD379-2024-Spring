<template>
  <v-container>
    <v-card>
      <v-card-title>Wordle</v-card-title>

      <GameBoardGuess
        v-for="(guess, i) of game.guesses"
        :key="i"
        :guess="guess"
      />
    </v-card>

    <!-- Old Stuff -->
    <div>
      <v-divider class="my-5" />
      <h3>My Old UI</h3>
      <v-card>
        <v-card-title>Hello Welcome to Home</v-card-title>
      </v-card>

      <v-card elevation="16">
        <v-card-item>
          <v-card-title> Wordle </v-card-title>
          <v-card-subtitle>
            This is our super basic wordle game
          </v-card-subtitle>
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
    </div>
  </v-container>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Game } from "../scripts/game";
const game: Game = reactive(new Game("JUMBO"));

const myGuess = ref("");

function submitGuess() {
  game.guess(myGuess.value.toUpperCase());
  myGuess.value = "";
}
</script>

