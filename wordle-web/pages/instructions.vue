<template>
  <v-card class="mx-auto w-75">
    <v-sheet color="secondary">
      <v-card-title> Instructions</v-card-title>
    </v-sheet>
    <v-card-text>
        &ensp; Whurdle is a classic take on the game wordle. The goal is to guess the Word of the day in 6 tries or less.
        The word is a 5 letter word and you can only guess words that are 5 letters long. After each guess, you will
        be given feedback on the letters you guessed correctly. The letters will be colored as follows: green for correct
        yellow for correct but in the wrong position, any other color will be wrong. For example, if the word of the day is "GROVE"
        if you guess "GROVE" you will see all green letters.
        <br>
        <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="correctWord" />
      </div>
        <br>
        &ensp; If you guess "VORTE" you will see "V" and "R" in yellow and "E" in green.
        <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="wrongWord" />
      </div>
      <br>
      &ensp; Other features of the game include a cheat button that will show you all the possible words based on your
      previous guesses and the current letters that are typed in. There is a settings button that will allow you to
      change the theme of the game which includes a regular, jungle, flamingo and Whurdle theme all with a light and dark version. The leaderboard will show
      the top 10 players. There is a keyboard that will allow you to type in your guesses. Fianlly there is a version of the game
      that allows you to play a game from a specific day and another version that allows you to play a random game. 

    </v-card-text>
    <v-btn @click="router.go(-1)" class="ma-4" color="secondary">Back</v-btn>
  </v-card>
</template>
<script setup lang="ts">
import { useRouter } from 'vue-router';
const router = useRouter();

import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";

const correctWord = new Word({ word: "GROVE" });
correctWord.letters = [
    new Letter("G", LetterState.Correct),
    new Letter("R", LetterState.Correct),
    new Letter("O", LetterState.Correct),
    new Letter("V", LetterState.Correct),
    new Letter("E", LetterState.Correct),
]
const wrongWord = new Word({ word: "GROVE" });
wrongWord.letters = [
    new Letter("V", LetterState.Wrong),
    new Letter("O", LetterState.Misplaced),
    new Letter("R", LetterState.Misplaced),
    new Letter("T", LetterState.Wrong),
    new Letter("E", LetterState.Correct),
]
</script>