<template>
  <v-data-table
    :headers="[
      { key: 'word', value: 'word' },
      { key: 'isCommon', value: 'isCommon' },
      { key: 'actions', value: 'actions' },
    ]"
    :items="wordsList"
    :sort-by="[{ key: 'word', order: 'asc' }]"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>My CRUD</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
      </v-toolbar>
    </template>
    <template v-slot:item.actions="{ item }"
      ><v-btn>Common</v-btn><v-btn>Delete</v-btn>
    </template>
  </v-data-table>
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";
import Axios from "axios";

const wordsList: Ref<WordDto[]> = ref([]);
const isWordsListLoading = ref(true);

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
