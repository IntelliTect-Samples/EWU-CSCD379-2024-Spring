<template>
  <!--create a leader board that shows the stats for the last ten words-->
  <v-card>
    <v-card-title class="text-center">Last Ten Word Stats</v-card-title>
    <v-table>
      <thead>
        <tr>
          <th>Date</th>
          <th>Average Guesses</th>
          <th>Average Time</th>
          <th>Total Times Played</th>
          <th>Total Wins</th>
          <th>Total Losses</th>
          <th>Did you play?</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="stats in statsToDisplay" :key="stats.date">
          <td v-if="stats.date">{{ stats.date }}</td> <td v-else>N/A</td>
          <td v-if="stats.averageGuesses">{{ stats.averageGuesses }}</td> <td v-else>N/A</td>
          <td v-if="stats.averageTime">{{ stats.averageTime }}</td> <td v-else>N/A</td>
          <td v-if="stats.totalTimesPlayed">{{ stats.totalTimesPlayed }}</td> <td v-else>0</td>
          <td v-if="stats.totalWins">{{ stats.totalWins }}</td> <td v-else>0</td>
          <td v-if="stats.totalWins && stats.totalTimesPlayed">{{ stats.totalTimesPlayed - stats.totalWins }}</td> <td v-else>{{stats.totalTimesPlayed}}</td>
          <td v-if="stats.played "> {{ stats.played ? "Yes" : "No" }}</td> <td v-else>No</td>
        </tr>
      </tbody>
    </v-table>
    <v-btn variant="flat" color="primary" @click="getStats()"
      >Refresh</v-btn>
    <v-card-actions>
      <v-btn variant="flat" color="primary" @click="router.push('/')"
        >Back</v-btn
      >
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { format } from "date-fns";
import Axios from "axios"; //npm install axios
import { Game } from "~/scripts/game";
const router = useRouter();
const game: Game = inject("GAME")!;
const date = ref("");
const userName : Ref<string> = inject("userName")! as Ref<string>;

interface Stats {
  date: string;
  averageGuesses: number;
  averageTime: number;
  totalTimesPlayed: number;
  totalWins: number;
  played: boolean;
}
const statsToDisplay = ref<Stats[]>();

onMounted(() => {
  getStats();
});

async function getStats() {
  let statUrl = "Game/GetGames";
  const formatDate = format(new Date(), "MM-dd-yyyy");
  date.value = formatDate;
  console.log("get games to api " + statUrl + "/" + userName.value);
  await Axios.get(statUrl + "/" + userName.value)
    .then((response) => {
      statsToDisplay.value = response.data;
      console.log("api get games response " + response.status);
    })
    .catch((error) => {
      console.log("api get games error " + error);
    });
}

</script>
