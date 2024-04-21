<template>
  <v-pagination v-model="currentPage" :length="totalPages" />
  {{ game.guessedLetters }}

  <ul>
    <li v-for="word in updatedWords" :key="word">{{ word }}</li>
  </ul>
</template>

<script setup lang="ts">
import { WordList } from "~/scripts/wordList";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";
const game: Game = inject("GAME")!;

const words = WordList;
const wordsPerPage = WordList.length / 10;
const totalPages = 10;
const updatedWords = ref(words);
const currentPage = ref(1);
const pagedWords = computed(() => {
  const start = (currentPage.value - 1) * wordsPerPage;
  const end = start + wordsPerPage;
  return (game.guessedLetters.length === 0 ? words : validWords()).slice(
    start,
    end
  );
});

function validWords(): string[] {
  return words.filter((word) => {
    for (let i = 0; i < game.guessedLetters.length; i++) {
      if (
        word.includes(game.guessedLetters[i].char.toLowerCase()) &&
        game.guessedLetters[i].state === LetterState.Wrong
      ) {
        return false;
      }
    }
    return true;
  });
}

watch(game.guessedLetters, () => {
  updatedWords.value = validWords();
});
</script>
