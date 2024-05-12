<template>
  <v-progress-linear
    v-if="isDailyWordlesLoading"
    class="mx-auto"
    color="primary"
    height="10"
    indeterminate
    rounded
    width="75%"
  />
  <div v-else>
    <v-tabs center-active v-model="selectedDate">
      <v-tab v-for="(wordStat, i) in wordStats" :key="i">
        {{ wordStat.date }}
      </v-tab>
    </v-tabs>
    <v-tabs-window v-model="selectedDate">
      <v-card>
        <v-card-text
          >Average Attemps:
          {{ wordStats[selectedDate].averageAttempts }}</v-card-text
        >
        <v-card-text
          >Number of Wins:
          {{ wordStats[selectedDate].numberOfWins }}</v-card-text
        >
        <v-card-text
          >Total Games Played:
          {{ wordStats[selectedDate].totalGamesPlayed }}</v-card-text
        >
      </v-card>
    </v-tabs-window>
  </div>
</template>

<script setup lang="ts">
import Axios from "axios";

const selectedDate = ref(0);
const isDailyWordlesLoading = ref(true);

interface WordStats {
  date: string;
  averageAttempts: number;
  totalGamesPlayed: number;
  numberOfWins: number;
}

const wordStats = ref<WordStats[]>([]);

onMounted(() => {
  Axios.get("api/Statistics/GetWordStats?numDays=10")
    .then((res: { data: any }) => res.data)
    .then((data: any) =>
      data.map((word: any) => ({
        date: word.date,
        averageAttempts: word.averageAttempts,
        totalGamesPlayed: word.totalGamesPlayed,
        numberOfWins: word.numberOfWins,
      }))
    )
    .then((wordStatsData: WordStats[]) => {
      console.log(wordStatsData);
      isDailyWordlesLoading.value = false;
      wordStats.value = wordStatsData;
    });
});
</script>
