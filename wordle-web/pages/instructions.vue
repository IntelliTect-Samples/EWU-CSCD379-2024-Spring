<template>
  <v-container>
    <v-card
      color="secondary"
      class="mx-auto pa-8 rounded text-center"
      elevation="4"
    >
      <v-card-title class="text-wrap">
        How to play Aesthetic Wordle
      </v-card-title>
      <v-card-text>
        Wordle is a poetic journey through language, where each guess paints a
        delicate picture of meaning on the canvas of possibility, revealing the
        hidden hues of words until the final stroke unveils the masterpiece of
        understanding.
      </v-card-text>
      <v-card-text class="ml-3">
        <ul>
          <li>Is in the correct position and is the right letter.</li>
          <li>Is in the word but is in a misplaced position.</li>
          <li>Is not in the word at all and is wrong.</li>
        </ul>
      </v-card-text>
      <v-card-text>
        For example, if the word is "DAISY" and you guess "BASED", the feedback
        might look like this:
      </v-card-text>
      <v-card-item>
        <GameBoardGuess :guess="exampleWord" />
      </v-card-item>

      <v-card-item>
        <v-label>Color Codes</v-label>
        <v-container class="d-flex flex-row ga-5">
          <LetterResult
            v-for="letter in key.letters"
            :key="letter.char"
            :letter="letter"
            :clickable="false"
            width="100px"
          />
        </v-container>
      </v-card-item>

      <v-divider />
      <v-card-actions class="d-flex justify-center">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Go Home"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";

const exampleWord = new Word({ word: "BASED" });
exampleWord.letters = [
  new Letter("B", LetterState.Wrong),
  new Letter("A", LetterState.Correct),
  new Letter("S", LetterState.Misplaced),
  new Letter("E", LetterState.Wrong),
  new Letter("D", LetterState.Misplaced),
];

const key = {
  letters: [
    new Letter("Correct", LetterState.Correct),
    new Letter("Misplaced", LetterState.Misplaced),
    new Letter("Wrong", LetterState.Wrong),
  ],
};
</script>
