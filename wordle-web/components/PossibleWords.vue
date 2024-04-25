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

function updateWordList() {
  wordList.value = wordService.getValidWords(game);
}

</script>


<style>
</style>
