<template>
	<v-container class="text-center">
		<v-progress-linear 
		v-if="players === undefined"
		color="primary"
		indeterminate
		/>
		<v-card v-else class="mx-auto" max-width="800" outlined>
			<v-card-title class="text-h5" >Leaderboard</v-card-title>
			<v-card-text>
				<v-table>
					<thead>
						<tr>
							<th>Rank</th>
							<th>Name</th>
							<th>Average Guesses</th>
							<th>Number of Games</th>
							<th>Average Time</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="(player, index) in players" :key="player.playerId">
							<td>{{ index + 1 }}</td>
							<td>{{ player.name }}</td>
							<td>{{ player.averageAttempts }}</td>
							<td>{{ player.gameCount }}</td>
							<td>{{ player.averageSecondsPerGame }} sec.</td>
						</tr>
					</tbody>
				</v-table>
			</v-card-text>
		</v-card>
	</v-container>
</template>

<script setup lang="ts">
import type { Player } from "../scripts/player";
import Axios from "axios";

const players = ref<Player[]>();

onMounted(async () => {
	await Axios.get("/Player/TopPlayers?numberOfPlayers=10")
  .then(response => {
    players.value = response.data;
  })
  .catch(error => {
    console.log("Errors",error);
  });
});

</script>

<style scoped>
th {
	text-align: center !important;
}
</style>
