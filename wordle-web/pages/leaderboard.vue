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
      <tr v-for="player in players" :key="player.id"> //replace players with LeaderPlayers
        <td>{{ player.name }}</td>
        <td>{{ player.gameCount }}</td>
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
  { id: 1, name: "John Doe", gameCount: 100, averageAttempts: 3 },
  { id: 2, name: "Jane Doe", gameCount: 200, averageAttempts: 2 },
  { id: 3, name: "John Smith", gameCount: 150, averageAttempts: 4 },
  { id: 4, name: "Jane Smith", gameCount: 250, averageAttempts: 1 },
];
interface Players {
  name: string;
  gameCount: number;
  averageAttempts: number;
}

const LeaderPlayers = ref<Players[]>();
/*Axios.get("http://localhost:3000/leaderboard").then((response) => {
  setTimeout(() => {}, 100)
  console.log(response.data);
  LeaderPlayers.value = response.data;
}).catch((error) => {
  console.log(error);
});*/
//need to make GET request to the server to get the leaderboard data
Axios.get(`leaderboard/GetTopScores`).then((response) => {
  setTimeout(() => {}, 100)
  console.log(response.data);
  LeaderPlayers.value = response.data;
}).catch((error) => {
  console.log(error);
});
</script>
