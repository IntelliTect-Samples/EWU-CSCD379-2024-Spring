<template>
    <!--create a leader board that shows top scores-->
    <v-card>
        <v-card-title class = "text-center">Leader Board</v-card-title>
        <v-card-text>
            <v-list>
                <v-list-item v-for="score in scores" :key="score.id">
                    <v-list-item-title>{{ score.userName }}</v-list-item-title>
                    <v-list-item-subtitle>{{ score.score }}</v-list-item-subtitle>
                </v-list-item>
            </v-list>
        </v-card-text>
        <v-card-actions>
            <v-btn @click="router.push('/')">Back</v-btn>
        </v-card-actions>
    </v-card>
</template>

<script setup lang="ts">
import Axios from "axios" //npm install axios 
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
    const response = await Axios.get("/api/leaderboard");
    return response.data;
}


</script>