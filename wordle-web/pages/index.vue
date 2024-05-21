<template>
  <v-container>
    <v-progress-linear v-if="game.isBusy" color="primary" indeterminate />
    <v-card v-else class="text-center">
      <v-alert
        v-if="game.gameState != GameState.Playing"
        :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5"
        tile
      >
        <h3>
          You've
          {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-row v-if="game.stats" class="mb-1" justify="center">
          <v-col cols="auto">
            <v-progress-circular
              size="75"
              width="10"
              v-model="game.stats.winPercentage"
            >
              {{ game.stats.winPercentage }} %
            </v-progress-circular>
            <br />
            <i class="text-caption"> Success Rate </i>
          </v-col>
          <v-col cols="auto">
            <v-progress-circular
              size="75"
              width="10"
              :model-value="game.stats.averageGuessesPercent(game.maxAttempts)"
            >
              {{
                game.stats.averageGuessesPercent(game.maxAttempts).toFixed(0)
              }}
              %
            </v-progress-circular>
            <br />
            <i class="text-caption"> Average Guesses </i>
          </v-col>
        </v-row>
        <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>
      <v-card-title v-else>Wordle</v-card-title>

      <GameBoardGuess
        v-for="(guess, i) of game.guesses"
        :key="i"
        :guess="guess"
      />

      <div class="my-10">
        <Keyboard />
      </div>

      <div class="mb-5">
        <v-btn @click="game.submitGuess()" class="mb-5" color="primary">
          Guess!
        </v-btn>
        <br />
        <v-btn @click="hint" color="primary"> Hint! 👀 </v-btn>
      </div>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import axios from "axios";
import TokenService from "~/scripts/TokenService";
import { Game, GameState } from "../scripts/game";

const game = reactive(new Game());
game.startNewGame();
provide("GAME", game);

const myGuess = ref("");
const tokenService = new TokenService();

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    game.submitGuess();
  } else if (event.key == "Backspace") {
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    game.addLetter(event.key.toUpperCase());
  }
}

function hint() {
  const headers = tokenService.generateTokenHeader();
  console.log(headers);
  axios.get("Word/WordOfTheDayHint", { headers }).then((response) => {
    alert(`Hint: ${response.data}`);
  });
}
</script>
