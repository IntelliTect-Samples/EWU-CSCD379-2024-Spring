<template>
  <v-container>
    <v-card class="mx-auto w-100">
      <v-card-item class="text-center">
        <v-card-title>Whurdle</v-card-title>
      </v-card-item>
      <v-container class="text-center">
        <GameBoardGuess
          v-for="(guess, i) of game.guesses"
          :key="i"
          :guess="guess" />

        <Keyboard />
      </v-container>

      <v-card-actions>
        <v-spacer />
        <v-btn
          v-if="game.gameState !== GameState.Playing"
          variant="tonal"
          color="red"
          @click="game.startNewGame()">
          Restart Game
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from '../scripts/game';
const game: Game = reactive(new Game());

const myGuess = ref('');

onMounted(() => {
  window.addEventListener('keyup', onKeyup);
});

onUnmounted(() => {
  window.removeEventListener('keyup', onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === 'Enter') {
    game.submitGuess();
  } else if (event.key == 'Backspace') {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/)) {
    game.addLetter(event.key.toUpperCase());
  }
}
</script>
