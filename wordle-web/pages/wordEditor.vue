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
import axios from "axios";
import TokenScript from "~/scripts/tokenScript";

export interface WordsDto {
  text: string;
  common: boolean;
}


// Initial list of words
//const initialWords = WordList.map(word => ({ text: word, isCommon: false }));
const wordList: ref<WordsDto[]> = ref([]);

// Reactive variables
const words = ref(initialWords);
const newWord = ref('');
const isCommon = ref(false);
const filterCommon = ref(false);
const searchQuery = ref('');
const currentPage = ref(1);
const itemsPerPage = ref(10);

const totalPages = ref(0);

const tokenService = new TokenScript();

const canAddAndDelete = computed(
  () => tokenService.isLoggedIn() && tokenService.deleteAndAdd()
);

const loggedIn = computed(
  () => tokenService.isLoggedIn()
);


async function getWordList(
  query: string = "",
  currentPage: number = 1,
  pageSize: number = 10,
): Promise<WordsDto[]>{
  let words: WordsDto[] = [];
  return Axios.get('')
    .then((res) => res.data)
    .then((data: any) => {
      items = data["words"].map((data: any) => ({
        text: data.text,
        common: data.commonWord
      }));
    totalPages.value = data["total"]
    });
}

onMounted(async () => {
  wordList.value = await getWordList();
})



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

