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
    <v-card variant="flat" class="pa-3 bg-secondary" v-else>
      <v-card-title class="text-center text-h5 mb-3">
        <v-icon class="rotate2d" color="primary">mdi-star</v-icon>
        Leaderboard
        <v-icon class="rotate2d" color="primary">mdi-star</v-icon>
      </v-card-title>

      <v-table>
        <thead>
          <tr>
            <th
              style="position: sticky; left: 0"
              class="text-center font-weight-bold bg-primary"
            >
              Rank
            </th>
            <th
              style="position: sticky; left: 50px"
              class="text-center font-weight-bold text-no-wrap bg-primary"
            >
              Player
            </th>
            <th class="text-center font-weight-bold text-no-wrap bg-primary">
              Games Played
            </th>
            <th class="text-center font-weight-bold text-no-wrap bg-primary">
              Average Attempts
            </th>
            <th class="text-center font-weight-bold text-no-wrap bg-primary">
              Average Seconds
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(player, i) in players" :key="i" class="bg-background">
            <td
              style="position: sticky; left: 0"
              class="text-center bg-background"
            >
              <v-icon v-if="i < 3" :class="[getTrophyColor(i), 'rotate']"
                >mdi-trophy</v-icon
              >

              <span v-else>{{ i + 1 }}</span>
            </td>

            <td
              style="position: sticky; left: 50px"
              class="text-center bg-background"
            >
              {{ player.name }}
            </td>

            <td class="text-center bg-background">{{ player.gameCount }}</td>
            <td class="text-center bg-background">
              {{ player.averageAttempts.toFixed(2) }}
            </td>
            <td class="text-center bg-background">
              {{ player.averageSeconds.toFixed(2) }}
            </td>
          </tr>
        </tbody>
      </v-table>
      <v-card-actions class="d-flex justify-center my-1">
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

// build 2d rotation
@keyframes rotate2d {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
//apply to v-icon now
.rotate2d {
  animation: rotate2d 3s linear infinite;
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

useHead({
  title: "Leaderboard",
  meta: [{ name: "description", content: "Cool site!" }],
});

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
