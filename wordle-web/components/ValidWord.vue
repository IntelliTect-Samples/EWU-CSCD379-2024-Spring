<!--create an object that shows a list of valid words from the avalible guesses using ValidWordList-->
<template>
    <v-menu>
        <template v-slot:activator="{ props }">
            <v-btn v-bind="props" > available words: {{ validWords.length }}</v-btn>
        </template>
        <v-list>
            <v-list-item v-for="word in validWords" :key="word" @click="setGuess(word)">
                <v-list-item-title>{{ word }}</v-list-item-title>
            </v-list-item>
        </v-list>
    </v-menu>
</template>

<script setup lang="ts">
import { Game } from "~/scripts/game";
import { findValidWords } from "~/scripts/ValidWordList";

const gameRef: Ref<Game> = inject("GAME") as Ref<Game>;
const validWords = computed(() => {
    return gameRef.value ? findValidWords(gameRef.value) : [];
});
function setGuess(word: string) {
    gameRef.value?.guess.clear();

    word = word.toUpperCase();
    for (let letter of word) {
        gameRef.value?.guess.addLetter(letter);
    }
}

</script>