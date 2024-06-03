<template>
  <SignInDialog v-model="showSignInDialog" />
  <v-card>
    <v-card-title class="text-center">Word List</v-card-title>

    <v-tooltip text="Sign in to access more features">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" color ="primary" @click="showSignInDialog = true">Sign In</v-btn>
      </template>
    </v-tooltip>

    <v-table>
      <v-table>
            <thead>
                <tr>
                    <th>Word</th>
                    <th>Is It A Common Word</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="word in wordList" :key="word.word">
                    <td v-if="word.word">{{ word.word }}</td> <td v-else>No Data</td>
                    <td v-if="word.isCommon">{{ word.isCommon? "yes": "no" }}</td> <td v-else>No Data</td>
                    
                </tr>
            </tbody>
        </v-table>
    </v-table>

    <v-text-field clearable label ="Search" v-model ="wordToSearch" ></v-text-field>
    <v-tooltip text="mark the word as a common word">
      <template v-slot:activator="{ props }">
        <v-btn :disabled="!signedIn" color ="primary"v-bind="props">Common</v-btn>
      </template>
    </v-tooltip>

    <div class="d-flex">
      <v-text-field clearable label ="Add A Word" v-model = wordToAdd @click =" addWord()"></v-text-field>
      <v-tooltip text="Add a word to the word list">
        <template v-slot:activator="{ props }">
          <v-btn :disabled="!canAddWords" color ="primary" v-bind="props" @click ="console.log('word to add ' + wordToAdd)">Add Word</v-btn>
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
const wordList = ref<WordListItem[]>();
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

interface WordListItem {
  word: string;
  isCommon: boolean;
}
onMounted(() => {
  if (tokenService.isLoggedIn()) {
    showSignInDialog.value = false;
  }
  getWordList();
});
function addWord() {
  console.log("word to add " + wordToAdd.value);
  Axios.post("/Word/AddWord", {
    word: wordToAdd.value,
    isCommon: false,
  });
}
async function getWordList() {
  let wordUrl = "Word/WordsList";
  console.log("get wordlist from api " + wordUrl + "?page=" + pageNumber.value + "&pageSize=" + pageSize.value);
  await Axios.get(wordUrl + "?page=" + pageNumber.value + "&pageSize=" + pageSize.value)
    .then((response) => {
      wordList.value = response.data;
      console.log("api get words response " + response.status);
    })
    .catch((error) => {
      console.log("api get Words error " + error);
    });
}
</script>
