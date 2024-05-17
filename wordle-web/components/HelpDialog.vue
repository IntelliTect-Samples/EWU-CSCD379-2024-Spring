<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card style="background-color: myFunction()" color = "secondary">
      <v-sheet color="primary">
        <v-card-text
          style="text-align: center; font-size: larger"
        >
          <header>
            How to play Wordle
          </header>
        </v-card-text>
      </v-sheet>
      <v-card-actions>
        <v-btn
          style="box-shadow: inset;"
          color="red"
          variant="flat"
          text="Close"
          @click="modelValue = false"
        />
      </v-card-actions>
      <v-card-text style="text-align: center; font-size: medium">
        <header>Guess the Wordle in 6 tries.</header>
      </v-card-text>
      <v-card-text>
        <ul>
          <li>Each guess must be a valid 5-letter word.<br /></li>
          <li>
            The color of the tiles will change to show how close your guess was
            to the word.
          </li>
        </ul>
      </v-card-text>

      <v-card-text style="text-align: center">
        <header>Types of state for each letter.</header>
      </v-card-text>

      <v-card-text>
        <ul>
          <li>Is in the correct position and is the right letter.</li>
          <li>Is in the word but in the wrong position.</li>
          <li>Is not in the word at all.</li>
        </ul>
      </v-card-text>

      <v-card-text style="text-align: center">
        For example, if the word is "BLIMP" and you guess "BILBO", the feedback
        might look like this:
      </v-card-text>
      <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="exampleWord" />
      </div>
      <v-card-item>
        <v-card-text style="text-align: center">
          <header>Color Codes</header>
        </v-card-text>
        <v-container style="text-align: center" class="d-flex flex-row ga-12">
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
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";
import { useTheme } from "vuetify";
import nuxtStorage from 'nuxt-storage';
import { ref } from "vue";

const modelValue = defineModel<boolean>({ default: false });

const exampleWord = new Word({ word: "BILBO" });
exampleWord.letters = [
  new Letter("B", LetterState.Correct),
  new Letter("I", LetterState.Correct),
  new Letter("L", LetterState.Misplaced),
  new Letter("B", LetterState.Wrong),
  new Letter("O", LetterState.Wrong),
];
const key = {
  letters: [
    new Letter("Correct", LetterState.Correct),
    new Letter("Misplaced", LetterState.Misplaced),
    new Letter("Wrong", LetterState.Wrong),
  ],
};
function myFunction() {
  document.body.style.backgroundColor = theme.global.name.value;
  nuxtStorage.localStorage.setData("themes", theme.global.name.value);;
}
</script>

