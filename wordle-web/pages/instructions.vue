<template>
  <v-card class="mx-auto w-75" color="primary">
    <v-sheet color="secondary">
      <v-card-title> Instructions</v-card-title>
    </v-sheet>
    <v-card-text>
        &ensp; The goal of the game is to guess the Word of the day in 6 tries or less.
        The word is a 5 letter word and you can only guess words that are 5 letters long which are real valid words. After each guess, you will
        be given the states of each letter. The letters will be colored as follows: green for is in the correct postion and is the right letter
        yellow for the letter is in the word but in the wrong position, gray/other color for the letter is not in the word. For example, if the word of the day is "GROVE"
        if you guess "BLIMB" you will see all green letters.
        <br>
        <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="correctWord" />
      </div>
        <br>
        &ensp; If you guess "BILBO" this is whay you will see.
        <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="wrongWord" />
      </div>
      <br>
      &ensp; One helpful feature is the word engine button that will show all avalible words based on the current state of the game, as you guess words the number of valid words goes down
      
      
      
    </v-card-text>
    <v-card-text>
      <br>
      &ensp;
      There is a settings button that gives you the option to change the theme of the game.
      The leaderboard should show the top 10 players (WORK IN PROGRESS).
      There is two modes of the game, one that is a random word each time you play, another is word of the day mode which only has one word per day based of time. 
    </v-card-text>

    <div class="d-flex justify-center mt-3 mb-5" >
    <v-btn prepend-icon="mdi-home-export-outline" @click="router.go(-1)"color="secondary"> Back</v-btn>
  </div>
  <div class="d-flex justify-center mt-3 mb-5" >
    <v-btn
      prepend-icon="mdi-home-export-outline"
      @click="router.push('/')"
      color="secondary"
      >Home</v-btn>
      </div>
  </v-card>
</template>
<script setup lang="ts">
import { useRouter } from 'vue-router';
const router = useRouter();

import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";

const correctWord = new Word({ word: "BLIMP" });
correctWord.letters = [
    new Letter("B", LetterState.Correct),
    new Letter("L", LetterState.Correct),
    new Letter("I", LetterState.Correct),
    new Letter("M", LetterState.Correct),
    new Letter("P", LetterState.Correct),
]
const wrongWord = new Word({ word: "BILBO" });
wrongWord.letters = [
    new Letter("B", LetterState.Correct),
    new Letter("I", LetterState.Correct),
    new Letter("L", LetterState.Misplaced),
    new Letter("B", LetterState.Wrong),
    new Letter("O", LetterState.Wrong),
]
</script>