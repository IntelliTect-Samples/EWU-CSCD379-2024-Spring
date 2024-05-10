<template>
  <v-container>
    <div class="pyro">
      <div class="before"></div>
      <div class="after"></div>
    </div>
    <v-progress-linear
      v-if="isLeaderboardLoading"
      class="mx-auto"
      color="primary"
      height="10"
      indeterminate
      rounded
      width="75%"
    />
    <v-card
      v-else
      color="secondary"
      class="mx-auto pa-8 w-75 rounded text-center"
      elevation="4"
    >
      <v-card-title class="text-h5 mb-2">
        <v-icon icon="mdi-star" />Leaderboard<v-icon icon="mdi-star"
      /></v-card-title>
      <v-card-item>
        <v-table>
          <thead>
            <tr class="bg-primary">
              <th class="text-center font-weight-bold">Rank</th>
              <th class="text-center font-weight-bold">Player</th>
              <th class="text-center font-weight-bold">Games Played</th>
              <th class="text-center font-weight-bold">Average Attempts</th>
              <th class="text-center font-weight-bold">Average Seconds</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(player, i) in players" :key="i" class="bg-background">
              <td v-if="i < 3">
                <v-icon :class="[isPosdium(i), 'rotate']">mdi-trophy</v-icon>
              </td>
              <td v-else>{{ i + 1 }}</td>
              <td class="w-25">{{ player.name }}</td>
              <td>{{ player.gameCount }}</td>
              <td>{{ player.averageAttempts.toFixed(2) }}</td>
              <td>{{ player.averageSeconds.toFixed(2) }}</td>
            </tr>
          </tbody></v-table
        >
      </v-card-item>

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

<style lang="scss" scoped>
.first-place {
  color: #ffd700;
}
.second-place {
  color: #c0c0c0;
}
.third-place {
  color: #cd7f32;
}

// build 3d roation
@keyframes rotate3d {
  0% {
    transform: rotate3d(0, 1, 0, 0deg);
  }
  100% {
    transform: rotate3d(0, 1, 0, 360deg);
  }
}
//apply to v-card now
.rotate {
  animation: rotate3d 3s linear infinite;
}
</style>

<script setup lang="ts">
import "../animations/fireworks.scss";
import Axios from "axios";
interface Player {
  playerId: number;
  name: string;
  gameCount: number;
  averageAttempts: number;
  averageSeconds: 0;
}

const isLeaderboardLoading = ref(true);

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
        averageSeconds: player.averageSeconds,
      }))
    )
    .then((playersData: Player[]) => {
      players.value = playersData;
      isLeaderboardLoading.value = false;
    });
});

function isPosdium(i: number) {
  if (i === 0) return "first-place";
  if (i === 1) return "second-place";
  if (i === 2) return "third-place";
}
</script>
