<template>
  <v-container class="myFontDefault">
    <v-card class="text-center">
      <v-alert v-if="game.gameState != GameState.Playing" :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5" tile >
        <div></div>
        <h3>
          You've
          {{ game.gameState == GameState.Won ? "Won" : "Lost" }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>
      <v-card-title v-else>Wordle</v-card-title>
      <GameBoardGuess v-for="(guess, i) of game.guesses" :key="i" :guess="guess"/>

      <h3>
        <ValidWord />
      </h3>
    
      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn @click="game.submitGuess()" class="mb-5" color="primary">
        Guess!
      </v-btn>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import { findValidWords } from "~/scripts/ValidWordList";
import Axios from "axios" //npm install axios 

const userName = inject("userName");
const game: Ref<Game> = ref(new Game("GAMES"));
provide("GAME", game.value);
const myGuess = ref("");
const showUserNameDialog = inject("showUserNameDialog");
const validWords = computed(() => {
  return findValidWords(game.value);
});


onMounted(() => {
  // Get random word from word list
  getWordFromApi().then((word) => {
    game.value = new Game(word);
  });

  window.addEventListener("keyup", onKeyup);
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

async function getWordFromApi(): Promise<string> {
  let wordUrl = "Word/WordOfTheDay?offsetInHours=-27";

  const response = await Axios.get(wordUrl);
  console.log("Response from API : " + response.data);
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
function calcAttempts(){
  var attempts = 0;
  if(game.value.gameState == GameState.Won){
    attempts = game.value.guesses.length;
  }else{
    attempts = game.value.guesses.length + 5;
  }
  return attempts;
}
function postScore(playerNameIn: string, attemptsIn: number, timeIn: number){
  let postScoreUrl ="Score/UpdateScore";
  Axios.post(postScoreUrl, {
    playerName: playerNameIn,
    attempts: attemptsIn,
    time: timeIn
  }).then((response) => {
    console.log("response from api " + response.data);
  });
}
watch(() => game.value.gameState, (value) => {
  if(value == GameState.Won || value == GameState.Lost){
    if(userName === "guest"){
      //showUserNameDialog.value = true;
    }
    postScore(userName as string, calcAttempts(), 0);
  }
});
</script>
