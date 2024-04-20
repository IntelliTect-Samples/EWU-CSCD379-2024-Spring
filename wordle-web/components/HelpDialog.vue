<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-text> How to play Wordle </v-card-text>
      </v-sheet>
      <v-card-text>
        Wordle is a word puzzle game where you have to guess a five-letter word
        within a certain number of attempts. After each guess, Wordle will
        provide feedback to indicate if each letter:
        <ul>
          <li>Is in the correct position and is the right letter.</li>
          <li>Is in the word but in the wrong position.</li>
          <li>Is not in the word at all.</li>
        </ul>
      </v-card-text>
      <v-card-text>
        For example, if the word is "BLIMP" and you guess "BILBO", the feedback
        might look like this:
      </v-card-text>
      <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="exampleWord" />
      </div>

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

const exampleWord = new Word({ word: "BILBO" });
exampleWord.letters = [
    new Letter("B", LetterState.Correct),
    new Letter("I", LetterState.Correct),
    new Letter("L", LetterState.Misplaced),
    new Letter("B", LetterState.Wrong),
    new Letter("O", LetterState.Wrong),
]
</script>