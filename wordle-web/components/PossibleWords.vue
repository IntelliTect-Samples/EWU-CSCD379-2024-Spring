<template>
  <div>
    <v-select
      clearable
      label="Select a Word: "
      v-model="selectedWord"
      :items="wordList"
      variant="solo-filled"
      @input="populateGuess"
    ></v-select>
    <v-label>
      Possible Words: {{ wordList.length }}
    </v-label>
  </div>
</template>


<script setup lang="ts">
import { WordService } from "~/scripts/wordService";
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";
import { Game } from "~/scripts/game";
import { WordList } from "~/scripts/wordList";

const labelText = "Possible Words: ";

const game = inject("GAME") as Game;

const wordService = new WordService();

const wordList = ref<string[]>([]);
let selectedWord = ref<string | null>(null);

onMounted(() => {
  updateWordList();
});

watch(() => game.guessedLetters, () => {
    updateWordList();
}, { deep: true });

watch(selectedWord, (newValue) => {
  if(newValue){
    populateGuess();
  }
});

function updateWordList() {
  wordList.value = wordService.getValidWords(game);
}

function populateGuess(){
  game.guess.clear();
  if(selectedWord.value){
    for (let i = 0; i < selectedWord.value.length; i++){
      game.addLetter(selectedWord.value[i].toUpperCase());
    }
  }
}

</script>
