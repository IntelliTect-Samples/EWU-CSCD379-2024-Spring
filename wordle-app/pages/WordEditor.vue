<template>
  <v-container>
    <!-- <search-bar /> -->

    <v-data-table
      :headers="headers"
      :items="words"
      :server-items-length="totalWords"
      :options.sync="options"
      @update:options="fetchWords"
      :loading="isLoading"
    >
      <template #top>
        <v-text-field
          v-model="search"
          label="Search"
          @input="fetchWords"
          clearable
          clear-icon="mdi-close-circle"
        />
      </template>
    </v-data-table>
  </v-container>
</template>

<script setup lang="ts">
import Axios from "axios";

const headers = [
  { title: "Word", key: "text",  sortable: false},
  { title: "Common", key: "isCommon", value: (word: Word) => (word.isCommon ? "✅" : "❌"), sortable: false},
  
];

interface Word {
  isCommon: boolean;
  text: string;
}

const words = ref<Word[]>([]);
const isLoading = ref<boolean>(false);

const totalWords = ref<number>(0);
const search = ref("");
const options = ref({
  page: 1,
  itemsPerPage: 10
});

async function fetchWords() {
  const { page, itemsPerPage} = options.value;
  const params = {
	search: search.value,
    page,
    itemsPerPage,
    
  };

  let response: any;

  
  try {
	isLoading.value = true;
    response = await Axios.get("/WordEditor/GetWords", { params });
  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }

  words.value = response.data.words;
  totalWords.value = response.data.totalCount;

  console.log('Response: ', response.data.words);
  console.log('Words: ', words.value[0]);

}

watch([options, search], fetchWords, { immediate: true });

</script>
