<template>
  <v-container>
    <v-card class="text-center" elevation="0">
      <v-sheet> <v-card-title>Name:</v-card-title> </v-sheet>
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

      <div class="mt-10">
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
          showDialog = !showDialog;
          playAudio();
        "
        >{{ validWordsCount }} possible words!</v-btn
      >
      <ValidWords
        v-model:show="showDialog"
        v-model:validWordsCount="validWordsCount"
        :game="game"
        @chooseWord="word => selectWord(word)" />
      <NameDialog v-model:show="nameDialog" v-model:name="name"></NameDialog>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from '../scripts/game';
import { myWordList } from '~/scripts/wordList';
const game: Game = reactive(new Game());
provide('GAME', game);
const showDialog = ref(false);
const validWordsCount = ref(myWordList.length);
const name = ref('');
const nameDialog = ref(name.value === '');

const myGuess = ref('');
console.log(game.secretWord);
function playAudio(): any {
  const audio = new Audio('/clicker.mp3');
  audio.volume = 0.9;
  audio.play();
}
onMounted(() => {
  window.addEventListener('keyup', onKeyup);
});

onUnmounted(() => {
  window.removeEventListener('keyup', onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  // client side error: Uncaught (in promise) TypeError: Cannot read properties of null (reading 'parentNode')
  // if (!nameDialog.value) {
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
  // }
  // else {
  //   if (event.key === 'Enter') {
  //     nameDialog.value = false;
  //   }
  // }
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
</script>
