<template>
  <v-card>
    <v-sheet color="primary py-3">
      <v-row>
        <v-col>
          <V-card-title v-if="isDaily">{{ formattedDate }}</V-card-title>
          <v-card-title v-else>{{ gameState.word }}</v-card-title>
        </v-col>
        <v-col>
          <v-chip variant="tonal" v-if="hasPlayed">Played</v-chip>
          <v-chip variant="tonal" v-else>Not Played</v-chip>
        </v-col>
      </v-row>
    </v-sheet>
    <v-row>
      <v-col>
        <v-card-text>Total Games: {{ gameState.totalGames }}</v-card-text>
        <v-card-text>Total Wins: {{ gameState.totalWins }}</v-card-text>
        <v-card-text>Total Losses: {{ gameState.totalLosses }}</v-card-text>
      </v-col>
      <v-col>
        <v-card-titem class="d-flex flex-column align-cetner">
          <v-card-text>Average Attempts</v-card-text>
          <v-progress-circular model-value="20"></v-progress-circular>
        </v-card-titem>

        <v-card-text>Average Seconds</v-card-text>
        <v-progress-circular model-value="20"></v-progress-circular>
      </v-col>
    </v-row>
    <v-card-action>
      <v-btn>Play</v-btn>
      <v-btn>Go to Stats Page</v-btn>
    </v-card-action>
  </v-card>
</template>
<script setup lang="ts">
import { format } from "date-fns";
import type { GameStats } from "~/Models/GameStas";

const props = withDefaults(
  defineProps<{ gameState: GameStats; isDaily: boolean; hasPlayed: boolean }>(),
  {
    hasPlayed: false,
    isDaily: false,
  }
);

const formattedDate = computed(() => {
  return format(new Date(props.gameState.date), "MMMM dd, yyyy");
});
</script>
