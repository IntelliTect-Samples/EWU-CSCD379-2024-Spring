<template>
  <v-container height="150px">
    <v-sheet
      @click="dialogBox = !dialogBox"
      class="pa-2 mx-2 mt-2 cursor-pointer"
      color="secondary"
    >
      <v-card-subtitle
        :class="{ animated: timerRunning }"
        style="font-size: xx-large; align-self: start; font-style: oblique"
        color="primary"
        >Welcome, {{ userName }}</v-card-subtitle
      >
    </v-sheet>
  </v-container>

  <v-container>
    <!-- Timer Box -->
    <v-container class="timer-container">
      <v-card class="timer-box" max-width="250" outlined color="secondary">
        <v-card-title class="subtitle-1">Time: </v-card-title>
        <v-card-text :class="{ animated: timerRunning }">{{
          elapsedTime
        }}</v-card-text>
      </v-card>
    </v-container>

    <v-card class="text-center" color="secondary">
      <v-alert
        v-if="game.gameState != GameState.Playing"
        :color="game.gameState == GameState.Won ? 'success' : 'error'"
        class="mb-5"
        tile
      >
        <h3>
          You've
          {{ game.gameState == GameState.Won ? "Won! 🥳" : "Lost... 😭" }}
          {{ stopTimerOnGameEnd() }}
        </h3>
        <v-card-text>
          The word was: <strong>{{ game.secretWord }}</strong>
        </v-card-text>
        <v-btn variant="outlined" @click="game.startNewGame(), startTimer()">
          <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart Game
        </v-btn>
      </v-alert>
      <v-card-title v-else style="font-size: xx-large">Wordle</v-card-title>

      <GameBoardGuess
        v-for="(guess, i) of game.guesses"
        :key="i"
        :guess="guess"
      />

      <div class="my-10">
        <Keyboard />
      </div>

      <v-btn
        @click="game.submitGuess()"
        class="mb-5"
        elevation="5"
        color="primary"
      >
        Guess!
      </v-btn>
    </v-card>
    <v-card color="primary" dark>
      <v-container>
        <ValidGuess
          v-model="engine"
          :game="game"
          @chooseWord="(word) => selectWord(word)"
        />
      </v-container>
    </v-card>
  </v-container>

  <v-dialog v-model="dialogBox" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary">
        <v-card-text>Enter your UserName: </v-card-text>
      </v-sheet>
      <v-form class="mx-3 mt-5">
        <v-text-field
          @keyup.stop
          v-model="usersNameInput"
          label="user"
          variant="outlined"
          clearable
          required
          @keydown.enter
          @keydown.enter.prevent
        >
        </v-text-field>
      </v-form>
      <v-card-actions class="mx-4 mb-3">
        <v-spacer></v-spacer>
        <v-btn color="success" @click="saveUserName">SAVE</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import { provide, ref } from "vue";
const game: Game = reactive(new Game());
import nuxtStorage from "nuxt-storage";

provide("GAME", game);

const myGuess = ref("");
const engine = ref(false);
const dialogBox = ref<boolean>(true);

const usersNameInput = ref<string>(
  nuxtStorage.localStorage.getData("userName") ?? ""
); // ref<string>("");
const userName = ref<string>(usersNameInput.value.trim() || "GUEST"); // ref(nuxtStorage.localStorage.getData("userName") ?? "");

let startTime: number | null = null;
let timerInterval: NodeJS.Timeout | null = null;
var elapsedTime = ref("00:00");

function enterSound() {
  var sound = new Audio("/click.mp3");
  sound.play();
}

function backspaceSound() {
  var sound = new Audio("/backspace.mp3");
  sound.play();
}

function clickSound() {
  var sound = new Audio("/clicking.mp3");
  sound.play();
}

onMounted(() => {
  window.addEventListener("keyup", onKeyup);
  const savedUserName = nuxtStorage.localStorage.getData("userName");
  if (savedUserName) {
    dialogBox.value = false; // Close the dialog if a username is already saved
  }
  startTimer();
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (event.key === "Enter") {
    enterSound();
    game.submitGuess();
  } else if (event.key == "Backspace") {
    backspaceSound();
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    clickSound();
    game.addLetter(event.key.toUpperCase());
  }
}

function saveUserName() {
  const name = usersNameInput.value.trim();
  if (name === "") {
    userName.value = "GUEST";
  } else {
    userName.value = name;
    nuxtStorage.localStorage.setData("userName", userName.value);
  }
  dialogBox.value = false;
}
function openNameDialog() {
  dialogBox.value = true;
}

function updateUserName() {
  if (usersNameInput.value.trim() !== "") {
    saveUserName();
  }
}

function startTimer() {
  startTime = Date.now();
  timerInterval = setInterval(updateTimer, 1000);
}
function stopTimerOnGameEnd() {
  if (game.gameState == GameState.Won || game.gameState == GameState.Lost) {
    stopTimer();
  }
}
function stopTimer() {
  if (startTime !== null && timerInterval !== null) {
    clearInterval(timerInterval);
    timerInterval = null;
    const elapsedTimeInSeconds = Math.round((Date.now() - startTime) / 1000);
    elapsedTime.value = formatTime(elapsedTimeInSeconds);
    saveScoreAndTime(elapsedTimeInSeconds);
  }
}

function updateTimer() {
  if (startTime !== null) {
    const elapsedTimeInSeconds = Math.round((Date.now() - startTime) / 1000);
    elapsedTime.value = formatTime(elapsedTimeInSeconds);
  }
}

function formatTime(timeInSeconds: number): string {
  const minutes = Math.floor(timeInSeconds / 60);
  const seconds = timeInSeconds % 60;
  return `${minutes < 10 ? "0" + minutes : minutes}:${
    seconds < 10 ? "0" + seconds : seconds
  }`;
}

function saveScoreAndTime(timeInSeconds: number) {
  const score = 1; // game.getScore();
  if (userName.value === "GUEST") {
    nuxtStorage.localStorage.setData("guestScore", score);
    nuxtStorage.localStorage.setData("guestTimeInSeconds", timeInSeconds);
  } else {
    nuxtStorage.localStorage.setData(`${userName.value}-score`, score);
    nuxtStorage.localStorage.setData(
      `${userName.value}-timeInSeconds`,
      timeInSeconds
    );
  }
}
const timerRunning = ref(false);

// Determine when the timer should be running based on game state
watchEffect(() => {
  timerRunning.value = game.gameState === GameState.Playing;
});
</script>

<style scoped>
/* Container for the timer */
.timer-container {
  position: fixed;
  top: 180px;
  right: -800px;
  z-index: 1000;
}

/* Styling for the timer box */
.timer-box {
  display: flex;
  align-items: first baseline;
  justify-content: center;
  width: 150px; /* Adjust as needed */
  height: 50px; /* Adjust as needed */
  background-color: #4caf50;
  color: white;
  font-size: 30px;
  font-weight: bold;
  border-radius: 25px; /* Half of the height for a perfect circle */
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
  transition: background-color 0.3s, transform 0.5s ease-in-out; /* Smooth transitions */
}

/* Animation for the timer box when running */
.timer-box--running {
  animation: pulse 1s infinite alternate;
}

/* Additional animation for rotating */
.animated {
  animation: pulse 5s linear infinite;
}

/* Pulse animation */
@keyframes pulse {
  0% {
    transform: scale(1);
  }
  25% {
    transform: scale(-1.2);
  }
  50% {
    transform: scale(1.3);
  }
  100% {
    transform: scale(1.1);
  }
  110% {
    transform: scale(1);
  }
}

/* Rotation animation */
@keyframes rotate {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
