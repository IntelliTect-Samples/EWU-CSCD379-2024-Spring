<template>
    <v-row v-for="(keyboardRow, rowIndex) in keyboardKeys" :key="rowIndex" dense>
        <v-col v-for="key in keyboardRow" :key="key">
            <v-btn>
                {{ key }}
            </v-btn>
        </v-col>
    </v-row>
</template>

<script setup lang="ts">
const keyboardKeys = [
    ["Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P"],
    ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
    ["Z", "X", "C", "V", "B", "N", "M", "ENTER"]
]
</script>