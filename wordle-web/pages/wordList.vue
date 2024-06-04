<template>
  <SignInDialog v-model="showSignInDialog" />
  <v-card>
    <v-card-title class="text-center">Word List</v-card-title>
    <ConfirmDeleteWord
      v-model="showConfirmDeleteWord"
      @updated="deleteWord(wordToDelete)"
      @cancel="wordToDelete = ''"
    />
    <v-tooltip text="Sign in to access more features">
      <template v-slot:activator="{ props }">
        <v-btn
          v-bind="props"
          color="primary"
          @click="showSignInDialog = true"
          >{{ signedIn ? userNameGlobal : "Sign In" }}</v-btn
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
        <v-tooltip text="Reset the filters">
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props" color="primary" @click="resetFilters()"
              >Reset</v-btn
            >
          </template>
        </v-tooltip>
      </v-col>
    </v-row>

    <!---->

    <v-table>
      <thead>
        <tr>
          <th>Word</th>
          <th>Is It A Common Word</th>
          <th>mark as common</th>
          <th>delete</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="words in wordList" :key="words.word">
          <td v-if="words.word">{{ words.word }}</td>
          <td v-else>No Data</td>
          <td v-if="words.isCommon != null">{{ words.isCommon ? "Yes" : "no" }}</td>
          <td v-else>No Data</td>
          <td>
            <v-tooltip text="mark the word as a common word">
              <template v-slot:activator="{ props }">
                <v-btn
                  :disabled="!signedIn"
                  color="primary"
                  v-bind="props"
                  @click="markAsCommon(words.word, words.isCommon)"
                  >Common</v-btn
                >
              </template>
            </v-tooltip>
          </td>
          <td>
            <v-tooltip text="delete the word">
              <template v-slot:activator="{ props }">
                <v-btn
                  :disabled="!canAddWords"
                  color="primary"
                  v-bind="props"
                  @click="confirmDeleteWord(words.word)"
                  >Delete</v-btn
                >
              </template>
            </v-tooltip>
          </td>
        </tr>
      </tbody>
    </v-table>
    <v-pagination
      v-model="pageNumber"
      :length="Math.ceil(totalCount / pageSize)"
      @input="getWordList(wordToSearch, pageNumber, pageSize)"
      variant="outlined"
    />
    <!---->

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
            @click="addWord()"
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
const wordToDelete = ref("");
const wordList = ref<WordListItems[]>();
const totalCount = ref(0);
const pageNumber = ref(1);
const pageSize = ref(10);
const showConfirmDeleteWord = ref(false);
const userNameGlobal: Ref<string> = inject("userName")! as Ref<string>;
provide("wordToDelete", wordToDelete);
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

interface WordListItems {
  word: string;
  isCommon: boolean;
}

onMounted(async () => {
  if (tokenService.isLoggedIn()) {
    showSignInDialog.value = false;
  }
  await refreshWords();
});

watch([wordToSearch, pageNumber, pageSize], async () => {
  await refreshWords();
});

async function refreshWords(){
  console.log("refreshing words");
  wordList.value = await getWordList(
    wordToSearch.value,
    pageNumber.value,
    pageSize.value
  );
  return true;
}

function resetFilters() {
  wordToSearch.value = "";
  pageNumber.value = 1;
  pageSize.value = 10;
}

function confirmDeleteWord(word: string) {
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
        isCommon: data.isCommonWord,
      }));
      totalCount.value = data["count"];
    })
    .catch((error) => {
      console.log("api get Words error " + error);
    });
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
  Axios.post(
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
  if (isCommon === null || isCommon === undefined) {
    isCommon = true;
  }
  const headers = { Authorization: `Bearer ${tokenService.getToken()}` };
  console.log("headers " + headers);
  console.log("mark as common " + word + " " + !isCommon);
  Axios.post(
    "/Word/UpdateWord",
    {
      word: word,
      isCommon: !isCommon,
    },
    { headers }
  )
    .then((response) => {
      console.log("mark as common response " + response.status + " " + response.data);
    })
    .catch((error) => {
      console.log("api update word error " + error);
    });
   await refreshWords();
 
}


async function deleteWord(wordThatsDelete: string) {
  const headers = { Authorization: `Bearer ${tokenService.getToken()}` };
  console.log("delete word " + wordThatsDelete);
  Axios.delete("/Word/RemoveWord?word=${wordThatsDelete!}", { headers })
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
