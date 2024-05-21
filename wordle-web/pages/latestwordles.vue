<template>
  <div class="full-page-gradient">
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
        <div class="text-h3 ma-5 font-weight-bold text-primary">
          Last Ten Wordles
        </div>
        <v-spacer />
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
            />
          </v-col>
        </v-row>
      </div>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import Axios from "axios";
import { format } from "date-fns";
import WordleStatsCard from "~/components/WordleStatsCard.vue";
import type { GameStats } from "~/Models/GameStas";

const isDailyWordlesLoading = ref(true);
const date = ref("");

const gameStats = ref<GameStats[]>([]);

onMounted(() => {
  const formatDate = format(new Date(), "MM-dd-yyyy");
  date.value = formatDate;
  Axios.get("game/LastTenWordOfTheDayStats/" + formatDate)
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
        usernames: data.usernames,
      }))
    )
    .then((gameStatData: GameStats[]) => {
      isDailyWordlesLoading.value = false;
      gameStats.value = gameStatData;
    });
});
</script>
<style scoped>
.full-page-gradient {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.fill-height {
  flex: 1;
  display: flex;
  flex-direction: column;
}
</style>

<style>
html, body {
  height: 100%;
  margin: 0;
  background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
}

#app {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.v-application--wrap {
  flex: 1;
  display: flex;
  flex-direction: column;
}

@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}
</style>