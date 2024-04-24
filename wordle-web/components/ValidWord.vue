<!--create an object that shows a list of valid words from the avalible guesses using ValidWordList-->
<template>
    <v-menu>
        <template v-slot:activator="{ props }">
            <v-btn v-bind="props" >
                available words
            </v-btn>
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
import { Letter } from "~/scripts/letter";


const game: Game | undefined = inject("GAME", undefined);
const validWords = computed(() => {
    return game ? findValidWords(game) : [];
});
function setGuess(word: string) {
    game?.guess.clear();

    word = word.toUpperCase();
    for (let letter of word) {
        game?.guess.addLetter(letter);
    }
}

</script>