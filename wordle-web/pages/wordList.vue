<template>
  <v-card>
    <v-card-title class="text-center">Word List</v-card-title>
    <v-card-item>
      <v-data-table
        :headers="[
          { title: 'Word', key: 'word', value: 'word' },
          { title: 'Is Common', key: 'isCommon', value: 'isCommon' },
          {
            title: 'Mark as Common',
            key: 'markAsCommon',
            value: 'markAsCommon',
            sortable: false,
          },
          { title: 'Delete', key: 'delete', value: 'delete', sortable: false },
        ]"
        :items="wordsList"
        :items-per-page="pageSize"
        :loading="isWordsListLoading"
        :sort-by="[{ key: 'word', order: 'asc' }]"
        :header-props="{ class: 'text-uppercase' }"
        :cell-props="{ class: 'text-uppercase text-button py-3' }"
        :v-model="chosenWord"
      >
        <template v-slot:top>
          <v-row class="mb-1">
            <v-col cols="12" lg="5" md="6" sm="12">
              <v-text-field
                v-model="wordToSearch"
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
            <v-col cols="12" lg="3" md="6" sm="6">
              <v-slider v-model="pageSize" min="10" max="100" step="1">
                <template v-slot:append>
                  <v-select
                    v-model="pageSize"
                    :items="[10, 20, 25, 50, 100]"
                    hide-details
                    density="compact"
                    variant="outlined"
                  />
                </template>
              </v-slider>
            </v-col>
            <v-col cols="auto">
              <v-btn variant="outlined" @click="resetFilters" text="Clear" />
            </v-col>
          </v-row>
        </template>
        <template v-slot:item.isCommon="{ item }">
          {{ item.isCommon ? "Yes" : "No" }}
        </template>
        <template v-slot:item.markAsCommon="{ item }">
          <v-tooltip text="mark the word as a common word">
            <template v-slot:activator="{ props }">
              <v-btn
                :disabled="!signedIn"
                color="primary"
                v-bind="props"
                @click="markAsCommon(item.word, item.isCommon), refreshWords()"
                >Common</v-btn
              >
            </template>
          </v-tooltip>
        </template>
        <template v-slot:item.delete="{ item }">
          <v-tooltip text="delete the word">
            <template v-slot:activator="{ props }">
              <v-btn
                :disabled="!canAddWords"
                color="primary"
                v-bind="props"
                @click="confirmDeleteWord(item.word), refreshWords()"
                >Delete</v-btn
              >
            </template>
          </v-tooltip>
        </template>

        <template v-slot:bottom>
          <v-divider />
          <v-row class="pa-4">
            <v-col cols="12" lg="12">
              <v-pagination
                v-model="pageNumber"
                :length="Math.ceil(totalCount / pageSize)"
                @input="refreshWords"
                variant="outlined"
                density="comfortable"
              />
            </v-col>
          </v-row>
        </template>
      </v-data-table>
      <v-row>
        <v-col>
          <v-text-field
            clearable
            label="Add A Word"
            v-model="wordToAdd"
          ></v-text-field>
        </v-col>
        <v-col>
          <v-tooltip text="Add a word to the word list">
            <template v-slot:activator="{ props }">
              <v-btn
                :disabled="!canAddWords"
                color="primary"
                v-bind="props"
                @click="addWord(), refreshWords()"
                >Add Word</v-btn
              >
            </template>
          </v-tooltip>
        </v-col>
      </v-row>
    </v-card-item>
  </v-card>
  <v-container>
    <ConfirmDeleteWord
      v-model="showConfirmDeleteWord"
      @updated="deleteWord(wordToDelete)"
      @cancel="wordToDelete = ''"
    />

    <SignInDialog v-model="showSignInDialog" />
  </v-container>
</template>
<script setup lang="ts">
import TokenService from "~/scripts/tokenService";
import Axios from "axios";
import type { s } from "vitest/dist/reporters-P7C2ytIv";
interface WordListItems {
  word: string;
  isCommon: boolean;
}

