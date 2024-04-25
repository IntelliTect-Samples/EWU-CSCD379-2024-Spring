<template>
  <v-container>
    <v-card class="text-center" elevation="0">
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
