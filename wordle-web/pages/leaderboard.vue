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
      <v-data-table-server :items="players" />

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
import { onMounted } from "vue";
interface Player {
  id: number;
  name: string;
  score: number;
  attemps: number;
}


let players: Player[];

onMounted(() => {
  Axios.get("player/leaderboard")
    .then((res: { data: any }) => res.data)
    .then((data: any) =>
      data.map((player: any) => ({
        id: player.id,
        name: player.name,
        score: player.score,
        attemps: player.attemps,
      }))
    )
    .then((playersData: Player[]) => (players = playersData));
});

</script>