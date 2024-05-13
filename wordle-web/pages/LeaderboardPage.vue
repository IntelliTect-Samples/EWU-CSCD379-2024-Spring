<template>
    <v-card class="my-7 mx-auto w-75">
        <v-sheet color="secondary">
            <v-card-title>Leaderboard</v-card-title>
        </v-sheet>
        <v-table class="table mt-7 mx-auto w-75">
            <thead>
                <tr>
                    <th class="text-h6 text-center Name"><strong>Player Name</strong></th>
                    <th class="text-h6 text-center GameCount"><strong>Game Count</strong></th>
                    <th class="text-center text-h6 AverageAttempts"><strong>Average Guesses</strong></th>
                </tr>
            </thead>
            <transition-group name="fade" tag="tbody">
                <tr v-for="player in topTenScores" :key="player.name" class="table-row">
                    <td class="text-center">{{ player.name }}</td>
                    <td class="text-center">{{ player.gameCount }}</td>
                    <td class="text-center">{{ player.averageAttempts }}</td>
                </tr>
            </transition-group>
        </v-table>
        <v-container class="text-center">
            <v-btn color="secondary" class="mb-5" @click="$router.push('/')">Home</v-btn>
        </v-container>
    </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Axios from 'axios';
interface Player {
    name: string;
    gameCount: number;
    averageAttempts: number;
}

const topTenScores = ref<Player[]>([]);

// Fetch the top ten scores from the leaderboard API
Axios.get('/api/leaderboard')
    .then(response => {
        topTenScores.value = response.data;
    })
    .catch(error => {
        console.error('Failed to fetch leaderboard:', error);
    });
</script>

<style scoped>
.fade-enter-active, .fade-leave-active {
    transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active in <2.1.8 */ {
    opacity: 0;
}
.table-row {
    transition: transform 0.3s ease-in-out;
}
.table-row:hover {
    transform: scale(1.03);
    background-color: #f4f4f4; /* Light grey background on hover */
}
</style>
