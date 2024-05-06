<template>
    <!--create a leader board that shows top scores-->
    <v-card>
        <v-card-title class = "text-center">Leader Board</v-card-title>
        <v-table>
            <thead>
                <tr>
                    <th>User Name</th>
                    <th>Average Attempts</th>
                    <th>Game Count</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="score in scoresToDisplay" :key="score.userName">
                    <td v-if="score.userName">{{ score.userName }}</td>
                    console.log(score.userName);
                    <td v-if="score.aveAttempts">{{ score.aveAttempts }}</td>
                    console.log(score.aveAttempts);
                    <td v-if="score.gameCount">{{ score.gameCount }}</td>
                    console.log(score.gameCount);
                </tr>
            </tbody>
        </v-table>
        <v-card-actions>
            <v-btn @click="router.push('/')">Back</v-btn>
        </v-card-actions>
    </v-card>
</template>

<script setup lang="ts">
import Axios from "axios" //npm install axios 
const router = useRouter();

interface Score {
    userName: string;
    aveAttempts: number;
    gameCount: number;
}
const scoresToDisplay = ref<Score[]>();

onMounted(() => { 
   getScores();
})

async function getScores(){
    let scoreUrl = "Score/Leaderboard";
    const response = await Axios.get(scoreUrl).then((response) => {
        scoresToDisplay.value = response.data;
    })
    .catch((error) => {
        console.log(error);
    });

}

</script>