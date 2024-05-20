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
  <v-container v-else>
    <div>
      <div class="text-h3 ma-5 text-center font-weight-bold text-primary">
        Last Ten Wordles
      </div>
      <v-row cols="12">
        <v-col
          v-for="(gameStat, i) in gameStats"
          :key="i"
          cols="12"
          sm="12"
          md="6"
          lg="4"
        >
          <WordleStatsCard
            :gameStat="gameStat"
            :isDaily="true"
            :inCurrentGame="false"
            :hasPlayed="false"
          />
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script setup lang="ts">
import Axios from "axios";
import { format } from "date-fns";
import WordleStatsCard from "~/components/WordleStatsCard.vue";
import type { GameStats } from "~/Models/GameStas";

const isDailyWordlesLoading = ref(true);
const date = ref("");
interface Game {
  word: string;
  isWin: boolean;
  attempts: number;
}

const gameStats = ref<GameStats[]>([]);

onMounted(() => {
  const formatDate = format(new Date(), "MM-dd-yyyy");
  date.value = formatDate;
  Axios.get("/Game/LastTenWordOfTheDayStats/" + "5-20-2024")
    .then((res: { data: any }) => res.data)
    .then((data: any) =>
      data.map((data: any) => ({
        totalGames: data.totalTimesPlayed,
        totalWins: data.totalWins,
        totalLosses: data.totalLosses,
        averageSeconds: data.averageSeconds,
        date: data.date,
        word: data.word,
        averageGuesses: data.averageGuesses,
      }))
    )
    .then((gameStatData: GameStats[]) => {
      console.log(gameStatData);
      isDailyWordlesLoading.value = false;
      gameStats.value = gameStatData;
    });
});
</script>
