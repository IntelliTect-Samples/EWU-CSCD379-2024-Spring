<template>
  <v-card :width="cardWidth"
          class="my-7 mx-auto cardWidth">
    <v-sheet color="secondary">
      <v-card-title>Leaderboard</v-card-title>
    </v-sheet>
    <v-table class="table mt-7 mx-auto w-75 opacity-50">
      <thead>
        <tr>
          <th :height="cardHeight"
              
              class="textSize text-center Name"><strong>Player Name</strong></th>
          <th :height="cardHeight" 
              
              class="textSize text-center GameCount">
            <strong>Game Count</strong>
          </th>
          <th :height="cardHeight" 
              
              class="textSize text-center AverageAttempts">
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
import { useDisplay } from 'vuetify';
const cardHeight = ref(100);
let cardWidth = "h-75";
let textSize = "text-h6";
const display = useDisplay();

watch([display.sm, display.xs, display.md, display.lgAndUp], () => {
  if (display.xs.value) {
    cardHeight.value = 30;
    cardWidth = "h-25";
    textSize = "text-body-2";
  } else if (display.sm.value) {
    cardHeight.value = 40;
    cardWidth = "h-50";
    textSize = "text-subtitle-2";
  } else if (display.md.value) {
    cardHeight.value = 100;
    cardWidth = "h-75";
    textSize = "text-h5";
  }else{
    cardHeight.value = 100;
    cardWidth = "h-100";
    textSize = "text-h3";
  }
});

interface Player {
  name: string;
  gameCount: number;
  averageAttempts: number;
}

const topTenScores = ref<Player[]>();

//need to make GET request to the server to get the leaderboard data
Axios.get('/leaderboard/GetScores')
  .then(response => {
    topTenScores.value = response.data;
  })
  .catch(error => {
    console.log(error);
  });
//note to self need to implement animate.css for the leaderboard extra credit
</script>

<style>
.table {
  background-color: unknownGradient;
  animation: colorChange 10s infinite;
}
@keyframes colorChange {
  0% {
    background-color: #b7afaf;
  }
  25% {
    background-color: #ffd54f;
  }
  50% {
    background-color: #9575cd;
  }
  75% {
    background-color: #482e74;
  }
  100% {
    background-color: #4f4f4f;
  }
}
</style>
