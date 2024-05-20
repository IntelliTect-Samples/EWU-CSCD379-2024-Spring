<template>
  <div>
    <v-card class="mx-auto" max-width="1000" outlined color="primary">
      <v-sheet>
        <h1 style="font-size: 2em"class="text-center">LeaderBoard🥇👨‍🌾</h1>     
      </v-sheet>
      <v-card-text style="font-size: 1em"class="text-center">
      Here are our top players : 
  </v-card-text>
  <v-table>
          <tbody>
            <tr>
              <td class="text-center">ID</td>
              <td class="text-center">Name</td>
              <td class="text-center">Average Attempts</td>
              <td class="text-center">Plays</td>
            </tr>

            <tr v-for="(row, index) in tableData" :key="index">
              <td class="text-center">{{ row.Name }}</td>
              <td class="text-center">{{ row.GameCount }}</td>
              <td class="text-center">{{ row.AverageAttempts }}</td>
              <td class="text-center">{{ row.Plays }}</td>
          </tr>
        </tbody>
      </v-table>

    </v-card>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios';

const tableData = ref([
  { Name: 'user1', GameCount: 24, AverageAttempts: 80, Plays: 30},
  { Name: 'oompaloompa', GameCount: 24, AverageAttempts: 80, Plays: 10},
  { Name: 'ultimatehillbill', GameCount: 24, AverageAttempts: 80, Plays: 3},
  { Name: 'billyhilly', GameCount: 24, AverageAttempts: 80, Plays: 400},
  { Name: 'thehillbillmaster', GameCount: 24, AverageAttempts: 80, Plays: 60},

])
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
