<template>
	<v-container class="text-center">
		<v-card class="mx-auto" max-width="800" outlined>
			<v-card-title class="text-h5" >Leaderboard</v-card-title>
			<v-card-text>
				<v-table>
					<thead>
						<tr>
							<th>Rank</th>
							<th>Name</th>
							<th>Average Guesses</th>
							<th>Number of Games</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="(player, index) in players" :key="player.playerId">
							<td>{{ index + 1 }}</td>
							<td>{{ player.name }}</td>
							<td>{{ Math.round(player.averageAttempts) }}</td>
							<td>{{ player.gameCount }}</td>
						</tr>
					</tbody>
				</v-table>
			</v-card-text>
		</v-card>
	</v-container>
</template>

<script setup lang="ts">
import Axios from "axios";
import type { Player } from "~/scripts/player";

const players = ref<Player[]>();

// interface Player {
// 	playerId: number;
// 	name: string;
// 	gameCount: number;
// 	averageAttempts: number;
// 	averageSecondsPerGame: number;
// }

// fetch the leaderboard data from the server
onMounted(async () => {

	if (window.location.hostname === "localhost" || window.location.hostname === "127.0.0.1") {
    Axios.defaults.baseURL = "https://localhost:7108/";
  } else {
    Axios.defaults.baseURL = "https://wordleapiewu.azurewebsites.net/";
  }

	const response = await Axios.get("/Player/TopPlayers?numberOfPlayers=10");
	players.value = response.data;
	console.log("What is this: " + players.value);
});

// create a dummy data for the leaderboard
// const players = [
// 	{ id: 1, name: "John", averageGuesses: 3, numberOfGames: 10 },
// 	{ id: 2, name: "Alex", averageGuesses: 4, numberOfGames: 20 },
// 	{ id: 3, name: "Alice", averageGuesses: 5, numberOfGames: 30 },
// 	{ id: 4, name: "Bob", averageGuesses: 6, numberOfGames: 40 },
// 	{ id: 5, name: "Charlie", averageGuesses: 7, numberOfGames: 50 },
// 	{ id: 6, name: "David", averageGuesses: 8, numberOfGames: 60 },
// 	{ id: 7, name: "Eve", averageGuesses: 9, numberOfGames: 70 },
// 	{ id: 8, name: "Frank", averageGuesses: 10, numberOfGames: 80 },
// 	{ id: 9, name: "Grace", averageGuesses: 11, numberOfGames: 90 },
// 	{ id: 10, name: "Hank", averageGuesses: 12, numberOfGames: 100 },
// ];

</script>
