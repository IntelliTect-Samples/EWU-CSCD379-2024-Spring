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
  { text: "Word", value: "text" },
  { text: "Common", value: "isCommon" },
  { text: "Position", value: "position" },
];

interface Word {
  text: string;
  isCommon: boolean;
}

const words = ref([]);
const isLoading = ref<boolean>(false);

const totalWords = ref(0);
const search = ref("");
const options = ref({
  page: 1,
  itemsPerPage: 10,
  sortBy: ["text"],
  sortDesc: [false],
});

async function fetchWords() {
  const { page, itemsPerPage, sortBy, sortDesc } = options.value;
  const params = {
    page,
    itemsPerPage,
    search: search.value,
    sortBy: sortBy[0] || "",
    sortDesc: sortDesc[0] || false,
  };

  // const response = await Axios.get('/WordEditor/GetWords', { params });

  let response: any;

  
  try {
	isLoading.value = true;
    response = await Axios.get("/WordEditor/GetWords", { params });
    words.value = response.data.words;
	totalWords.value = response.data.total;
    console.log(words.value)
  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }

  words.value = response.data.words;
  totalWords.value = response.data.total;

  console.log("Words: " + words.value[0]);
  console.log(totalWords.value);

}

watch([options, search], fetchWords, { immediate: true });

// async function tryFetch() {
//   isLoading.value = true;
//   try {
//     const response = await Axios.get("/WordEditor/GetWords");
//     words.value = response.data;
//     console.log(words.value[0].text);
//   } catch (error) {
//     console.error(error);
//   } finally {
//     isLoading.value = false;
//   }
// }
</script>
