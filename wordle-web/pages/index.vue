<template>
  <v-container>
    <v-dialog v-model="isGameOn" class="mx-auto" max-width="500">
      <v-card
        :color="game.gameState == GameState.Won ? 'win' : 'lose'"
        tile
        class="pa-5 text-center text-white"
        rounded
      >
        <v-card-title class="text-h4">
          You've
          {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
        </v-card-title>

        <v-card-text class="my-3">
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-card-actions class="mx-auto">
          <v-btn variant="outlined" @click="game.startNewGame()">
            <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Play Again
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <GameBoardGuess
      v-for="(guess, i) of game.guesses"
      :key="i"
      :guess="guess"
    />
    <div class="d-flex justify-center my-3">
      <v-btn
        v-if="game.gameState !== GameState.Playing"
        @click="isGameOn = true"
        color="primary"
        text="RESULTS"
        height="40px"
        width="120px"
      />
    </div>

    <Keyboard />

    <WordList
      v-if="game.gameState === GameState.Playing"
      v-model="showWordsList"
    />
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
const game: Game = reactive(new Game());
const showWordsList = ref(false);
const isGameOn = ref(false);

provide("GAME", game);
function playSound(): any {
  const audio = new Audio('/click.mp3');
  audio.volume = 0.9;
  audio.play();
}

function playSound2(): any {
  const audio = new Audio('/won.mp3');
  audio.volume = 0.9;
  audio.play();
}
function playSound3(): any {
  const audio = new Audio('/lose.mp3');
  audio.volume = 0.9;
  audio.play();
}
onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (showWordsList.value) {
    return;
  }

  if (event.key === "Enter") {
    game.submitGuess();
  } else if (event.key == "Backspace") {
    playSound();
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    playSound();
    game.addLetter(event.key.toUpperCase());

  }
}

watch(game, () => {
  if (game.gameState !== GameState.Playing) {
    isGameOn.value = true;
  } else {
    isGameOn.value = false;
  }
});
watch(() => game.gameState, (newState) => {
  if (newState === GameState.Won) {
    playSound2(); 
    isGameOn.value = true;
  } else if (newState === GameState.Lost) {
    playSound3(); 
    isGameOn.value = true;
  } else if (newState === GameState.Playing) {
    isGameOn.value = false;
  }
});
</script>
