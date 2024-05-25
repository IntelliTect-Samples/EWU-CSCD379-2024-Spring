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
              <v-col cols="3" class="mt">
                <v-switch v-model="word.isCommonWord"></v-switch>
              </v-col>
              <v-col class="mt-2">
                <v-btn
                  color="error"
                  variant="outlined"
                  icon="mdi-trash-can-outline"
                  size="35"></v-btn>
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

interface Word {
  word: string;
  isCommonWord: boolean;
}

const isLoading = ref<boolean>(true);
const words = ref<Array<Word>>();

try {
  const gameUrl = 'word/getallwords';
  Axios.get(gameUrl).then(response => {
    words.value = response.data;
    isLoading.value = false;
    console.log();
  });
} catch (error) {
  console.error('Error fetching words for word editor:', error);
}
</script>
