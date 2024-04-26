<template>
  <v-bottom-sheet
    v-model="modelValue"
    max-height="600"
    class="pa-2 d-flex flex-wrap justify-center align-center"
  >
    <v-card>
      <v-autocomplete
        v-model="selectedWord"
        prepend-inner-icon="mdi-magnify"
        :items="validWords()"
        placeholder="Enter a Word!"
        @update:modelValue="updatePage"
      >
      </v-autocomplete>
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
        />
      </v-card-item>
      <v-btn class="ml-2" icon @click="modelValue = false" style="width: auto;">
      <v-icon class="align-end" color = "primary">mdi-close</v-icon>
      <v-btn-text color="primary">Close</v-btn-text>
    </v-btn>
    </v-card>
  </v-bottom-sheet>
  <v-btn
    position="fixed"
    location="bottom right"
    class="mr-3 mb-3"
    size="default"
    color="primary"
    elevation="8"
    rounded
    @click="modelValue = true"
    >Word List: {{ validWords().length }}</v-btn
  >
</template>

<script setup lang="ts">
import { WordList } from "~/scripts/wordList";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";
import { filterValidWords } from "~/scripts/wordListUtils";
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
</script>
