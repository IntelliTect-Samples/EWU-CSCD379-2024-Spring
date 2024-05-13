<template>
  <v-card class="my-7 mx-auto w-75" elevation="2">
    <v-sheet color="deep-purple accent-4">
      <v-card-title class="white--text">Hall of Heroes</v-card-title>
    </v-sheet>
    <v-table class="table mt-7 mx-auto w-75" dense>
      <thead>
        <tr>
          <th class="text-h6 text-center Name"><strong>Adventurer</strong></th>
          <th class="text-h6 text-center GameCount">
            <strong>Quests Completed</strong>
          </th>
          <th class="text-center text-h6 AverageAttempts">
            <strong>Average Spells Cast</strong>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in topTenScores" :key="player.name">
          <td class="text-center">{{ player.name }}</td>
          <td class="text-center">{{ player.gameCount }}</td>
          <td class="text-center">{{ player.averageAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
    <v-container class="text-center">
      <v-btn color="amber darken-2" class="mb-5" @click="$router.push('/')">
        Return to Realm
      </v-btn>
    </v-container>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios';

interface Player {
  name: string;
  gameCount: number;
  averageAttempts: number;
}

const topTenScores = ref<Player[]>([]);

Axios.get('/leaderboard/GetScores')
  .then(response => {
    topTenScores.value = response.data;
  })
  .catch(console.error);
</script>

<style scoped>
.table {
  background-color: #5c3c92;
  animation: colorChange 10s infinite;
}
@keyframes colorChange {
  0%, 100% { background-color: #7c4dff; }
  25% { background-color: #b39ddb; }
  50% { background-color: #512da8; }
  75% { background-color: #311b92; }
}
</style>

