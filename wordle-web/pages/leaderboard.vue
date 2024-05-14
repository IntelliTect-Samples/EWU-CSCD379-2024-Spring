<template>
  <v-card class="my-7 mx-auto w-75 fantasy-card" elevation="2">
    <v-sheet color="deep-purple accent-4" class="fantasy-header">
      <v-card-title class="white--text fantasy-title">Hall of Heroes</v-card-title>
    </v-sheet>
    <v-table class="table mt-7 mx-auto w-75" dense>
      <thead>
        <tr>
          <th class="text-h6 text-center Name"><strong>Adventurer</strong></th>
          <th class="text-h6 text-center GameCount"><strong>Quests Completed</strong></th>
          <th class="text-center text-h6 AverageAttempts"><strong>Average Spells Cast</strong></th>
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
      <v-btn color="amber darken-2" class="mb-5 fantasy-btn" @click="$router.push('/')">Return to Realm</v-btn>
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

Axios.get('https://lexiquestapi.azurewebsites.net/leaderboard/GetScores')
  .then(response => {
    topTenScores.value = response.data;
  })
  .catch(console.error);
</script>

<style scoped>
.fantasy-card {
  background: url('path/to/your/fantasy-background.jpg') no-repeat center center;
  background-size: cover;
  border-radius: 15px;
  overflow: hidden;
}

.fantasy-header {
  background-color: rgba(85, 37, 130, 0.9);
  padding: 15px;
  text-align: center;
}

.fantasy-title {
  font-family: 'MedievalSharp', serif;
  font-size: 24px;
  color: #fff;
}

.table {
  background-color: rgba(92, 60, 146, 0.9);
  color: #fff;
  border: 1px solid #fff;
  animation: colorChange 10s infinite;
}

.table th, .table td {
  color: #fff;
}

.fantasy-btn {
  font-family: 'MedievalSharp', serif;
  font-size: 18px;
}

@keyframes colorChange {
  0%, 100% { background-color: rgba(124, 77, 255, 0.9); }
  25% { background-color: rgba(179, 157, 219, 0.9); }
  50% { background-color: rgba(81, 45, 168, 0.9); }
  75% { background-color: rgba(49, 27, 146, 0.9); }
}
</style>
