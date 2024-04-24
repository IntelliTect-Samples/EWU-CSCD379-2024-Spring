<template>
  <div>
    <v-select
      clearable
      :label="labelText"
      v-model="selectedWord"
      :items="wordList"
      variant="solo-filled"
      :menu-props="{ bottom: true }"
    ></v-select>
  </div>
</template>


<script setup lang="ts">
import { WordService } from "~/scripts/wordService";
import { ref, onMounted, watch, inject, computed } from "vue";
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";
import { Game } from "~/scripts/game";

const labelText = "Possible Words: 10000";

const game = inject("GAME") as Game;

const { emit } = defineEmits(["selectedWord"]);

const wordList = ref<string[]>([]);
let selectedWord = ref<string | null>(null);

watch(() => game?.guesses, (newGuesses) => {
  if (newGuesses){
    const stateArray = getStateArray(newGuesses);
    wordList.value = WordService.validGuessedWords(newGuesses, stateArray);
  }
});

onMounted(()=> {
  if(game?.guesses){
    const stateArray = getStateArray(game.guesses);
    wordList.value = WordService.validGuessedWords(game.guesses, stateArray);
  }
});

function getStateArray(guesses: string[]): LetterState[][] {
  return guesses.map(word => {
    return word.letters.map(letter => {
      console.log(letter.state);
      return letter ? letter.state : LetterState.Unknown;
    });
  });
}

</script>


<style>
</style>
