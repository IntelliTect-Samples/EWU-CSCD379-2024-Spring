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
							<th>Average Time</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="player in players" :key="player.name">
							<td>{{ player.name }}</td>
							<td>{{ player.averageGuesses }}</td>
							<td>{{ player.gamesPlayed }}</td>
							<td>{{ player.averageTime }}</td>
						</tr>
					</tbody>
				</v-table>
			</v-card-text>
		</v-card>
	</v-container>
</template>

<script setup lang="ts">
import Axios from "axios";
import {ref} from 'vue';

const players = ref<Player[]>();
interface Player {
  name: string;
  averageGuesses: number;
  gamesPlayed: number;
  averageTime: number;
}

const topTenScores = ref<Player[]>();

//TODO: APIURL
Axios.get("https://wordleapiewusergeitim.azurewebsites.net/Player/TopPlayers?numberOfPlayers=10")
  .then(response => {
    players.value = response.data;
  })
  .catch(error => {
    console.log(error);
  });

</script>
