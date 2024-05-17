<template>
  <v-container class="text-center">
    <v-card class="mx-auto" max-width="1000" outlined>
      <v-card-title class="text-h5">LEADERBOARD</v-card-title>
      <v-card-text>
        <v-row>
          <v-col cols="1" class="text-center">
            ID
          </v-col>
          <v-col cols="6 " class="text-center">
            NAME 
          </v-col>
          <v-col cols="2" class="">
            AVG ATTEMPTS
          </v-col>
          <v-col cols="2" class="text-center" >
            PLAYS 
          </v-col>
        </v-row>
        <v-divider></v-divider>
        <v-table>
          <tbody>
            <tr v-for="player in topTen" :key="player.name">
              <td class="text-center">{{ player.Name }}</td>
              <td class="text-center">{{ player.GameCount }}</td>
              <td class="text-center">{{ player.AverageAttempts }}</td>
            </tr>
          </tbody>
        </v-table>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios';

interface PlayerInfo{
  name: string;
  gameCount: number;
  averageAttempts: number;
};

const topTen = ref<PlayerInfo[]>([]);

Axios.get('/leaderboard/GetScores')
  .then(response => {
    topTenScores.value = response.data;
  })
  .catch(error => {
    console.log(error);
  });

</script>
