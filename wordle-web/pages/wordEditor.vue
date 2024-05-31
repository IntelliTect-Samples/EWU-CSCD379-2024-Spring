<template>
  <v-progress-linear v-if="isLoading" color="primary" indeterminate />
  <v-card class="ma-10">
    <div class="text-center">
      <v-row>
        <v-col>
          <v-btn class="ma-7" variant="outlined" @click="addWordDialog = true"
            >Add word</v-btn
          >
        </v-col>
        <v-col>
          <v-radio-group v-model="commonRadio">
            <v-radio
              label="Both common/uncommon"
              :value="CommonRadio.Both"></v-radio>
            <v-radio label="Only common" :value="CommonRadio.Common"></v-radio>
            <v-radio
              label="Only uncommon"
              :value="CommonRadio.Uncommon"></v-radio>
          </v-radio-group>
        </v-col>
      </v-row>
    </div>
    <v-table class="table my-2 mx-auto w-75 opacity-50">
      <thead>
        <tr>
          <th
            class="text-center text-h8"
            @click="
              isWordOrderAscending = !isWordOrderAscending;
              sortWords(words!);
            ">
            <strong>Word</strong
            ><v-icon
              :icon="
                isWordOrderAscending ? 'mdi-chevron-up' : 'mdi-chevron-down'
              "></v-icon>
          </th>
          <th
            class="text-center text-h8"
            @click="
              commonWordOrder = (commonWordOrder + 1) % 3;
              sortWords(words!);
            ">
            <strong>Common Word</strong
            ><v-icon :icon="getCommonWordIcon()"></v-icon>
          </th>
          <th class="text-center text-h8"><strong>Edit</strong></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(word, index) in words">
          <td class="text-center text-h8">
            {{ word.word }}
          </td>
          <td class="text-center text-h8">
            {{ word.isCommonWord ? 'Yes' : 'No' }}
          </td>
          <td class="text-center text-h8">
            <v-row class="mt-0">
              <v-col cols="3">
                <v-switch
                  v-model="word.isCommonWord"
                  @update:modelValue="
                    isCommonWordChanged[index] = !isCommonWordChanged[index]
                  "></v-switch>
              </v-col>
              <v-col class="mt-2" cols="4">
                <v-btn
                  color="error"
                  variant="outlined"
                  icon="mdi-trash-can-outline"
                  size="35"
                  @click="deleteWord(word)"></v-btn>
              </v-col>
              <v-col class="mt-2" cols="4">
                <v-btn
                  :variant="isCommonWordChanged[index] ? 'elevated' : 'plain'"
                  @click="
                    isCommonWordChanged[index] = false;
                    saveCommonWordFlag(word.word, word.isCommonWord);
                  "
                  :color="isCommonWordChanged[index] ? 'primary' : ''">
                  Save
                </v-btn>
              </v-col>
            </v-row>
          </td>
        </tr>
      </tbody>
    </v-table>
    <v-pagination v-model="curretnPage":length="pageCount" :totalVisible="7"></v-pagination>
  </v-card>
  <v-dialog v-model="addWordDialog" width="400">
    <v-card height="200">
      <!--<v-text-field label="Word" v-model="wordToAdd" />-->
      <v-autocomplete
        v-model="wordToAdd"
        :items="words!.map(w => w.word)"
        label="Add Word"
      ></v-autocomplete>
      <v-btn
        @click="
          addWord();
          addWordDialog = false;
        "
        >Submit</v-btn
      >
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import Axios from 'axios';
import { TokenService, key } from '~/scripts/tokenService';

interface Word {
  word: string;
  isCommonWord: boolean;
}

enum CommonWordSortOrder {
  Ascending = 0,
  Descending = 1,
  Unspecified = 2,
}

enum CommonRadio {
  Both = 0,
  Common = 1,
  Uncommon = 2,
}

const isLoading = ref<boolean>(true);
const words = ref<Array<Word>>();
const wordsCopy = ref<Array<Word>>();
const isCommonWordChanged = ref<boolean[]>([]);
const tokenService: TokenService | undefined = inject(key);
const isWordOrderAscending = ref(true);
const commonWordOrder = ref(CommonWordSortOrder.Unspecified);
const addWordDialog = ref(false);
const wordToAdd = ref('');
const commonRadio = ref(CommonRadio.Both);

