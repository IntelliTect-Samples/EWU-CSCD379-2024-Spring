<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-text> How to play Wordle </v-card-text>
      </v-sheet>
      <v-card-text>
      How To Play <br>
      Guess the Wordle in 6 tries.<br>
      *Each guess must be a valid 5-letter word.<br>
      *The color of the tiles will change to show how close your guess was to the word.
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
          variant="tonal"
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
