<template>
  <v-card elevation="4">
    <v-sheet color="primary" class="py-2">
      <V-card-title v-if="isDaily">{{ formattedDate }}</V-card-title>
      <v-card-title v-else>{{ gameStat.word }}</v-card-title>
    </v-sheet>
    <v-row class="mt-1">
      <v-col class="ml-2">
        <v-card-text class="font-weight-bold text-h7"
          >Total Wins: {{ gameStat.totalWins }}</v-card-text
        >
        <v-card-text class="font-weight-bold text-h7"
          >Total Losses: {{ gameStat.totalLosses }}</v-card-text
        >
        <v-card-text class="font-weight-bold text-h7"
          >Average Seconds:
          {{ gameStat.averageSeconds.toFixed(2) }}</v-card-text
        >
        <v-chip
          v-if="hasPlayed"
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
        <v-card-text class="font-weight-bold text-h6 text-center"
          >Average Attempts</v-card-text
        >
        <v-progress-circular
          :rotate="360"
          :width="10"
          color="win"
          class="mx-auto font-weight-bold d-flex justify-center align-center"
          size="90"
          :model-value="averageAttempts"
        >
          {{ averageAttempts }}%</v-progress-circular
        >
        <v-card-text class="font-weight-bold text-h6 text-center"
          >Win Percentage</v-card-text
        >
        <v-progress-circular
          :rotate="360"
          :width="10"
          color="warning"
          class="mx-auto font-weight-bold d-flex justify-center align-center"
          size="90"
          :model-value="winPercentage"
        >
          {{ winPercentage }}%</v-progress-circular
        >
      </v-col>
    </v-row>
    <v-card-actions class="py-5">
      <v-btn
        v-if="isDaily"
        class="pa-2 px-5 mx-3 mb-4 bg-primary"
        color="white"
        :to="`/Wordle/Daily?date=${formattedDate}`"
        >Play Word</v-btn
      ></v-card-actions
    >
    <v-sheet color="primary" height="5px" />
  </v-card>
</template>

<script setup lang="ts">
import { format, addDays } from "date-fns";
import type { GameStats } from "~/Models/GameStas";
import nuxtStorage from "nuxt-storage";

const playerName = ref("");

const props = withDefaults(
  defineProps<{
    gameStat: GameStats;
    isDaily: boolean;
    inCurrentGame: boolean;
  }>(),
  {
    hasPlayed: false,
    isDaily: false,
    inCurrentGame: true,
  }
);

const winPercentage = computed(() => {
  if (props.gameStat.totalGames === 0) {
    return "0"; // or any other default value
  }
  return ((props.gameStat.totalWins / props.gameStat.totalGames) * 100).toFixed(
    2
  );
});

const averageAttempts = computed(() => {
  return ((props.gameStat.averageGuesses / 6) * 100).toFixed(2);
});

const formattedDate = computed(() => {
  return format(addDays(new Date(props.gameStat.date), 1), "MMMM dd, yyyy");
});

const hasPlayed = computed(() => {
  return props.gameStat.usernames.includes(playerName.value);
});

onMounted(async () => {
  const defaultName = nuxtStorage.localStorage.getData("name");
  playerName.value = defaultName ? defaultName : "Guest";
});
</script>
