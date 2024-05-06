<template>
  <v-card class="my-7 mx-auto w-75">
    <v-sheet color="secondary">
      <v-card-title>Leaderboard</v-card-title>
    </v-sheet>
    <v-table class="table mt-7 mx-auto w-75">
      <thead>
        <tr>
          <th class="text-h6 text-center Name"><strong>Player Name</strong></th>
          <th class="text-h6 text-center GameCount">
            <strong>Game Count</strong>
          </th>
          <th class="text-center text-h6 AverageAttempts">
            <strong>Average Guesses</strong>
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
      <v-btn color="secondary" class="mb-5" @click="$router.push('/')"
        >Home</v-btn
      >
    </v-container>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios';

const apiUrl = 'https://wordlewebapijoshua.azurewebsites.net';

interface Player {
  name: string;
  gameCount: number;
  averageAttempts: number;
}

const topTenScores = ref<Player[]>();

//need to make GET request to the server to get the leaderboard data
Axios.get(apiUrl + '/leaderboard/GetScores')
  .then(response => {
    topTenScores.value = response.data;
  })
  .catch(error => {
    console.log(error);
  });
//note to self need to implement animate.css for the leaderboard extra credit
</script>
<style>
.table{
  background-color: unknownGradient;
  animation: colorChange 10s infinite;
}
@keyframes colorChange {
  0% {
    background-color: #b7afaf;
  }
  25% {
    background-color: #FFD54F;
  }
  50% {
    background-color: #9575CD;
  }
  75% {
    background-color: #482e74;
  }
  100% {
    background-color: #4f4f4f;
  }
}
</style>

