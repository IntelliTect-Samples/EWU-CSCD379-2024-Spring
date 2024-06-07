<template>
  <v-container>
    <v-card class="text-center">
      <v-card-title>Word Editor</v-card-title>
      <v-card-text>
        <!-- Add word form -->
        <v-form @submit.prevent="addWord">
          <v-text-field v-model="newWord" label="Add a new word" required></v-text-field>
          <v-checkbox v-model="isCommon" label="Common word" v-if="canAddAndDelete"></v-checkbox>
          <v-btn type="submit" color="primary">Add Word</v-btn>
        </v-form>

        <v-divider class="my-5"></v-divider>

        <!-- Search input and filter -->
        <v-text-field v-model="searchQuery" label="Search words" @input="updateWordList"></v-text-field>
        <v-checkbox v-model="filterCommon" label="Show only common words" @change="updateWordList"></v-checkbox>

        <!-- Word list -->
        <v-list>
          <v-list-item v-for="word in wordList" :key="word.text">
            <v-list-item-content>
              <v-list-item-title>{{ word.text }}</v-list-item-title>
              <v-list-item-subtitle>{{ word.common ? 'Common' : 'Uncommon' }}</v-list-item-subtitle>
            </v-list-item-content>
            <v-list-item-action v-if="canAddAndDelete">
              <v-btn icon @click="deleteWord(word.text)">
                <v-icon>mdi-delete</v-icon>
              </v-btn>
            </v-list-item-action>
          </v-list-item>
        </v-list>

        <!-- Pagination -->
        <v-pagination v-model="currentPage" :length="totalPages" @next="nextPage" @prev="prevPage"></v-pagination>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted, watch } from 'vue';
import Axios from 'axios';
import TokenScript from '~/scripts/tokenScript';
import type { WordsDto } from '~/Models/WordsDto';

const wordList = ref<WordsDto[]>([]);
const newWord = ref('');
const isCommon = ref(false);
const filterCommon = ref(false);
const searchQuery = ref('');
const currentPage = ref(1);
const itemsPerPage = ref(10);
const totalPages = ref(0);
const tokenService = new TokenScript();

const canAddAndDelete = () => tokenService.isLoggedIn() && tokenService.deleteAndAdd();

async function fetchWordList(query: string, pageNum: number, itemsPer: number, filterCommon: boolean) {
  try {
    const response = await Axios.get(`/Word/GetWordList?searchQuery=${query}&pageNum=${pageNum}&itemsPer=${itemsPer}&filterCommon=${filterCommon}`);
    wordList.value = response.data.words;
    totalPages.value = Math.ceil(response.data.total / itemsPer);
  } catch (error) {
    console.error('Error fetching word list:', error);
    wordList.value = [];
    totalPages.value = 0;
  }
}

async function addWord() {
  if (!newWord.value) return;
  try {
    await Axios.post('/Word/AddWord', { text: newWord.value, commonWord: isCommon.value });
    await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
    newWord.value = '';
    isCommon.value = false;
  } catch (error) {
    console.error('Error adding word:', error);
  }
}

async function deleteWord(word: string) {
  try {
    await Axios.delete(`/Word/DeleteWord?word=${word}`);
    await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
  } catch (error) {
    console.error('Error deleting word:', error);
  }
}

async function nextPage() {
  if (currentPage.value < totalPages.value) {
    currentPage.value++;
    await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
  }
}

async function prevPage() {
  if (currentPage.value > 1) {
    currentPage.value--;
    await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
  }
}

async function updateWordList() {
  await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
}


// Watch for changes in currentPage and fetch word list
watch(currentPage, async () => {
  await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
});
// Watch for changes in searchQuery and fetch word list
watch(searchQuery, async () => {
  currentPage.value = 1; // Reset to the first page when searching
  console.log("Search watch", searchQuery)
  await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
  console.log("Search watch", searchQuery)
});

// Watch for changes in filterCommon and fetch word list
watch(filterCommon, async () => {
  currentPage.value = 1; // Reset to the first page when filter changes
  await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
});

// Fetch initial word list on component mount
onMounted(async () => {
  await fetchWordList(searchQuery.value, currentPage.value, itemsPerPage.value, filterCommon.value);
});
</script>
