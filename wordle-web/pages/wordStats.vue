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
        </tr>
      </thead>
      <tbody>
        <tr v-for="stats in statsToDisplay" :key="stats.date">
          <td v-if="stats.date">{{ stats.date }}</td>
          <td v-if="stats.averageGuesses">{{ stats.averageGuesses }}</td>
          <td v-if="stats.averageTime">{{ stats.averageTime }}</td>
          <td v-if="stats.totalTimesPlayed">{{ stats.totalTimesPlayed }}</td>
          <td v-if="stats.totalWins">{{ stats.totalWins }}</td>
          <td v-if="stats.totalLosses">{{ stats.totalLosses }}</td>
        </tr>
      </tbody>
    </v-table>
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
import { w } from "@nuxt/test-utils/dist/shared/test-utils.9059LSjm";
const router = useRouter();
const game: Game = inject("GAME")!;
const date = ref("");

interface Stats {
  date: string;
  averageGuesses: number;
  averageTime: number;
  totalTimesPlayed: number;
  totalWins: number;
  totalLosses: number;
}
const statsToDisplay = ref<Stats[]>();

onMounted(() => {
  getStats();
});

async function getStats() {
  let statUrl = "/Game/GetGames";
  const formatDate = format(new Date(), "MM-dd-yyyy");
  date.value = formatDate;
  console.log("to api" + statUrl + "/" + date.value);
  await Axios.get(statUrl + "/" + date.value)
    .then((response) => {
      statsToDisplay.value = response.data;
    })
    .catch((error) => {
      console.log("api error" + error);
    });
}
watch(game.submitGuess, () => {
  getStats();
});
</script>
