<template>
  <v-container style="max-width: 800px">
    <v-toolbar flat class="mb-3">
      <v-toolbar-title>Word Editor</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-switch
        label="Display common words only"
        color="secondary"
        @change="fetchWords"
        class="d-flex justify-center"
		v-model="isCommonFilter"
      />
      <v-btn
        color="primary"
        prepend-icon="mdi-plus-box"
        variant="flat"
        class="ml-5"
        @click="showDialog = true"
        >Add Word
      </v-btn>
    </v-toolbar>

    <v-data-table-server
      v-model:items-per-page="options.itemsPerPage"
      :headers="headers"
      :items="words"
      :items-length="totalWords"
      :options.sync="options"
      @update:options="fetchWords"
      @update:page="pageNumber"
      @update:items-per-page="itemsPerPage"
      :loading="isLoading"
      :items-per-page-options="[10, 25, 50, 100]"
      hover
      density="compact"
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

      <!-- Template for Word text -->
      <template #item.text="{ item }">
        <p class="font-weight-bold">
          {{ item.text.charAt(0).toUpperCase() + item.text.slice(1) }}
        </p>
      </template>

      <template #item.actions="{ item }">
        <v-btn @click="deleteItem(item)" color="red">Delete</v-btn>
      </template>

      <!-- Template for switch to change isCommon -->
      <template #item.isCommon="{ item }">
        <v-switch
          class="d-flex justify-center"
          v-model="item.isCommon"
          color="green"
          inset
          @change="updateItem(item)"
        />
      </template>
    </v-data-table-server>

    <AddWordDialog @save="saveWord" v-model:show="showDialog" />
  </v-container>
</template>

<script setup lang="ts">
import Axios from "axios";

// Add Word Dialog setup and functions
const showDialog = ref<boolean>(false);

async function saveWord(word: string) {
  console.log(word);
  showDialog.value = false;

  try {
    const response = await Axios.post("/WordEditor/AddWord?word=" + word);

    if (response.status === 200) {
      await fetchWords();
    }

  } catch (error) {
    console.error(error);
  }
}

// Data table setup and functions

// Headers for the data table
const headers = [
  {
    key: "text",
    text: "Word",
    title: "Word",
    sortable: false,
    align: "center",
  },
  {
    key: "isCommon",
    text: "Common",
    title: "Common",
    sortable: false,
    align: "center",
  },
  {
    key: "actions",
    text: "Actions",
    title: "Actions",
    sortable: false,
    align: "center",
  },
];

interface Word {
  isCommon: boolean;
  text: string;
}

const words = ref<Word[]>([]);
const isLoading = ref<boolean>(false);
const isCommonFilter = ref<boolean>(false);

const totalWords = ref<number>(0);
const search = ref("");
const options = ref({
  page: 1,
  itemsPerPage: 10,
});

const pageNumber = (page: number) => {
  options.value.page = page;
};

const itemsPerPage = (itemsPerPage: number) => {
  options.value.itemsPerPage = itemsPerPage;
};

// Fetch words from the server based on the search query and pagination options
async function fetchWords() {
  const { page, itemsPerPage } = options.value;
  const params = {
    search: search.value,
    page,
    itemsPerPage,
	isCommonFilter: isCommonFilter.value,
  };

  try {
    isLoading.value = true;
    const response = await Axios.get("/WordEditor/GetWords", { params });

    words.value = response.data.words;
    totalWords.value = response.data.totalCount;

  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }
}

async function updateItem(item: Word) {
  try {
    isLoading.value = true;
    const response = await Axios.post(
      "WordEditor/SetIsCommon?word=" + item.text + "&isCommon=" + item.isCommon
    );

    if (response.status === 200) {
      await fetchWords();
    }
  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }
}

async function deleteItem(item: Word) {
  try {
    isLoading.value = true;
    const response = await Axios.post(
      "/WordEditor/DeleteWord?word=" + item.text
    );

    if (response.status === 200) {
      await fetchWords();
    }
  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }
}

// watch([options, search], fetchWords, { immediate: true });
watch([options, search, isCommonFilter], fetchWords, { immediate: true });
</script>
