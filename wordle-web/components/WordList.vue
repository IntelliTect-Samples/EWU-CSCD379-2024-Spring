<template>
  <v-dialog v-model="modelValue" max-width="800" max-height="800" class="pa-2">
    <v-card>
      <v-btn
        height="60px"
        width="200px"
        class="align-center d-flex justify-center"
        @click="console.log('hi')"
        v-for="word in pagedWords"
        :key="word"
      >
        {{ word.toUpperCase() }}
      </v-btn>
      <v-pagination
        density="compact"
        v-model="currentPage"
        :length="totalPages"
      />
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { WordList } from "~/scripts/wordList";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";
const game: Game = inject("GAME")!;

const modelValue = defineModel<boolean>({ default: false });

const words = WordList;
const totalPages = ref(words.length / 10);
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
  return words.filter((word) => {
    for (let i = 0; i < game.guessedLetters.length; i++) {
      const letterObj = game.guessedLetters[i];
      const letterChar = letterObj.char.toLowerCase();

      const indexOfLetterInWord = word.indexOf(letterChar);
      const indexOfLetterInSecretWord = game.secretWord
        .toLowerCase()
        .indexOf(letterChar);
      if (
        word.includes(letterChar) &&
        game.guessedLetters[i].state === LetterState.Wrong
      ) {
        return false;
      }
      if (
        !word.includes(letterChar) &&
        (letterObj.state === LetterState.Correct ||
          letterObj.state === LetterState.Misplaced)
      ) {
        return false;
      }
      if (
        word.includes(letterChar) &&
        (letterObj.state === LetterState.Correct ||
          letterObj.state === LetterState.Misplaced) &&
        indexOfLetterInWord !== indexOfLetterInSecretWord
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

watch(updatedWords, () => {
  totalPages.value = Math.ceil(updatedWords.value.length / 20);
});
</script>
