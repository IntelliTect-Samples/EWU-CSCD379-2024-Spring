<template>
  <v-container>
    <v-row justify="center" v-for="(guess, i) in game.maxAttempts" :key="i">
      <GameboardLetter
        v-for="(letter, j) in game.wordToGuess.length"
        :key="j"
        :letter="getGuess(i, j)"
      />
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { Game } from "~/scripts/game";
import GameboardLetter from "./GameboardLetter.vue";
import { Letter } from "~/scripts/letter";

const props = defineProps<{
  game: Game;
  guess: string;
}>();

function getGuess(i: number, j: number): Letter {
  if (i < props.game.guesses.length) {
    return props.game.guesses[i].letters[j];
  } else if (i === props.game.guesses.length) {
    return new Letter(props.guess.charAt(j));
  } else {
    return new Letter("");
  }
}
</script>