const itemsPerPage =ref(10);
const curretnPage = ref(1);

function paginatedWords() {
  const start = (curretnPage.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return words.value?.slice(start, end);
}
function pageCount() {
  return Math.ceil(words.value!.length / itemsPerPage.value);
}


watch([commonRadio], () => {
  //   console.log(`${onlyCommonRadio.value} ${onlyUncommon}`)
  sortWords(wordsCopy.value!);
  switch (commonRadio.value) {
    case CommonRadio.Both:
      words.value = wordsCopy.value;
      break;
    case CommonRadio.Common:
      words.value = wordsCopy.value?.filter(word => word.isCommonWord);
      break;
    case CommonRadio.Uncommon:
      words.value = wordsCopy.value?.filter(word => !word.isCommonWord);
      break;
  }
});

try {
  const gameUrl = 'word/getallwords';
  Axios.get(gameUrl).then(response => {
    words.value = response.data;
    wordsCopy.value = response.data;
    isLoading.value = false;
    isCommonWordChanged.value = Array.from(
      { length: response.data.length },
      (v, k) => false
    );
  });
} catch (error) {
  console.error('Error fetching words for word editor:', error);
}

async function saveCommonWordFlag(word: string, isCommonWord: boolean) {
  try {
    const gameUrl = 'word/changeCommonWordFlag';
    const headers = tokenService?.generateTokenHeader();
    await Axios.post(
      gameUrl,
      {
        word: word,
        isCommonWord: isCommonWord,
      },
      { headers }
    );
  } catch (error) {
    console.error('Error posting isCommonWord change:', error);
  }
}

async function deleteWord(word: Word) {
  try {
    const gameUrl = `word/deleteWord?word=${word.word}`;
    const headers = tokenService?.generateTokenHeader();
    console.log(headers);
    await Axios.post(gameUrl, {}, { headers });
    let index = words.value?.indexOf(word);
    words.value?.splice(index!, 1);
  } catch (error) {
    console.error('Error on deleteWord post:', error);
  }
}

function getCommonWordIcon() {
  switch (commonWordOrder.value) {
    case CommonWordSortOrder.Ascending:
      return 'mdi-chevron-up';
    case CommonWordSortOrder.Descending:
      return 'mdi-chevron-down';
    case CommonWordSortOrder.Unspecified:
      return 'mdi-unfold-more-horizontal';
  }
}

function sortWords(words: Array<Word>) {
  switch (commonWordOrder.value) {
    case CommonWordSortOrder.Ascending:
      if (isWordOrderAscending.value) {
        words = words.sort((a, b) => {
          let commonWordCompare =
            Number(a.isCommonWord) - Number(b.isCommonWord);
          if (commonWordCompare === 0) {
            return a.word.localeCompare(b.word);
          } else {
            return commonWordCompare;
          }
        });
      } else {
        words = words.sort((a, b) => {
          let commonWordCompare =
            Number(a.isCommonWord) - Number(b.isCommonWord);
          if (commonWordCompare === 0) {
            return b.word.localeCompare(a.word);
          } else {
            return commonWordCompare;
          }
        });
      }
      break;
    case CommonWordSortOrder.Descending:
      if (isWordOrderAscending.value) {
        words = words.sort((a, b) => {
          let commonWordCompare =
            Number(b.isCommonWord) - Number(a.isCommonWord);
          if (commonWordCompare === 0) {
            return a.word.localeCompare(b.word);
          } else {
            return commonWordCompare;
          }
        });
      } else {
        words = words.sort((a, b) => {
          let commonWordCompare =
            Number(b.isCommonWord) - Number(a.isCommonWord);
          if (commonWordCompare === 0) {
            return b.word.localeCompare(a.word);
          } else {
            return commonWordCompare;
          }
        });
      }
      break;
    case CommonWordSortOrder.Unspecified:
      if (isWordOrderAscending.value) {
        words = words.sort((a, b) => a.word.localeCompare(b.word));
      } else {
        words = words.sort((a, b) => b.word.localeCompare(a.word));
      }
      break;
  }
}

async function addWord() {
  try {
    const gameUrl = `word/addWord?word=${wordToAdd.value}`;
    const headers = tokenService?.generateTokenHeader();
    console.log(headers);
    await Axios.post(gameUrl, {}, { headers });
  } catch (error) {
    console.error('Error on addWord post:', error);
  }
}
</script>
