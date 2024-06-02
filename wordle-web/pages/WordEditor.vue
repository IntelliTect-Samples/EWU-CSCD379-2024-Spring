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
        </v-row>
      </v-card-item>

      <v-data-table
        :headers="[
          { title: 'Word', key: 'word', value: 'word' },
          { title: 'Word Type', key: 'isCommon', value: 'isCommon' },
          {
            title: 'Actions',
            key: 'actions',
            value: 'actions',
            sortable: false,
          },
        ]"
        :items="wordsList"
        v-model:items-per-page="pageSize"
        :loading="isWordsListLoading"
        :sort-by="[{ key: 'word', order: 'asc' }]"
        :header-props="{ class: 'text-uppercase' }"
        :cell-props="{ class: 'text-uppercase text-button pa-3' }"
        :v-model="chosenWord"
        @update:options="getWords(query, pageNumber, pageSize)"
      >
        <template v-slot:top>
          <v-row height="100">
            <v-col cols="2">
              <v-text-field
                v-model="query"
                item-text="word"
                item-value="word"
                label="Search for a word"
                hide-details
                clearable
                single-line
                variant="outlined"
                density="compact"
              />
            </v-col>
            <v-col cols="5">
              <v-slider v-model="pageSize" min="10" max="100" step="1">
                <template v-slot:append>
                  <v-text-field
                    v-model="pageSize"
                    density="compact"
                    style="width: 80px"
                    type="number"
                    variant="outlined"
                    hide-details
                /></template>
              </v-slider>
            </v-col>
            <v-col cols="5" class="">
              <v-btn
                width="170"
                height=""
                variant="outlined"
                @click="pageNumber--"
                ><v-icon icon="mdi-chevron-left" />Previous Page</v-btn
              >
              <v-btn width="170" variant="outlined" @click="pageNumber++"
                >Next Page <v-icon icon="mdi-chevron-right"
              /></v-btn>
            </v-col>
          </v-row>
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
              {{ $vuetify.display.smAndDown ? "" : "Delete" }}</v-btn
            >
          </div>
        </template>
        <template v-slot:bottom>
          <v-divider />
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
    confirmTitle="Delete Word From Words List?"
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
const showConfirm = ref(false);
const chosenWord = ref<WordDto>();
const isCommon = ref<string | null>(null);

const pageNumber = ref(1);
const pageSize = ref(10);
const query = ref("");
useHead({
  title: "Word Editor",
  meta: [{ name: "description", content: "Cool site!" }],
});

const items = [
  { label: "Common", value: "common" },
  { label: "Uncommon", value: "uncommon" },
];

watch([query, pageSize], async () => {
  pageNumber.value = 1;
  wordsList.value = await getWords(
    query.value,
    pageNumber.value,
    pageSize.value
  );
});

watch([pageNumber], async () => {
  wordsList.value = await getWords(
    query.value,
    pageNumber.value,
    pageSize.value
  );
});

async function getWords(
  query: string,
  pageNumber: number,
  pageSize: number
): Promise<WordDto[]> {
  return Axios.get(
    `word/WordsList?query=${query}&page=${pageNumber}&pageSize=${pageSize}`
  )
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
}

onMounted(async () => {
  wordsList.value = await getWords("", 1, 10);
});
</script>
