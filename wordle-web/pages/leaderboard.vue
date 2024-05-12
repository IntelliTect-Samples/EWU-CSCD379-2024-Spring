<template>
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
  <v-table density="compact">
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
        <td class="text-center" v-if="i < 3">
          <v-icon :class="[getTrophyColor(i), 'rotate']">mdi-trophy</v-icon>
        </td>
        <td class="text-center" v-else>{{ i + 1 }}</td>
        <v-tooltip location="top">
          <template v-slot:activator="{ props }">
            <td icon v-bind="props">
              {{ player.name }}
            </td>
          </template>
          <span> {{ player.name }}</span>
        </v-tooltip>
        <td class="text-center">{{}}</td>
        <td class="text-center">{{ player.gameCount }}</td>
        <td class="text-center">{{ player.averageAttempts.toFixed(2) }}</td>
        <td class="text-center">{{ player.averageSeconds.toFixed(2) }}</td>
      </tr>
    </tbody>
  </v-table>
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

td {
  width: 0;
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

const players = ref<Player[]>([]);

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

function getTrophyColor(i: number) {
  if (i === 0) return "first-place";
  if (i === 1) return "second-place";
  if (i === 2) return "third-place";
}
</script>
