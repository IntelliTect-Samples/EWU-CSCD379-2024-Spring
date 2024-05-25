<template>
  <v-container>
    <v-progress-linear
      v-if="isWordsListLoading"
      class="mx-auto"
      color="primary"
      height="10"
      indeterminate
      rounded
      width="75%"
    />
    <div v-else>
      <v-autocomplete
        placeholder="Search"
        :items="wordsList.map((word) => word.word)"
      ></v-autocomplete>

      <div class="text-h3 ma-5 font-weight-bold text-primary">Words List</div>
      <v-row v-for="(word, i) in wordsList" :key="i">
        <v-col>
          {{ word.word }}
        </v-col>
        <v-col>
          {{ word.isCommon }}
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>
<script setup lang="ts">
import Axios from "axios";

const wordsList: Ref<WordDto[]> = ref([]);
const isWordsListLoading = ref(true);
interface WordDto {
  word: string;
  isCommon: boolean;
}

onMounted(async () => {
  wordsList.value = await Axios.get("word/wordsList")
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
});
</script>
