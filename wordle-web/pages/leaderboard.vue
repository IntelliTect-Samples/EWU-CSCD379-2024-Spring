<template>
    <!--create a leader board that shows top scores-->
    <v-card>
        <v-card-title class = "text-center">Leader Board</v-card-title>
        <v-card-text>
            <v-list>
                <div v-for="score in getScores">
                    <v-list-item v-for="score in parseScores" :key="score">
                        <v-list-item-content >
                            <v-list-item-title>{{ score }}</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </div>
            </v-list>
        </v-card-text>
        <v-card-actions>
            <v-btn @click="router.push('/')">Back</v-btn>
        </v-card-actions>
    </v-card>
</template>

<script setup lang="ts">
import Axios from "axios" //npm install axios 
import { s } from "vitest/dist/reporters-P7C2ytIv";
const router = useRouter();

onMounted(() => {
    if (
        window.location.hostname === "localhost" ||
        window.location.hostname === "127.0.0.1"
    ) {
        Axios.defaults.baseURL = "https://localhost:7266/";
    } else {
        Axios.defaults.baseURL = "https://wordleapiewu.azurewebsites.net/";
    }
})

async function getScores() {
    let scoreUrl = "Score/LeaderBoard";
    const response = await Axios.get(scoreUrl);
    console.log( "response from api " + response.data);
    return response.data;
}
function parseScores(scores: any) {
        const splitScores = scores.split("\n")
        return splitScores;
}


</script>