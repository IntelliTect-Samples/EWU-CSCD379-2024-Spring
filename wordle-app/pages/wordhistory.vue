<template>
	<v-container class="text-center">
		<v-progress-linear 
		v-if="wordDates === undefined"
		color="primary"
		indeterminate
		/>
		<v-card v-else class="mx-auto" max-width="800" outlined>
			<v-card-title class="text-h5" >Leaderboard</v-card-title>
			<v-card-text>
				<v-table>
					<thead>
						<tr>
                            <th>Index</th>
							<th>Date</th>
                            <th>Played?</th>
							<th>Number of Games</th>
							<th>Average Guesses</th>
							<th>Average Time</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="(wordDate, index) in wordDates" :key="wordDate.wordDateId">
							<td>{{ index + 1 }}</td>
							<td>{{ wordDate.date }}</td>
                            <td>Placeholder</td>
                            <td>{{ wordDate.gameCount }}</td>
							<td>{{ wordDate.averageAttempts }}</td>
							<td>{{ wordDate.averageSecondsPerGame }} sec.</td>
						</tr>
					</tbody>
				</v-table>
			</v-card-text>
		</v-card>
	</v-container>
</template>

<script setup lang="ts">
import type { WordDate } from "../scripts/wordDate";
import Axios from "axios";

const wordDates = ref<WordDate[]>();

onMounted(async () => {
	await Axios.get("/WordDate/RecentWordDates?numberOfWordDates=10")
  .then(response => {
    wordDates.value = response.data;
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
