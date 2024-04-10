<template>
  <v-container class="w-75">
    <v-row justify="center" v-for="(guess, i) in game.maxAttempts" :key="i">
      <v-col
        cols="1"
        class="bg-pink-lighten-2 ma-1 rounded-lg"
        v-for="(letter, j) in game.wordToGuess.length"
        :key="j"
      >
        {{ getGuess(i, j) }}
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped>
.v-col {
  height: 75px;
  width: 75px;
}
</style>

<script setup lang="ts">
import { Game } from "~/scripts/game";

const props = defineProps<{
  game: Game;
  guess: string;
}>();

function getGuess(i: number, j: number) {
  if (i < props.game.guesses.length) {
    return props.game.guesses[i].letters[j].char;
  } else if (i === props.game.guesses.length) {
    return props.guess.charAt(j);
  } else {
    return "";
  }
}
</script>
