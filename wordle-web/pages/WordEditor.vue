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
                  showAddEditor = true;
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
        :search="selectedWord?.toString() ?? undefined"
        :v-model="chosenWord"
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
            {{ item.isCommon ? "Common" : "Uncommon" }}
          </div>
        </template>
        <template v-slot:item.actions="{ item }">
          <div class="d-flex flex-row ga-3">
            <v-btn
              color="win"
              @click="
                () => {
                  chosenWord = item;
                  showEditor = true;
                }
              "
            >
              <v-icon icon="mdi-pencil" />
              {{ $vuetify.display.smAndDown ? "" : "Edit" }}</v-btn
            >
            <v-btn
              color="lose"
              @click="
                () => {
                  chosenWord = item;
                  showConfirm = true;
                }
              "
            >
              <v-icon icon="mdi-delete" />
              {{ $vuetify.display.smAndDown ? "" : "Edit" }}</v-btn
            >
          </div>
        </template>
      </v-data-table>
    </v-card>
  </v-container>
  <EditWordDialog
    v-model="showEditor"
    :isAdd="false"
    :word="chosenWord"
    @updated="console.log('updated')"
  />
  <EditWordDialog
    v-model="showAddEditor"
    :isAdd="true"
    @updated="console.log('updated')"
  />

  <ConfirmDialog
    v-model="showConfirm"
    :confirmMessage="`Are you sure you want to delete the word '${chosenWord?.word}'?`"
    confirmTitle="Delete Word From Words List"
    confirmAction="Delete Word"
    @updated="console.log('updated')"
  />
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";
import Axios from "axios";

const wordsList: Ref<WordDto[]> = ref([]);
const isWordsListLoading = ref(true);
const selectedWord = ref<string | null>(null);
const showEditor = ref(false);
const showAddEditor = ref(false);
const isAdd = ref(false);
const showConfirm = ref(false);
const chosenWord = ref<WordDto>();

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
