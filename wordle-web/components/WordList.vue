<template>
  <v-pagination v-model="currentPage" :length="totalPages" />
  <div>{{ currentPage }}</div>
  <ul>
    <li v-for="word in pagedWord" :key="word">{{ word }}</li>
  </ul>
</template>

<script setup lang="ts">
import { WordList } from "~/scripts/wordList";
const words = WordList;
const wordsPerPage = WordList.length / 10;
const totalPages = 10;
const currentPage = ref(1);
const pagedWord = computed(() => {
  const start = (currentPage.value - 1) * wordsPerPage;
  const end = start + wordsPerPage;
  return words.slice(start, end);
});
</script>
