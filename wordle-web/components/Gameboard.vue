<template>
  <v-container>
    <GameboardGuess
      v-for="(guess, i) in game.maxAttempts"
      :guess="getGuess(i)"
      :key="i"
    />
  </v-container>
</template>

<script setup lang="ts">
import { Game } from "~/scripts/game";
import { Word } from "~/scripts/word";
const props = defineProps<{
  game: Game;
  guess: string;
}>();

function getGuess(i: number): Word {
  if (i > props.game.guesses.length) {
    return new Word("");
  } else if (i === props.game.guesses.length) {
    return new Word(props.guess);
  } else {
    return props.game.guesses[i];
  }
}
</script>
