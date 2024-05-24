<template>
   <HelpDialog v-model="showHelpDialog" />
  <v-btn icon="mdi-help-box" @click="showHelpDialog = true" />
  <v-card class="text-center">
    <v-alert v-if="game.gameState != GameState.Playing" :color="game.gameState == GameState.Won ? 'success' : 'error'"
      class="mb-5" tile>
      <div></div>
      <h3>
        You've
        {{ game.gameState == GameState.Won ? "Won" : "Lost" }}
      </h3>
      <v-card-text>
        The word was: <strong>{{ game.secretWord }}</strong>
      </v-card-text>
      <v-btn variant="outlined" @click="game.startNewGameRandom()">
        <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
      </v-btn>
    </v-alert>
    <v-card-title>Never Ending Wordle</v-card-title>
    <v-card-subtitle>Practice your wordle skills with a different word each time!</v-card-subtitle>

    <GameBoardGuess v-for="(guess, i) of game.guesses" :key="i" :guess="guess" />

    <div class="my-10">
      <Keyboard />
    </div>

    <div class="my-5">
      <ValidWord />
    </div>

    <v-btn @click="game.submitGuess(false, '' )" class="mb-5" color="primary">Guess!</v-btn>

    <v-btn class="mb-5 ml-5" color="primary" variant="flat" @click="router.push('/leaderboard')">Leaderboard</v-btn>
  </v-card>

</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";

const showHelpDialog = ref(false);
const router = useRouter();
const game = reactive(new Game());
game.startNewGameRandom();
provide("GAME", game);

const showUserNameDialog = ref(false);

onMounted(() => {
  // Get random word from word list
  

  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});
function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    game.submitGuess(false,"" );
  } else if (event.key == "Backspace") {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    game.addLetter(event.key.toUpperCase());
  }

}

</script>
