<template>
  <v-container>
    <v-card class="pa-3">
      <v-card-title class="font-weight-bold">Word Editor</v-card-title>
      <v-card-item>
        <v-row>
          <v-col cols="auto">
            <v-btn
              color="play"
              @click="
                () => {
                  showEditor = true;
                  isAdd = true;
                }
              "
            >
              <v-icon>mdi-plus</v-icon>
              Add Word</v-btn
            >
          </v-col>
          <v-col cols="auto">
            <v-row>
              <v-checkbox
                v-for="(item, index) in items"
                :key="index"
                :label="item.label"
                :value="item.value"
                v-model="isCommon"
                direction="horizontal"
                compact
                color="play"
              />
            </v-row>
          </v-col>
        </v-row>
      </v-card-item>

      <v-data-table
        :headers="[
          { title: 'Word', key: 'word', value: 'word' },
          { title: 'Word Type', key: 'isCommon', value: 'isCommon' },
          { title: 'Actions', key: 'actions', value: 'actions' },
        ]"
        :items="wordsList"
        :loading="isWordsListLoading"
        :itemsLength="wordsList.length"
        :sort-by="[{ key: 'word', order: 'asc' }]"
        items-per-page="10"
        :header-props="{ class: 'text-uppercase' }"
        :cell-props="{ class: 'text-uppercase text-button pa-3' }"
        show-select
        :search="selectedWord?.toString() ?? undefined"
      >
        <template v-slot:top>
          <v-text-field
            v-model="selectedWord"
            :items="wordsList.map((word) => word.word)"
            item-text="word"
            item-value="word"
            label="Search for a word"
            hide-no-data
            hide-details
            dense
            clearable
            single-line
          />
        </template>
        <template v-slot:item.isCommon="{ item }">
          <div class="d-flex flex-row ga-3">
            <v-icon :icon="item.isCommon ? 'mdi-check' : 'mdi-close'" />
          </div>
        </template>
        <template v-slot:item.actions="{ item }">
          <div class="d-flex flex-row ga-3">
            <v-btn
              color="win"
              @click="
                () => {
                  isAdd = false;
                  showEditor = true;
                }
              "
            >
              <v-icon>mdi-pencil</v-icon>
              Edit</v-btn
            >
            <v-btn color="lose">
              <v-icon>mdi-delete</v-icon>
              Delete</v-btn
            >
          </div>
        </template>
      </v-data-table>
    </v-card>
  </v-container>
  <EditWordDialog v-model="showEditor" :isAdd="isAdd" />
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";
import Axios from "axios";

const wordsList: Ref<WordDto[]> = ref([]);
const isWordsListLoading = ref(true);
const selectedWord = ref<string | null>(null);
const showEditor = ref(false);
const isAdd = ref(false);

useHead({
  title: "Word Editor",
  meta: [{ name: "description", content: "Cool site!" }],
});

const items = [
  { label: "Common", value: "common" },
  { label: "Uncommon", value: "uncommon" },
];

const isCommon = ref<string | null>(null);
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
