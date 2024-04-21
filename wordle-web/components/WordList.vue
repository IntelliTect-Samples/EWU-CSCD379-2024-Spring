<template>
  <v-dialog v-model="modelValue" max-width="800" max-height="800" class="pa-2">
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
        height="60px"
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
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { WordList } from "~/scripts/wordList";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";
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
