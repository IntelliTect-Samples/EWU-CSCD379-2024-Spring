<template>
  <v-data-table-server
    :headers="[
      { title: 'Word', key: 'word', value: 'word' },
      { title: ' is Common', key: 'isCommon', value: 'isCommon' },
      { title: 'Actions', key: 'actions', value: 'actions' },
    ]"
    :items="wordsList"
    :loading="isWordsListLoading"
    :itemsLength="wordsList.length"
    :sort-by="[{ key: 'word', order: 'asc' }]"
    items-per-page="10"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Word Editor</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
      </v-toolbar>
      <v-autocomplete
        v-model="selectedWord"
        :items="wordsList.map((word) => word.word)"
        item-text="word"
        item-value="word"
        label="Search for a word"
        hide-no-data
        hide-details
        dense
        clearable
      />
    </template>
    <template v-slot:item.actions="{ item }"
      ><v-btn>Common</v-btn><v-btn>Delete</v-btn>
    </template>
  </v-data-table-server>
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";
import Axios from "axios";

const wordsList: Ref<WordDto[]> = ref([]);
const isWordsListLoading = ref(true);
const selectedWord = ref<string | null>(null);

onMounted(async () => {
  wordsList.value = await Axios.get("word/wordsList")
    .then((res: { data: any }) => res.data)
    .then((data: any) =>
      data.map((data: any) => ({
        word: data.word,
        isCommon: data.isCommonWord,
      }))
    )
    .then((words: WordDto[]) => {
      isWordsListLoading.value = false;
      return words;
    });
});
</script>