const showSignInDialog = ref(false);
const tokenService = new TokenService();
const wordToAdd = ref("");
const wordToSearch = ref("");
const wordToDelete = ref("");
const wordsList: Ref<WordListItems[]> = ref([]);
const totalCount = ref(0);
const pageNumber = ref(1);
const pageSize = ref(10);
const showConfirmDeleteWord = ref(false);
const isWordsListLoading = ref(false);
provide("wordToDelete", wordToDelete);
const chosenWord = ref<WordListItems>();
const signedIn = computed(() => tokenService.isLoggedIn());
const parseToken = computed(() => tokenService.parseToken());
const canAddWords = computed(() => {
  if (
    parseToken.value[5] == "true" &&
    parseInt(parseToken.value[4]) >= 21 &&
    signedIn.value == true
  ) {
    return true;
  } else {
    return false;
  }
});

onMounted(async () => {
  if (tokenService.isLoggedIn()) {
    showSignInDialog.value = false;
  }
  await refreshWords();
});

watch([wordToSearch, pageNumber, pageSize], async () => {
  await refreshWords();
});

async function refreshWords() {
  console.log("refreshing words");
  wordsList.value = await getWordList(
    wordToSearch.value,
    pageNumber.value,
    pageSize.value
  );
}

function resetFilters() {
  wordToSearch.value = "";
  pageNumber.value = 1;
  pageSize.value = 10;
}

function confirmDeleteWord(word: string) {
  if (!canAddWords.value) {
    return;
  }
  wordToDelete.value = word;
  console.log("word to delete " + wordToDelete.value);
  showConfirmDeleteWord.value = true;
  console.log("show confirm dio" + showConfirmDeleteWord.value);
}

async function getWordList(
  wordToSearch: string = "",
  pageNumber: number = 1,
  pageSize: number = 10
): Promise<WordListItems[]> {
  let items: WordListItems[] = [];
  await Axios.get(
    `word/WordsList?query=${wordToSearch}&page=${pageNumber}&pageSize=${pageSize}`
  )
    .then((res) => res.data)
    .then((data: any) => {
      items = data["items"].map((data: any) => ({
        word: data.word,
        isCommon: data.isCommon,
      }));
      totalCount.value = data["count"];
    })
    .catch((error) => {
      console.log("api get Words error " + error);
    });
  console.log("items " + items);
  return items;
}

async function addWord() {
  //check size of word
  if (wordToAdd.value.length < 5) {
    window.alert("word must be at least 5 characters long");
    return;
  }
  //check to see if it is in the word list already
  var foundWord: WordListItems[] = await getWordList(wordToAdd.value);
  for (var i = 0; i < foundWord.length; i++) {
    if (foundWord[i].word == wordToAdd.value) {
      window.alert("word is already in the list");
      return;
    }
  }
  const headers = { Authorization: `Bearer ${tokenService.getToken()}` };
  console.log("word to add " + wordToAdd.value);
  await Axios.post(
    "/Word/AddWord",
    {
      word: wordToAdd.value,
      isCommon: false,
    },
    { headers }
  ).catch((error) => {
    console.log("api add word error " + error);
  });
  await refreshWords();
}

async function markAsCommon(word: string, isCommon: boolean) {
  const headers = { Authorization: `Bearer ${tokenService.getToken()}` };
  console.log("mark as common " + word + " " + !isCommon);
  await Axios.post(
    "/Word/UpdateWord",
    {
      word: word,
      isCommon: !isCommon,
    },
    { headers }
  )
    .then((response) => {
      console.log(
        "mark as common response " + response.status + " " + response.data
      );
    })
    .catch((error) => {
      console.log("api update word error " + error);
    });
  await refreshWords();
}

async function deleteWord(wordThatsDelete: string) {
  const headers = { Authorization: `Bearer ${tokenService.getToken()}` };
  console.log("delete word " + wordThatsDelete);
  await Axios.delete("/Word/RemoveWord?word=" + wordThatsDelete, { headers })
    .then((response) => {
      console.log("delete word response " + response.status);
    })
    .catch((error) => {
      console.log("api delete word error " + error);
    });
  showConfirmDeleteWord.value = false;
  await refreshWords();
}
</script>
