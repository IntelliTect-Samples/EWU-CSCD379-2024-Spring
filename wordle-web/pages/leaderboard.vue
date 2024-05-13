<template>
  <v-card class="my-7 mx-auto w-75" elevation="10" shaped>
    <v-sheet color="deep-purple accent-4">
      <v-card-title class="display-1 white--text">LexiQuest Leaderboard</v-card-title>
    </v-sheet>
    <v-table class="elevation-5 mt-7 mx-auto w-75">
      <thead>
        <tr>
          <th class="text-h6 text-center Name"><strong>Adventurer</strong></th>
          <th class="text-h6 text-center GameCount">
            <strong>Quests Completed</strong>
          </th>
          <th class="text-center text-h6 AverageAttempts">
            <strong>Average Attempts</strong>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="player in topTenScores" :key="player.name">
          <td class="text-center">{{ player.name }}</td>
          <td class="text-center">{{ player.gameCount }}</rd>
          <td class="text-center">{{ player.averageAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
    <v-container class="text-center">
      <v-btn color="purple darken-2" dark class="mb-5" @click="$router.push('/')">
        Return to the Realm
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

const topTenScores = ref<Player[]>();

Axios.get('/leaderboard/GetScores')
  .then(response => {
    topTenScores.value = response.data;
  })
  .catch(error => {
    console.error('Failed to load scores:', error);
  });
</script>

<style scoped>
.v-table {
  background-color: #663399;
  color: #fff;
  border-radius: 8px;
}

.v-card {
  background-image: url('path_to_your_background_image');
  background-size: cover;
  background-repeat: no-repeat;
}

@keyframes colorChange {
  0%, 100% {
    background-color: #6a1b9a; /* deep purple */
  }
  25% {
    background-color: #7c4dff; /* deep purple accent */
  }
  50% {
    background-color: #ba68c8; /* medium purple */
  }
  75% {
    background-color: #ce93d8; /* light purple */
  }
}

.v-table thead th {
  font-family: 'Merriweather', serif; 
  text-shadow: 1px 1px 2px black;
}

.v-btn {
  font-family: 'Merriweather', serif;
}
</style>
