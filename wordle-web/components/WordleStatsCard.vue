<template>
  <v-card elevation="4">
    <v-sheet color="primary" class="py-2">
      <V-card-title v-if="isDaily">{{ formattedDate }}</V-card-title>
      <v-card-title v-else>{{ gameStat.word }}</v-card-title>
    </v-sheet>
    <v-row>
      <v-col class="ml-2">
        <v-card-text class="font-weight-bold"
          >Total Wins: {{ gameStat.totalWins }}</v-card-text
        >
        <v-card-text class="font-weight-bold"
          >Total Losses: {{ gameStat.totalLosses }}</v-card-text
        >
        <v-card-text class="font-weight-bold"
          >Average Seconds {{ gameStat.averageSeconds }}</v-card-text
        >
        <v-chip class="ml-2" variant="flat" color="win" v-if="hasPlayed"
          >Played</v-chip
        >
        <v-chip class="ml-2" variant="flat" color="error" v-else
          >Not Played</v-chip
        >
      </v-col>
      <v-col>
        <v-card-titem
          class="text-center font-weight-bold d-flex flex-column align-cetner"
        >
          <v-card-text class="font-weight-bold">Average Attempts</v-card-text>
          <v-progress-circular
            :rotate="360"
            :width="5"
            color="win"
            class="mx-auto font-weight-bold"
            size="60"
            :model-value="averageAttempts"
          >
            {{ averageAttempts }}%</v-progress-circular
          >
        </v-card-titem>
        <v-card-titem class="text-center d-flex flex-column align-cetner">
          <v-card-text class="font-weight-bold">Win Percentaage</v-card-text>
          <v-progress-circular
            :rotate="360"
            :width="5"
            color="warning"
            class="mx-auto font-weight-bold"
            size="60"
            :model-value="winPercentage"
          >
            {{ winPercentage }}%</v-progress-circular
          >
        </v-card-titem>
      </v-col>
    </v-row>
    <v-card-actions class="py-5">
      <v-spacer />
      <v-btn v-if="!inCurrentGame" variant="flat" color="primary">Play</v-btn>
      <v-btn variant="flat" color="primary">Go to Stats Page</v-btn>
    </v-card-actions>
    <v-sheet color="primary" height="5px" />
  </v-card>
</template>
<script setup lang="ts">
import { format } from "date-fns";
import type { GameStats } from "~/Models/GameStas";

const winPercentage = computed(() => {
  return (props.gameStat.totalWins / props.gameStat.totalGames) * 100;
});

const averageAttempts = computed(() => {
  return (props.gameStat.averageGuesses / 6) * 100;
});

const props = withDefaults(
  defineProps<{
    gameStat: GameStats;
    isDaily: boolean;
    hasPlayed: boolean;
    inCurrentGame: boolean;
  }>(),
  {
    hasPlayed: false,
    isDaily: false,
    inCurrentGame: true,
  }
);

const formattedDate = computed(() => {
  return format(new Date(props.gameStat.date), "MMMM dd, yyyy");
});
</script>
