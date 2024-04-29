<template>
  <v-container>
    <v-card class="text-center" elevation="0">
      <v-sheet>
        <v-container height="150px">
          <v-sheet
            @click="showNameDialog = !showNameDialog"
            class="pa-2 mx-2 mt-2 cursor-pointer"
            color="secondary">
            {{ username }}
          </v-sheet>
        </v-container>
      </v-sheet>
      <v-alert
        v-if="game.gameState != GameState.Playing"
        :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5"
        tile>
        <h3>
          You've
          {{ game.gameState == GameState.Won ? 'Won! 🥳' : 'Lost... 😭' }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn variant="outlined" @click="game.startNewGame()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>

      <div class="mt-5">
        <GameBoardGuess
          v-for="(guess, i) of game.guesses"
          :key="i"
          :guess="guess" />
      </div>

      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn
        @click="
          game.submitGuess();
          playAudio();
        "
        class="mb-5"
        color="primary">
        Guess!
      </v-btn>
      <v-btn
        class="mb-5 ml-5"
        color="secondary"
        @click="
          showValidWordsDialog = !showValidWordsDialog;
          playAudio();
        "
        >{{ validWordsCount }} possible words!</v-btn
      >
      <ValidWords
        v-model:show="showValidWordsDialog"
        v-model:validWordsCount="validWordsCount"
        :game="game"
        @chooseWord="word => selectWord(word)" />
      <NameDialog
        v-model:show="showNameDialog"
        v-model:name="username"
        @entered="enterName" />
      <GuestSaveDialog
        v-model="showGuestSaveDialog"
        @saveGuestScore="postScore" />
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from '../scripts/game';
import { myWordList } from '~/scripts/wordList';
import nuxtStorage from 'nuxt-storage';
import axios from 'axios';

const game: Game = reactive(new Game());
provide('GAME', game);
const showValidWordsDialog = ref(false);
const validWordsCount = ref(myWordList.length);
const username = ref(' ');
const showNameDialog = ref(false);
const showGuestSaveDialog = ref(false);
const apiUrl = 'wordlewebapijoshua.azurewebsites.net';

const myGuess = ref('');
console.log(game.secretWord);
function playAudio(): any {
  const audio = new Audio('/clicker.mp3');
  audio.volume = 0.9;
  audio.play();
}
onMounted(() => {
  window.addEventListener('keyup', onKeyup);
  var defaultName = nuxtStorage.localStorage.getData('name');
  showNameDialog.value = defaultName ? false : true;
  username.value = showNameDialog.value ? 'Guest' : defaultName;
});

onUnmounted(() => {
  window.removeEventListener('keyup', onKeyup);
});

watch(
  () => game.gameState,
  () => {
    if (game.gameState == GameState.Won || game.gameState == GameState.Lost) {
      if (username.value === 'Guest') {
        showGuestSaveDialog.value = true;
      } else {
        postScore();
      }
    }
  }
);

function onKeyup(event: KeyboardEvent) {
  // Check if text field automatically listens for 'Enter'
  if (showNameDialog.value) {
    if (event.key === 'Enter') {
      enterName();
    }
  } else {
    if (event.key === 'Enter') {
      playAudio();
      game.submitGuess();
    } else if (event.key == 'Backspace') {
      playAudio();
      game.removeLastLetter();
    } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
      playAudio();
      game.addLetter(event.key.toUpperCase());
    }
  }
}

function selectWord(selected: string) {
  game.guess.clear();
  myGuess.value = '';
  selected.split('').forEach(character => {
    character = character.toUpperCase();
    game.addLetter(character);
    myGuess.value += character;
  });
}

function enterName() {
  if (username.value === '') {
    console.log('hello');
    username.value = 'Guest';
  } else {
    nuxtStorage.localStorage.setData('name', username.value);
  }
  showNameDialog.value = !showNameDialog.value;
}

function postScore() {
  let attempts = 0;
  if (game.gameState == GameState.Won) {
    attempts = game.guessIndex + 1;
  } else {
    attempts = game.maxAttempts;
  }
  axios.post(apiUrl, {
    Name: username.value,
    GameCount: 1,
    Attempts: attempts,
  });
}
</script>
