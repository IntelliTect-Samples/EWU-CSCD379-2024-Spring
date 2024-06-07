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
        <v-text-field v-model="searchQuery" label="Search words" @input="search"></v-text-field>
        <v-checkbox v-model="filterCommon" label="Show only common words"></v-checkbox>

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

async function fetchWordList() {
  try {
    const response = await Axios.get(`/Word/GetWordList?{searchQuery.value}&{currentPage.value}&{itemsPerPage.value}`);
    wordList.value = response.data.words;
    totalPages.value = Math.ceil(response.data.total / itemsPerPage.value);
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
    await fetchWordList();
    newWord.value = '';
    isCommon.value = false;
  } catch (error) {
    console.error('Error adding word:', error);
  }
}

async function deleteWord(word: string) {
  try {
    await Axios.delete(`/Word/DeleteWord?word=${word}`);
    await fetchWordList();
  } catch (error) {
    console.error('Error deleting word:', error);
  }
}

async function nextPage() {
  if (currentPage.value < totalPages.value) {
    currentPage.value++;
    fetchWordList();
  }
}

async function prevPage() {
  if (currentPage.value > 1) {
    currentPage.value--;
    fetchWordList();
  }
}

// Watch for changes in currentPage and fetch word list
watch(currentPage, () => {
  fetchWordList();
});

// Watch for changes in searchQuery and fetch word list
watch(searchQuery, () => {
  currentPage.value = 1; // Reset to the first page when searching
  fetchWordList();
});

// Define the search method to update the searchQuery
function search(event) {
  searchQuery.value = event.target.value;
}

onMounted(async () => {
  fetchWordList();
});
</script>

