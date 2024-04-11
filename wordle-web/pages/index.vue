<template>
  <v-container>
    <v-card>
      <v-card-title>Wordle</v-card-title>

      <GameBoardGuess
        v-for="(guess, i) of game.guesses"
        :key="i"
        :guess="guess"
      />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game } from "../scripts/game";
const game: Game = reactive(new Game("JUMBO"));

const myGuess = ref("");

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if(event.key === "Enter") {
    game.submitGuess();
  } else if(event.key == 'Backspace'){
    game.removeLastLetter();
  } else if(event.key.match(/[A-z]/)){
    game.addLetter(event.key.toUpperCase());
  }
}
</script>

