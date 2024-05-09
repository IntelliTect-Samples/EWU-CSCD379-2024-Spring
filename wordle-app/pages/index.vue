<template>
  <v-container>
    <<v-progress-linear
      v-if="game.gameState === GameState.Initializing"
      color="primary"
      indeterminate
    />
    <v-card v-else class="text-center">
      <v-alert v-if="game.gameState != GameState.Playing" :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5" tile>
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

      <v-card-text class="d-flex  flex-row justify-end">
        <v-chip color="secondary" class="mr-2" @click="showUserNameDialog=true">
          <v-icon class="mr-2" > mdi-account </v-icon> {{ nameUserNameDialog }}
        </v-chip>
        <v-chip color="secondary" class="mr-2">
          <v-icon class="mr-2"> mdi-timer </v-icon> 5s
        </v-chip>
      </v-card-text>

      <GameBoardGuess v-for="(guess, i) of game.guesses" :key="i" :guess="guess" />

      <div class="my-10">
        <Keyboard />
      </div>

      <WordList v-if="game.gameState === GameState.Playing" v-model="showWordsList" />

      <v-row justify="end">
        <v-col cols="6">
          <v-btn @click="game.submitGuess()" class="mb-5" color="primary">
        Guess!
      </v-btn>
        </v-col >
        <v-col cols="3">
          <v-btn class="mb-5" color="primary" @click="router.push('/Leaderboard')">Leaderboard</v-btn>
        </v-col>
      </v-row>
    </v-card>

    <UserNameDialog v-model:show="showUserNameDialog" v-model:userName="nameUserNameDialog" />
    
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import nuxtStorage from "nuxt-storage";
import Axios from 'axios'
import type { Player } from "../scripts/player";
import { useStopwatch } from 'vue-timer-hook';

const router = useRouter();
const game = reactive(new Game());
game.startNewGame();
provide("GAME", game);
// const game: Ref<Game> = ref(new Game("GAMES"));
// provide("GAME", game.value);

// User name dialog
const showUserNameDialog = ref(false);
const nameUserNameDialog = ref("");

var showWordsList = ref(false);

onMounted(() => {
  // if (window.location.hostname === "localhost" || window.location.hostname === "127.0.0.1") {
  //   Axios.defaults.baseURL = "https://localhost:7108/";
  // } else {
  //   Axios.defaults.baseURL = "https://wordleapiewu.azurewebsites.net/";
  // }
  

  // Get random word from word list
  getWordFromApi().then((word) => {
    game.value = new Game(word);
  })

  window.addEventListener("keyup", onKeyup);


  // Assignment 3 Task 2
  // Check if user name is stored in local storage
  checkUserNameLocalStorage();
  checkUserName();

  
  
});


onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

async function getWordFromApi(): Promise<string> {
  // const { data: word } = await useFetch("https://wordleapiewusergeitim.azurewebsites.net/word");
  //let wordUrl = "https://wordleapiewusergeitim.azurewebsites.net/word";
  let wordUrl = "word/wordOfTheDay";
  const response = await Axios.get(wordUrl);
  console.log("Secret word from API: " + response.data);
  return response.data;
}

function onKeyup(event: KeyboardEvent) {
  if (!showUserNameDialog.value) {
    if (event.key === "Enter") {
      game.submitGuess();
    } else if (event.key == "Backspace") {
      game.removeLastLetter();
    } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
      game.addLetter(event.key.toUpperCase());
    }
  }

}

async function checkUserNameLocalStorage() {
  
  if(nuxtStorage.localStorage.getData("userName") != null){
    nameUserNameDialog.value = nuxtStorage.localStorage.getData("userName");
    showUserNameDialog.value = false;
  }
  else {
    nameUserNameDialog.value = "Guest";
    showUserNameDialog.value = true;
  }

}

async function checkUserName() {
  const response = await Axios.get("player/checkUserName/" + nameUserNameDialog.value);
  console.log("Check user name response: " + response.data);
}

</script>
