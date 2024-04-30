<template>
  <v-card class="mt-7 mx-auto w-75">
    <v-sheet color="secondary">
      <v-card-title>Leaderboard</v-card-title>
    </v-sheet>
  </v-card>
  <v-card>
  <v-table class="mt-7 mx-auto w-75">
    <thead>
      <tr>
        <th class="Player ID">
          Player ID
        </th>
        <th class = "Name">
          Palyer Name
        </th>
        <th class = "GameCount">
          Score
        </th>
        <th class="AverageAttempts">
          Average Attempts
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="player in players" :key="player.id">
        <td>{{ player.id }}</td>
        <td>{{ player.name }}</td>
        <td>{{ player.score }}</td>
        <td>{{ player.averageAttempts }}</td>
      </tr>
    </tbody>
  </v-table>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Axios from "axios";
//replace later with actual data
const players = [
  { id: 1, name: "John Doe", score: 100, averageAttempts: 3 },
  { id: 2, name: "Jane Doe", score: 200, averageAttempts: 2 },
  { id: 3, name: "John Smith", score: 150, averageAttempts: 4 },
  { id: 4, name: "Jane Smith", score: 250, averageAttempts: 1 },
];
</script>
