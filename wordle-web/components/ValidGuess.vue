<template>
  <v-bottom-sheet
    v-model="modelValue"
    max-height="600"
    class="pa-2 d-flex flex-wrap justify-center align-center"
  >
    <v-card :class="{ 'bottom-sheet-card-light': isLightMode, 'bottom-sheet-card-dark': !isLightMode }">
      <v-autocomplete 
        style="outline: auto; outline-style: double inset outset; width: auto; outline-style: outset;"
        
        v-model="selectedWord"
        prepend-inner-icon="mdi-cat"
        :items="validWords()"
        placeholder="Search"
        @update:modelValue="updatePage"
        
        :style="{ color: isLightMode ? 'black' : 'white' }"
        
      >
      </v-autocomplete>
      <v-btn
        class="word-button"
        v-for="word in pagedWords"
        :key="word"
        @click="addGuess(word)"
        elevation="5"
        color=""
      >
        {{ word.toUpperCase() }}
      </v-btn>
      <v-card-item class="ma-3" style="color: purple; font-size: x-large;">
        <v-pagination 
          density="compact"
          v-model="currentPage"
          :length="totalPages"
        />
      </v-card-item>
    </v-card>
  </v-bottom-sheet>

  <v-btn
    elevation="10"
    prepend-icon="mdi-engine"
    color="secondary"
    dark
    @click="modelValue = true"
    >Word Engine {{ validWords().length }}</v-btn
  >
</template>

<script setup lang="ts">
import { ref, computed, defineModel, inject, watch } from 'vue';
import { WordList } from "~/scripts/wordList";
import { Game } from "~/scripts/game";
import { filterValidWords } from "~/scripts/wordEngine";
const game: Game = inject("GAME")!;

const modelValue = defineModel<boolean>({ default: false });
const selectedWord = ref("");
const words = WordList;
const totalPages = ref(Math.ceil(words.length / 10));
const updatedWords = ref(words);
const currentPage = ref(1);
const pagedWords = computed(() => {
  const start = (currentPage.value - 1) * 10;
  const end = start + 10;
  return (game.guessedLetters.length === 0 ? words : validWords()).slice(
    start,
    end
  );
});

function validWords(): string[] {
  return filterValidWords(game);
}

function addGuess(word: string) {
  game.guess.clear();
  for (let i = 0; i < word.length; i++) {
    game.addLetter(word[i].toUpperCase());
  }
  modelValue.value = false;
  currentPage.value = 1;
}

watch(game.guessedLetters, () => {
  updatedWords.value = validWords();
  totalPages.value = Math.ceil(updatedWords.value.length / 10);
});

const updatePage = () => {
  const index = updatedWords.value.indexOf(selectedWord.value.toLowerCase());
  if (index !== -1) {
    const pageNumber = Math.ceil((index + 1) / 10);
    currentPage.value = pageNumber;
  }
};

const isLightMode = ref(false); // Change to false if dark mode is detected
</script>

<style scoped>
  .bottom-sheet-card-light {
    background-color: #ffffff;
    border-radius: 10px;
    box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
    padding: 20px;
    width: 90%;
    max-width: 500px;
  }

  .bottom-sheet-card-dark {
    background-color: peru;
    border-radius: 10px;
    box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
    padding: 20px;
    width: 90%;
    max-width: 500px;
  }

  .word-button {
    margin: 10px;
    padding: 15px 30px;
    border-radius: 30px;
    cursor: pointer;
    font-weight: bold;
    font-size: 1.2em;
    transition: all 0.3s ease-in-out;
  }

  .word-button:hover {
    transform: translateY(-3px);
    box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
  }

  .word-button:active {
    transform: translateY(1px);
    box-shadow: none;
  }
</style>
