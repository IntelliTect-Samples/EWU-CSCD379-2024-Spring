<template>
    <v-bottom-sheet
      v-model="modelValue"
      max-height="600"
      max-width="160"
      class="pa-2 justify-left align-left"
    >
      <v-card>
        <v-btn
          height="40px"
          class="align-center d-flex justify-center"
          v-for="word in pagedWords"
          :key="word"
          @click="addGuess(word)"
        >
          {{ word.toUpperCase() }}
        </v-btn>
        <v-card-item class="ma-3">
          <v-pagination
            density="compact"
            v-model="currentPage"
            :length="totalPages"
            total-visible="1"
          />
        </v-card-item>
      </v-card>
    </v-bottom-sheet>
    <v-btn
      size="default"
      color="primary"
      @click="modelValue = true"
      >Valid Words Left: {{ validWords().length }}</v-btn
    >
  </template>
  
  <script setup lang="ts">
  import { WordList } from "~/scripts/wordList";
  import { Game } from "~/scripts/game";
  import { updateValidWords } from "~/scripts/wordListUtils";
  const game: Game = inject("GAME")!;
  
  const modelValue = defineModel<boolean>({ default: false });
  const words = WordList;
  const totalPages = ref(Math.ceil(words.length / 10));
  const updatedWords = ref(words);
  const currentPage = ref(1);
  const pagedWords = computed(() => {
    const start = (currentPage.value - 1) * 10;
    return (game.guessedLetters.length === 0 ? words : validWords()).slice(
      start,
      start+10
    );
  });
  
  function validWords(): string[] {
    return updateValidWords(game);
  }
  
  function addGuess(word: string) {
    game.guess.clear();
    for (let i = 0; i < 5; i++) {
      game.addLetter(word[i].toUpperCase());
    }
    modelValue.value = false;
    currentPage.value = 1;
  }
  
  watch(game.guessedLetters, () => {
    updatedWords.value = validWords();
    totalPages.value = Math.ceil(updatedWords.value.length / 10);
  });
  
  </script>
