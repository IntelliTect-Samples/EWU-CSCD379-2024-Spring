<template>
    <!--create a leader board that shows top scores-->
    <v-card>
        <v-card-title class = "text-center">Leaderboard</v-card-title>
        <v-table>
            <thead>
                <tr>
                    <th>User Name</th>
                    <th>Average Attempts</th>
                    <th>Game Count</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="score in scoresToDisplay" :key="score.name">
                    <td v-if="score.name">{{ score.name }}</td>
                    <td v-if="score.averageAttempts">{{ score.averageAttempts }}</td>
                    <td v-if="score.gameCount">{{ score.gameCount }}</td>
                    
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

interface Score {
    name: string;
    averageAttempts: number;
    gameCount: number;
}
const scoresToDisplay = ref<Score[]>();

onMounted(() => { 
   getScores();
})

async function getScores(){
    let scoreUrl = "Player/Leaderboard";
    await Axios.get(scoreUrl, {params: {num: 10}}).then((response) => {
        scoresToDisplay.value = response.data;
    })
    .catch((error) => {
        console.log(error);
    });

}

</script>