<template>
    <!--create a leader board that shows the stats for the last ten words-->
    <v-card>
        <v-card-title class = "text-center">Last Ten Word Stats</v-card-title>
        <v-table>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Times Played</th>
                    <th>Average Score</th>
                    <th>Average Time</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="stats in statsToDisplay" :key="stats.date">
                    <td v-if="stats.date">{{ stats.date }}</td>
                    <td v-if="stats.timesPlayed">{{ stats.timesPlayed }}</td>
                    <td v-if="stats.AverageScore">{{ stats.AverageScore }}</td>
                    <td v-if="stats.AverageTime">{{ stats.AverageTime }}</td>
                    
                </tr>
            </tbody>
        </v-table>
        <v-card-actions>
            <v-btn variant ="flat" color="primary" @click="router.push('/')">Back</v-btn>
        </v-card-actions>
    </v-card>
</template>

<script setup lang="ts">
import Axios from "axios" //npm install axios 
const router = useRouter();

interface Stats {
    date: string;
    timesPlayed: number;
    AverageScore: number;
    AverageTime: number;
}
const statsToDisplay = ref<Stats[]>();

onMounted(() => { 
   getStats();
})

async function getStats(){
    let scoreUrl = "Score/Leaderboard";
    await Axios.get(scoreUrl).then((response) => {
        statsToDisplay.value = response.data;
    })
    .catch((error) => {
        console.log(error);
    });

}

</script>