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
          <th class="Name">Player Name</th>
          <th class="GameCount">Game Count</th>
          <th class="AverageAttempts">Average Guesses</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in topTenScores" :key="player.name">
          <td>{{ player.name }}</td>
          <td>{{ player.gameCount }}</td>
          <td>{{ player.averageAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
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
    setTimeout(() => {}, 100);
    console.log(response.data);
    topTenScores.value = response.data;
  })
  .catch(error => {
    console.log(error);
  });
//note to self need to implement animate.css for the leaderboard extra credit
</script>
