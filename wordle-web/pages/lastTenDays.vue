<template>
  <v-container>
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
          <v-card elevation="4">
            <v-sheet color="primary" class="py-2">
              <v-card-title v-if="isDaily">{{ ordinalDate(gameStat.date) }}</v-card-title>
              <v-card-title v-else>{{ gameStat.word }}</v-card-title>
            </v-sheet>
            <v-row class="mt-1">
              <v-col class="ml-2">
                <v-card-text class="font-weight-bold text-h7">Total Wins: {{ gameStat.totalWins }}</v-card-text>
                <v-card-text class="font-weight-bold text-h7">Total Losses: {{ gameStat.totalLosses }}</v-card-text>
                <v-card-text class="font-weight-bold text-h7">
                  Average Seconds: {{ gameStat.averageSeconds.toFixed(2) }}
                </v-card-text>
                <v-chip
                  v-if="hasPlayed(gameStat)"
                  class="mx-3 mt-1"
                  varient="tonal"
                  color="success"
                >
                  <v-icon>mdi-check</v-icon> You have played
                </v-chip>
                <v-chip v-else class="mx-3 mt-1" varient="tonal" color="error">
                  <v-icon>mdi-close</v-icon> You have not played
                </v-chip>
              </v-col>
              <v-col>
                <v-card-text class="font-weight-bold text-h7 text-center">Average Attempts</v-card-text>
                <v-progress-circular
                  :rotate="360"
                  :width="7"
                  color="win"
                  class="mx-auto font-weight-bold d-flex justify-center align-center"
                  size="80"
                  :model-value="averageAttempts(gameStat)"
                >
                  {{ averageAttempts(gameStat) }}%
                </v-progress-circular>
                <v-card-text class="font-weight-bold text-h7 text-center">Win Percentage</v-card-text>
                <v-progress-circular
                  :rotate="360"
                  :width="7"
                  color="warning"
                  class="mx-auto font-weight-bold d-flex justify-center align-center"
                  size="80"
                  :model-value="winPercentage(gameStat)"
                >
                  {{ winPercentage(gameStat) }}%
                </v-progress-circular>
              </v-col>
            </v-row>
            <v-card-actions class="py-5">
              <v-btn
                v-if="isDaily"
                class="pa-2 px-5 mx-3 mb-4 bg-primary"
                color="white"
                :to="`/Wordle/Daily?date=${formattedDate(gameStat.date)}`"
                >Play Word</v-btn
              >
            </v-card-actions>
            <v-sheet color="primary" height="5px" />
          </v-card>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script setup lang="ts">
    import { ref, onMounted } from 'vue';
    import Axios from 'axios';
    import { format, addDays } from 'date-fns';
    import nuxtStorage from 'nuxt-storage';
    import type { GameStats } from '~/Models/GameStats';

    const gameStats = ref<GameStats[]>([]);
    const playerName = ref("");

    onMounted(() => {
        const formatDate = format(new Date(), "MM-dd-yyyy");
        Axios.get(`game/LastTenWordOfTheDayStats/${formatDate}`)
            .then((res) => res.data)
            .then((data) =>
                data.map((item: any) => ({
                    totalGames: item.totalTimesPlayed,
                    totalWins: item.totalWins,
                    totalLosses: item.totalLosses,
                    averageSeconds: item.averageSeconds,
                    date: item.date,
                    word: item.word,
                    averageGuesses: item.averageGuesses,
                    usernames: item.usernames,
                }))
            )
            .then((gameStatData: GameStats[]) => {
                gameStats.value = gameStatData;
            });

        const defaultName = nuxtStorage.localStorage.getData("name");
        playerName.value = defaultName ? defaultName : "Guest";
    });

    const winPercentage = (gameStat) => {
        if (gameStat.totalGames === 0) {
            return "0"; // or any other default value
        }
        return ((gameStat.totalWins / gameStat.totalGames) * 100).toFixed(2);
    };

    const averageAttempts = (gameStat) => {
        return ((gameStat.averageGuesses / 6) * 100).toFixed(2);
    };

    const formatDateWithOrdinal = (date) => {
        return format(addDays(new Date(date), 1), "MMMM do, yyyy");
    };

    const formattedDate = (date) => {
        return format(addDays(new Date(date), 1), "yyyy-MM-dd");
    };

    const hasPlayed = (gameStat) => {
        return gameStat.usernames.includes(playerName.value);
    };
</script>