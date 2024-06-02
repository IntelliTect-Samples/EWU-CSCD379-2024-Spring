<template>
  <v-container>
    <v-card class="text-center">
      <v-card-title>Word Editor</v-card-title>
      <v-card-text>
        <v-form @submit.prevent="addWord">
          <v-text-field
            v-model="newWord"
            label="Add a new word"
            required
          ></v-text-field>
          <v-checkbox
            v-model="isCommon"
            label="Common word"
          ></v-checkbox>
          <v-btn type="submit" color="primary">Add Word</v-btn>
        </v-form>
        <v-divider class="my-5"></v-divider>
        <v-text-field
          v-model="searchQuery"
          label="Search words"
        ></v-text-field>
        <v-checkbox
          v-model="filterCommon"
          label="Show only common words"
        ></v-checkbox>
        <v-list>
          <v-list-item
            v-for="(word, index) in paginatedWords"
            :key="index"
          >
            <v-list-item-content>{{ word.text }}</v-list-item-content>
            <v-list-item-action>
              <v-icon @click="deleteWord(word.text)" color="red">
                mdi-delete
              </v-icon>
            </v-list-item-action>
          </v-list-item>
        </v-list>
        <v-pagination
          v-if="totalPages > 1"
          v-model="currentPage"
          :length="totalPages"
          @input="paginateWords"
        ></v-pagination>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script setup lang='ts'>
import { ref, computed, onMounted } from 'vue';
import { WordList } from '../scripts/wordList'; // Adjust the import path as necessary

// Initial list of words
const initialWords = WordList.map(word => ({ text: word, isCommon: false }));

// Reactive variables
const words = ref(initialWords);
const newWord = ref('');
const isCommon = ref(false);
const filterCommon = ref(false);
const searchQuery = ref('');
const currentPage = ref(1);
const itemsPerPage = ref(10);

// Computed properties
const filteredWords = computed(() => {
  let filtered = words.value;
  if (filterCommon.value) {
    filtered = filtered.filter(word => word.isCommon);
  }
  if (searchQuery.value) {
    filtered = filtered.filter(word => word.text.startsWith(searchQuery.value));
  }
  return filtered;
});

const totalPages = computed(() => Math.ceil(filteredWords.value.length / itemsPerPage.value));

const paginatedWords = computed(() => {
  const startIndex = (currentPage.value - 1) * itemsPerPage.value;
  const endIndex = currentPage.value * itemsPerPage.value;
  return filteredWords.value.slice(startIndex, endIndex);
});

// Methods
const paginateWords = () => {
  currentPage.value = Math.min(currentPage.value, totalPages.value);
};

const addWord = () => {
  if (newWord.value && !words.value.some(word => word.text === newWord.value)) {
    words.value.push({ text: newWord.value, isCommon: isCommon.value });
    words.value.sort((a, b) => a.text.localeCompare(b.text));
    newWord.value = '';
    isCommon.value = false;
    paginateWords();
  }
};

const deleteWord = (wordText) => {
  words.value = words.value.filter(word => word.text !== wordText);
  paginateWords();
};
//workflow test
// Lifecycle hooks
onMounted(() => {
  paginateWords();
});
</script>

<style scoped>
.v-container {
  max-width: 600px;
  margin: 0 auto;
}
.v-card {
  padding: 20px;
}
</style>

