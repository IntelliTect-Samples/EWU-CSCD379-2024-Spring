<template>
  <SignInDialog v-model="showSignInDialog" />
  <v-card>
    <v-card-title class="text-center">Word List</v-card-title>

    <v-tooltip text="Sign in to access more features">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" color="primary" @click="showSignInDialog = true"
          >Sign In</v-btn
        >
      </template>
    </v-tooltip>
    <!---->
    <v-row>
      <v-col>
        <v-text-field
          clearable
          label="Search"
          v-model="wordToSearch"
        ></v-text-field>
      </v-col>
      <v-col>
        <v-slider v-model="pageSize" min="10" max="100" step="1" />
      </v-col>
      <v-col>
        <v-select
          v-model="pageSize"
          :items="[10, 20, 30, 40, 50, 60, 70, 80, 90, 100]"
        />
      </v-col>
      <v-col>
        <v-btn color="primary" @click="resetFilters()">Reset</v-btn>
      </v-col>
    </v-row>

    <!---->

    <v-table>
      <thead>
        <tr>
          <th>Word</th>
          <th>Is It A Common Word</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="words in wordList" :key="words.word">
          <td v-if="words.word">{{ words.word }}</td>
          <td v-else>No Data</td>
          <td v-if="words.isCommon">{{ words.isCommon ? "Yes" : "no" }}</td>
          <td v-else>No Data</td>
        </tr>
      </tbody>
    </v-table>
    <v-pagination
      v-model="pageNumber"
      :length="Math.ceil(totalCount / pageSize)"
      @input="refreshWords"
      variant="outlined"
    />
    <!---->
    <v-tooltip text="mark the word as a common word">
      <template v-slot:activator="{ props }">
        <v-btn :disabled="!signedIn" color="primary" v-bind="props"
          >Common</v-btn
        >
      </template>
    </v-tooltip>
    <!---->
    <div class="d-flex">
      <v-text-field
        clearable
        label="Add A Word"
        v-model="wordToAdd"
      ></v-text-field>
      <v-tooltip text="Add a word to the word list">
        <template v-slot:activator="{ props }">
          <v-btn
            :disabled="!canAddWords"
            color="primary"
            v-bind="props"
            @click="console.log('word to add ' + wordToAdd)"
            >Add Word</v-btn
          >
        </template>
      </v-tooltip>
    </div>
  </v-card>
</template>
<script setup lang="ts">
import TokenService from "~/scripts/tokenService";
import Axios from "axios";
const showSignInDialog = ref(false);
const tokenService = new TokenService();
const wordToAdd = ref("");
const wordToSearch = ref("");
const wordListApi = ref<WordListApi[]>();
const wordList = ref<WordListItems[]>();
const totalCount = ref(0);
const pageNumber = ref(1);
const pageSize = ref(10);
const signedIn = computed(() => tokenService.isLoggedIn());
const parseToken = computed(() => tokenService.parseToken());
const canAddWords = computed(() => {
  if (parseToken.value[5] == "true" && parseInt(parseToken.value[4]) >= 21) {
    return true;
  } else {
    return false;
  }
});
interface WordListApi {
  count: number;
  items: WordListItems[];
}
interface WordListItems {
  word: string;
  isCommon: boolean;
}
onMounted(async () => {
  if (tokenService.isLoggedIn()) {
    showSignInDialog.value = false;
  }
  wordList.value = await getWordList();
});
watch([wordToSearch, pageNumber, pageSize], () => {
  refreshWords();
});
function addWord() {
  console.log("word to add " + wordToAdd.value);
  Axios.post("/Word/AddWord", {
    word: wordToAdd.value,
    isCommon: false,
  });
}
async function getWordList(
  wordToSearch: string = "",
  pageNumber: number = 1,
  pageSize: number = 10
): Promise<WordListItems[]> {
  //console.log("get word list");
  let items: WordListItems[] = [];
  await Axios.get(
    `word/WordsList?query=${wordToSearch}&page=${pageNumber}&pageSize=${pageSize}`
  )
    .then((res) => res.data)
    .then((data: any) => {
      items = data["items"].map((data: any) => ({
        word: data.word,
        isCommon: data.isCommonWord,
      }));
      totalCount.value = data["count"];
    })
    .catch((error) => {
      console.log("api get Words error " + error);
    });
  return items;
}
async function refreshWords() {
  //console.log("refresh words");
  wordList.value = await getWordList(
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
</script>
