<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-title> How to play Wordle </v-card-title>
      </v-sheet>
      <v-card-text>
        Wordle is a word puzzle game where you have to guess a five-letter word
        within a certain number of attempts. After each guess, Wordle will
        provide feedback to indicate if each letter:
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
      <v-card-actions>
        <v-spacer></v-spacer>

        <v-btn
          color="secondary"
          variant="flat"
          text="Close"
          @click="modelValue = false"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";

const modelValue = defineModel<boolean>({ default: false });

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
