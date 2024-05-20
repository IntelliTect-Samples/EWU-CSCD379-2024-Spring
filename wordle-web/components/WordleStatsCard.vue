<template>
  <v-card>
    <v-sheet color="primary py-3">
      <v-row>
        <v-col>
          <V-card-title v-if="isDaily">{{ Gamestas.Date }}</V-card-title>
          <v-card-title v-else>{{ Gamestas.Word }}</v-card-title>
        </v-col>
        <v-col>
          <v-chip v-if="hasPlayed">Played</v-chip>
          <v-chip v-else>Not Played</v-chip>
        </v-col>
      </v-row>
    </v-sheet>
    <v-row>
      <v-col>
        <v-card-text
          >Average Total Games: {{ Gamestas.totalGames }}</v-card-text
        >
        <v-card-text>Average Total Wins: {{ Gamestas.totalWins }}</v-card-text>
        <v-card-text
          >Average Total Losses: {{ Gamestas.totalLosses }}</v-card-text
        >
      </v-col>
      <v-col>
        <v-card-titem>
          <v-card-title>Average Attempts</v-card-title>
          <v-progress-circular model-value="20"></v-progress-circular>
          <v-card-title>Average Seconds</v-card-title>
          <v-progress-circular model-value="20"></v-progress-circular>
        </v-card-titem>
      </v-col>
    </v-row>
  </v-card>
</template>
<script setup lang="ts">
import type { GameStats } from "~/Models/GameStas";

const props = withDefaults(
  defineProps<{
    Gamestas: GameStats;
    isDaily: boolean;
    hasPlayed: boolean;
  }>(),
  {
    hasPlayed: false,
    isDaily: false,
  }
);
</script>
