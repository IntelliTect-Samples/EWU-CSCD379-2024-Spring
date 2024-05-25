<template>
  <v-progress-linear v-if="isLoading" color="primary" indeterminate />
  <v-card class="ma-10">
    <v-table class="table my-2 mx-auto w-75 opacity-50">
      <thead>
        <tr>
          <th class="text-center text-h8"><strong>Word</strong></th>
          <th class="text-center text-h8"><strong>Common Word</strong></th>
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
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios';
import { TokenService, key } from '~/scripts/tokenService';

interface Word {
  word: string;
  isCommonWord: boolean;
}

const isLoading = ref<boolean>(true);
const words = ref<Array<Word>>();
const isCommonWordChanged = ref<boolean[]>([]);
const tokenService: TokenService | undefined = inject(key);

try {
  const gameUrl = 'word/getallwords';
  Axios.get(gameUrl).then(response => {
    words.value = response.data;
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
</script>
