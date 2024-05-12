<template>
  <v-table>
    <thead>
      <tr>
        <th>Date</th>
        <th>Average Attempts</th>
        <th>Total Games Played</th>
        <th>Number of Wins</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(wordStat, i) in wordStats" :key="i">
        <td>{{ wordStat.date }}</td>
        <td>{{ wordStat.averageAttempts }}</td>
        <td>{{ wordStat.totalGamesPlayed }}</td>
        <td>{{ wordStat.numberOfWins }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup lang="ts">
import Axios from "axios";

interface WordStats {
  date: string;
  averageAttempts: number;
  totalGamesPlayed: number;
  numberOfWins: number;
}

const wordStats = ref<WordStats[]>([]);

onMounted(() => {
  Axios.get("api/Statistics/GetWordStats?numDays=10")
    .then((res: { data: any }) => res.data)
    .then((data: any) =>
      data.map((player: any) => ({
        date: player.date,
        averageAttempts: player.averageAttempts,
        totalGamesPlayed: player.totalGamesPlayed,
        numberOfWins: player.numberOfWins,
      }))
    )
    .then((wordStatsData: WordStats[]) => {
      wordStats.value = wordStatsData;
    });
});
</script>
