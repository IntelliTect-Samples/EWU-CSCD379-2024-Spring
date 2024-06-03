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
    <v-table>
      <thead>
        <tr>
          <th>Word</th>
          <th>Is It A Common Word</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="words in wordList" :key = words.word>
          <td v-if="words.word">{{ words.word }}</td>
          <td v-else>No Data</td>
          <td v-if="words.isCommon">{{ words.isCommon? "Yes" : "no"}}</td>
          <td v-else>No Data</td>
        </tr>
      </tbody>
    </v-table>
    <!---->
    <v-text-field
      clearable
      label="Search"
      v-model="wordToSearch"
    ></v-text-field>
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
        @click="addWord()"
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
import { Word } from "~/scripts/word";
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
function addWord() {
  console.log("word to add " + wordToAdd.value);
  Axios.post("/Word/AddWord", {
    word: wordToAdd.value,
    isCommon: false,
  });
}
async function getWordList() {
  let items: WordListItems[] = [];
  await Axios.get(
    `word/WordsList?query=${wordToSearch.value}&page=${pageNumber.value}&pageSize=${pageSize.value}`
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
</script>
