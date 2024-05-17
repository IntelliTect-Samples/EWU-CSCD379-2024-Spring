<template>
  <v-container>
    <v-progress-linear v-if="game.isBusy" color="primary" indeterminate />
    <v-card v-else class="text-center" elevation="0">
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
        <v-row v-if="game.stats" class="mb-1" justify="center">
          <v-col cols="auto">
            <v-progress-circular
              size="75"
              width="10"
              v-model="game.stats.winPercentage">
              {{ game.stats.winPercentage }} %
            </v-progress-circular>
            <br />
            <i class="text-caption"> Success Rate </i>
          </v-col>
          <v-col cols="auto">
            <v-progress-circular
              size="75"
              width="10"
              :model-value="game.stats.averageGuessesPercent(game.maxAttempts)">
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
      <v-btn
        @click="
          $router.push('/leaderboard');
          playAudio();
        "
        class="mb-5 mx-5"
        color="primary">
        Leaderboard
      </v-btn>
      <v-chip class="mb-5" color="secondary">{{ seconds }}</v-chip>
      <ValidWords
        v-model:show="showValidWordsDialog"
        v-model:validWordsCount="validWordsCount"
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
import { Game, GameState, GameOption } from '../scripts/game';
import { WordList } from '~/scripts/wordList';
import nuxtStorage from 'nuxt-storage';
import Axios from 'axios';

const props = defineProps<{ option: GameOption; word?: string }>();
const game = reactive(new Game(props.option));
game.startNewGame(props.word);
provide('GAME', game);
const showValidWordsDialog = ref(false);
const validWordsCount = ref(WordList.length);
const username = ref(' ');
const showNameDialog = ref(false);
const showGuestSaveDialog = ref(false);
const seconds = ref(0);
const interval = ref();

function startSeconds() {
  interval.value = setInterval(() => {
    seconds.value++;
  }, 1000);
}

function stopSeconds() {
  if (interval.value) {
    clearInterval(interval.value);
  }
}

const myGuess = ref('');
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
  startSeconds();
});

onUnmounted(() => {
  window.removeEventListener('keyup', onKeyup);
});

watch(
  () => game.gameState,
  () => {
    if (game.gameState == GameState.Won || game.gameState == GameState.Lost) {
      stopSeconds();
      game.seconds = seconds.value;
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
  Axios.post('/leaderboard/postscore', {
    Name: username.value,
    GameCount: 1,
    AverageAttempts: attempts,
    AverageSeconds: seconds.value,
  });
}
</script>
