<template>
    <!--create a leader board that shows top scores-->
    <v-card>
        <v-card-title class = "text-center">Leader Board</v-card-title>
        <v-table>
            <tbody>
                <tr v-for="score in scoresToDisplay" :key="score.userName">
                    <td>{{ score.userName }}</td>
                    <td>{{ score.aveAttempts }}</td>
                    <td>{{ score.gameCount }}</td>
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
    let scoreUrl = "Score/LeaderBoard";
    const response = await Axios.get(scoreUrl);
    console.log( "response from api " + response.data);
    scoresToDisplay.value = response.data;

}

</script>