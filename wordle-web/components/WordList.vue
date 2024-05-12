<template>
  <v-bottom-sheet v-model="modelValue">
    <v-card>
      <v-autocomplete
        v-model="selectedWord"
        prepend-inner-icon="mdi-magnify"
        :items="validWords()"
        placeholder="Enter a Word!"
        @update:modelValue="updatePage"
        :disabled="game.gameState !== GameState.Playing"
      />
      <v-btn
        height="40px"
        v-for="word in pagedWords"
        :key="word"
        @click="addGuess(word)"
        flat
        :disabled="game.gameState !== GameState.Playing"
      >
        {{ word.toUpperCase() }}
      </v-btn>
      <v-card-item>
        <v-pagination
          v-if="totalPages > 1"
          density="compact"
          v-model="currentPage"
          :length="totalPages"
        />
      </v-card-item>
      <v-card-actions class="mx-auto">
        <v-btn @click="modelValue = false" color="secondary" variant="flat">
          <v-icon class="mr-2" icon="mdi-close" />
          Close
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-bottom-sheet>
</template>

<script setup lang="ts">
import { WordList } from "~/scripts/wordList";
import { Game, GameState } from "~/scripts/game";
import { filterValidWords } from "~/scripts/wordListUtils";

const game = inject("GAME");

const selectedWord = ref("");
const words = WordList;
const totalPages = ref(Math.ceil(words.length / 10));
const updatedWords = ref(words);
const currentPage = ref(1);

const modelValue = defineModel<boolean>({ default: false });
const emits = defineEmits<{
  (e: "validWordsUpdate", validWoerdsNum: number): number;
}>();

const pagedWords = computed(() => {
  const start = (currentPage.value - 1) * 10;
  const end = start + 10;
  return (game?.guessedLetters.length === 0 ? words : validWords()).slice(
    start,
    end
  );
});

function validWords(): string[] {
  const wordsFilterd = filterValidWords(game!);
  return wordsFilterd;
}

function addGuess(word: string) {
  game?.guess.clear();
  for (let i = 0; i < word.length; i++) {
    game?.addLetter(word[i].toUpperCase());
  }
  modelValue.value = false;
  currentPage.value = 1;
}

watch(pagedWords, () => {
  updatedWords.value = validWords();
  emits("validWordsUpdate", updatedWords.value.length);

  totalPages.value = Math.ceil(updatedWords.value.length / 10);
});

const updatePage = () => {
  const index = updatedWords.value.indexOf(selectedWord.value.toLowerCase());
  if (index !== -1) {
    const pageNumber = Math.ceil((index + 1) / 10);
    currentPage.value = pageNumber;
  }
};

onMounted(() => {
  updatedWords.value = validWords();
  totalPages.value = Math.ceil(updatedWords.value.length / 10);
  emits("validWordsUpdate", updatedWords.value.length);
});
</script>
