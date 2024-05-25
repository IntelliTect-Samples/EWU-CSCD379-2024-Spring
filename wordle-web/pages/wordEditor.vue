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
          <td>
            {{ word.Word }}
          </td>
          <td>
            {{ word.IsCommonWord ? '✅' : '❌' }}
          </td>
          <td>
            <v-btn>edit</v-btn>
          </td>
        </tr>
      </tbody>
    </v-table>
  </v-card>
</template>

<script setup lang="ts">
import Axios from 'axios';

interface Word {
  Word: string;
  IsCommonWord: boolean;
}

const isLoading = ref<boolean>(true);
const words = ref<Array<Word>>();
try {
  const gameUrl = 'word/getallwords';
  Axios.get(gameUrl).then(response => {
    words.value = response.data;
    isLoading.value = false;
  });
} catch (error) {
  console.error('Error fetching words for word editor:', error);
}
</script>
