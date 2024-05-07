<template>
  <v-container>
    <div class="pyro">
      <div class="before"></div>
      <div class="after"></div>
    </div>

    <v-card
      color="secondary"
      class="mx-auto mt-8 w-75 pa-8 rounded text-center"
      elevation="4"
    >
      <v-card-title class="text-h3 mb-3">Leaderboard</v-card-title>
      <v-table>
        <thead>
          <tr>
            <th class="text-left">Player</th>
            <th>Games Played</th>
            <th>Average Attempts</th>
          </tr>
        </thead>
        <tr v-for="player in players" :key="player.playerId">
          <td class="text-left">{{ player.name }}</td>
          <td>{{ player.gameCount }}</td>
          <td>{{ player.averageAttempts }}</td>
        </tr>
      </v-table>

      <v-spacer />
      <v-card-actions class="d-flex justify-center">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Go Home"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import "../animations/fireworks.scss";
import Axios from "axios";
interface Player {
  playerId: number;
  name: string;
  gameCount: number;
  averageAttempts: number;
}

const players: ref<Player[]> = ref([]);

onMounted(() => {
  Axios.get("player/leaderboard")
    .then((res: { data: any }) => res.data)
    .then((data: any) =>
      data.map((player: any) => ({
        playerId: player.playerId,
        name: player.name,
        gameCount: player.gameCount,
        averageAttempts: player.averageAttempts,
      }))
    )
    .then((playersData: Player[]) => (players.value = playersData));
});

</script>