<template>
    <v-container>
        <v-card color="secondary"
                class="mx-auto mt-8 w-75 pa-8 rounded text-center"
                elevation="4">
            <v-card-title class="text-h3 mb-3 animate__animated animate__tada "> Leaderboard </v-card-title>

            <v-card-text>
            </v-card-text>
            <v-spacer />
            <v-card-actions class="d-flex justify-center">
                <v-btn color="white"
                       class="bg-primary pa-2 px-5"
                       to="/"
                       text="Go Home" />
            </v-card-actions>
        </v-card>
    </v-container>
</template>
<script setup lang="ts">
import 'animate.css';
</script>