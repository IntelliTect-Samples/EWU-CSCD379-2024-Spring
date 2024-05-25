<template>
	<v-container class="text-center" style="max-width: 900px;">
		<v-progress-linear v-if="wordStats === undefined" color="primary" indeterminate />
		<div v-else>
			<v-row>
				<v-col>
					<!-- Title of the page -->
					<h1 class="display-1">Statistics</h1>
				</v-col>
			</v-row>
			<v-row>
				<v-col>
					<!-- Explain that user can click on a card to play that date word of tha day game -->
					<v-alert outlined color="primary">
						Click on a card to play that date's word of the day game
					</v-alert>
				</v-col>
			</v-row>
			<v-row>
				<v-col v-for="(word, index) in wordStats" :key="index">
					<v-card hover>
						<v-card-title>{{ word.datePlayed }}</v-card-title>
						<v-card-text>
							<v-row>
								<v-col>
									<v-card-subtitle>Games Played</v-card-subtitle>
									{{ word.numberOfPlays }}
								</v-col>
								<v-col>
									<v-card-subtitle>Average Attempts</v-card-subtitle>
									{{ word.averageAttempts }}
								</v-col>
								<v-col>
									<v-card-subtitle>Average Time</v-card-subtitle>
									{{ word.averageScore }}
								</v-col>
								<v-col>
									<v-card-subtitle>You played</v-card-subtitle>
									{{  word.hasPlayedWordOfTheDay ? "✅" : "🚫"}}

								</v-col>
							</v-row>
						</v-card-text>
					</v-card>
				</v-col>
			</v-row>
		</div>
	</v-container>
</template>

<script setup lang="ts">
import nuxtStorage from "nuxt-storage";
import Axios from "axios";

interface WordStats {
	datePlayed: Date;
	numberOfPlays: number;
	averageScore: number;
	averageAttempts: number;
	hasPlayedWordOfTheDay: boolean;
}

const playerName = nuxtStorage.localStorage.getData("userName");

const wordStats = ref<WordStats[]>();

onMounted(() => {
	// Fetch wordStats from the server
	fetchWordStats();
});

async function fetchWordStats() {
	await Axios.post("/Game/Stats?playerName=" + playerName)
		.then(response => {
			wordStats.value = response.data;
		})
		.catch(error => {
			console.log("Errors", error);
		});
}

// Dummy data for wordStats for now
// const wordStatsDummy: WordStats[] = [
// 	{
// 		date: "2022-01-01",
// 		gameCount: 10,
// 		averageAttempts: 5,
// 		averageSeconds: 30,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-02",
// 		gameCount: 15,
// 		averageAttempts: 4,
// 		averageSeconds: 25,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-03",
// 		gameCount: 20,
// 		averageAttempts: 3,
// 		averageSeconds: 20,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-04",
// 		gameCount: 25,
// 		averageAttempts: 2,
// 		averageSeconds: 15,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-05",
// 		gameCount: 30,
// 		averageAttempts: 1,
// 		averageSeconds: 10,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-01",
// 		gameCount: 10,
// 		averageAttempts: 5,
// 		averageSeconds: 30,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-02",
// 		gameCount: 15,
// 		averageAttempts: 4,
// 		averageSeconds: 25,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-03",
// 		gameCount: 20,
// 		averageAttempts: 3,
// 		averageSeconds: 20,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-04",
// 		gameCount: 25,
// 		averageAttempts: 2,
// 		averageSeconds: 15,
// 		playerId: "1",
// 	},
// 	{
// 		date: "2022-01-05",
// 		gameCount: 30,
// 		averageAttempts: 1,
// 		averageSeconds: 10,
// 		playerId: "1",
// 	},
// ];

</script>
