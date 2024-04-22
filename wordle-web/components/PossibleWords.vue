<template>
  <div>
    <v-select
      clearable
      label="Possible Words: "
      v-model="selectedWord";
      :items="wordList"
      variant="solo-filled"
    ></v-select>
  </div>
</template>


<script setup lang="ts">
import { WordService } from "~/scripts/wordService";
import { ref, onMounted } from "vue";
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";
import { Game } from "~/scripts/game";

const wordList = ref<string[]>([]);
let currentGuess: Word | null = null;
let currentGuessStates: LetterState[];
let selectedWord = ref<string | null>(null);

onMounted(()=> {
  if(Game.guesses && Game.guesses.length > 0 && Game.guessIndex !== undefined && Game.secretWord){
    currentGuess = Game.guesses[Game.guessIndex];
    currentGuessStates = currentGuess.compare(Game.secretWord);
    populateWordList();
  }
});

const populateWordList = () => {
  if(currentGuess && currentGuessStates){
    const list = WordService.validGuessedWords(currentGuess, currentGuessStates);
    console.log(list);
    wordList.value = list;
  }
};


</script>


<style>
</style>
