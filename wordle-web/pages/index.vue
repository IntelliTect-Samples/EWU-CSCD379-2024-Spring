<template>
  <v-container> 
      <v-card class="text-center">
          <v-alert v-if="game.gameState != GameState.Playing"
                   :color="game.gameState == GameState.Won ? 'success' : 'error'"
                   class="mb-5"
                   tile>
              <h3>
                  You've
                  {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
              </h3>
              <v-card-text>
                  The word was: <strong>{{ game.secretWord }}</strong>
              </v-card-text>
              <v-btn variant="outlined" @click="game.startNewGame()">
                  <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
              </v-btn>
          </v-alert>
          <v-card-title v-else>Wordle</v-card-title>

          <GameBoardGuess v-for="(guess, i) of game.guesses"
                          :key="i"
                          :guess="guess" />

          <div class="my-10">
              <Keyboard />
          </div>

          <v-btn @click="game.submitGuess()" class="mb-5" color="primary">
              Guess!
          </v-btn>

          <v-btn @click="
          $router.push('/leaderboard');"
                 class="mb-5 mx-5"
                 color="primary">
              Leaderboard
          </v-btn>
      </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { Game, GameState } from "../scripts/game";
import Axios from "axios";


const api = ''

const game: Ref<Game> = ref(new Game(""));
// Get random word from word list
getWordFromApi().then((word) => {
  game.value = new Game(word);
});

provide("GAME", game.value);

const myGuess = ref("");

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

async function getWordFromApi(): Promise<string> {
  let wordUrl = "https://wordleapiewu.azurewebsites.net/word";

  const response = await Axios.get(wordUrl);
  console.log("Response from API: " + response.data);
  return response.data;
}

function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    game.value?.submitGuess();
  } else if (event.key == "Backspace") {
    game.value?.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    game.value?.addLetter(event.key.toUpperCase());
  }
    }

    function postScore() {
        let attempts = 0;
        if (game.value.gameState == GameState.Won) {
            attempts = game.value.guessIndex + 1;
        } else {
            attempts = game.value.maxAttempts;
        }
        Axios.post(apiUrl + '/leaderboard/postscore', {
            Name: nuxtStorage.localStorage.get("userName", userName.value),
            GameCount: 1,
            AverageAttempts: attempts,
        });
    }


</script>

<style scoped>


</style>
