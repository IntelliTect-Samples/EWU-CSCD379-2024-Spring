<template>
    <v-card class="my-7 mx-auto w-75">
        <v-sheet color="secondary">
            <v-card-title>Leaderboard</v-card-title>
        </v-sheet>
        <v-table class="table mt-7 mx-auto w-75">
            <thead>
                <tr>
                    <th class="text-h6 text-center Name"><strong>Player Name</strong></th>
                    <th class="text-h6 text-center GameCount">
                        <strong>Game Count</strong>
                    </th>
                    <th class="text-center text-h6 AverageAttempts">
                        <strong>Average Guesses</strong>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="player in topTenScores" :key="player.name">
                    <td class="text-center">{{ player.name }}</td>
                    <td class="text-center">{{ player.gameCount }}</td>
                    <td class="text-center">{{ player.averageAttempts }}</td>
                </tr>
            </tbody>
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
    const topTenScores = ref<Player[]>();
    //need to make GET request to the server to get the leaderboard data
    Axios.get('/leaderboard/GetScores')
        .then(response => {
            topTenScores.value = response.data;
        })
        .catch(error => {
            console.log(error);
        });
    //note to self need to implement animate.css for the leaderboard extra credit
</script>