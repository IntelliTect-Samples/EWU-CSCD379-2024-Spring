<template>
  <v-container class="mt-2">
    <v-progress-linear
      v-if="game.gameState === GameState.Initializing"
      color="primary"
      indeterminate
    />
    <v-sheet v-else color="transparent">
      <div
        v-if="isDaily"
        class="font-text text-center text-wrap text-white font-weight-bold mb-3"
      >
        Daily Wordle: {{ formattedDate }}
      </div>
      <div
        v-else
        class="font-text text-center text-wrap text-white font-weight-bold mb-3"
      >
        Random Wordle
      </div>
      <v-row>
        <v-col lg="4" cols="1">
          <v-sheet
            v-if="$vuetify.display.smAndDown"
            class="position-fixed left-0 pa-1 rounded-e-lg bg-primary elevation-4"
            width="60"
          >
            <v-icon size="small" icon="mdi-timer" />
            {{ stopwatch.getCurrentTime() }}
          </v-sheet>
        </v-col>
        <v-col lg="4" cols="10" class="mb-3">
          <GameBoardGuess
            v-for="(guess, i) of game.guesses"
            :key="i"
            :guess="guess"
          />
        </v-col>
        <v-col lg="4" cols="1" v-if="$vuetify.display.mdAndUp" class="my-3">
          <v-row class="mb-1 justify-center">
            <v-tooltip :text="playerName" location="bottom">
              <template v-slot:activator="{ props }">
                <v-sheet
                  class="pa-2 cursor-pointer text-no-wrap"
                  color="primary"
                  rounded
                  v-ripple
                  width="200px"
                  height="40px"
                  elevation="4"
                  v-bind="props"
                  @click="showNameDialog = !showNameDialog"
                  style="white-space: nowrap"
                >
                  <v-icon icon="mdi-account" />
                  <strong>Username:</strong>
                  {{ truncate(playerName, 8, "...") }}
                </v-sheet>
              </template>
            </v-tooltip>
          </v-row>

          <v-row class="mb-1 justify-center">
            <v-sheet
              class="pa-2"
              color="primary"
              rounded
              elevation="4"
              min-width="200px"
              height="40px"
            >
              <v-icon icon="mdi-timer" />
              <strong> Current Time:</strong> {{ stopwatch.getCurrentTime() }}
            </v-sheet>
          </v-row>
          <v-row class="mb-1 justify-center">
            <v-sheet
              color="primary"
              min-width="200px"
              height="40px"
              v-ripple
              class="mx-auto pa-2 cursor-pointer"
              elevation="4"
              rounded
              @click="showWordsList = !showWordsList"
            >
              <v-icon icon="mdi-book" />

              <strong> Words List:</strong> {{ validWordsNum }}
            </v-sheet>
          </v-row>
          <v-row class="mb-1 justify-center">
            <v-sheet
              @click="isGameOver = true"
              color="primary"
              min-width="200px"
              height="40px"
              v-ripple
              class="mx-auto pa-2 cursor-pointer font-weight-bold"
              elevation="4"
              rounded
            >
              <v-icon icon="mdi-flag-variant" />
              {{ game.gameState === GameState.Playing ? "Give Up" : "Results" }}
            </v-sheet>
          </v-row>
        </v-col>
      </v-row>
      <v-bottom-navigation
        v-if="!$vuetify.display.mdAndUp"
        v-model="itemSelect"
        grow
      >
        <v-btn cols="5" value="showNameDialog">
          <v-icon icon="mdi-account" />
          {{ truncate(playerName, 8, "...") }}
        </v-btn>
        <v-btn value="showWordsList">
          <v-icon icon="mdi-book" />
          {{ validWordsNum }}
        </v-btn>

        <v-btn value="showResult">
          <v-icon icon="mdi-flag-variant" />
          {{ game.gameState === GameState.Playing ? "Give Up" : "Results" }}
        </v-btn>
      </v-bottom-navigation>

      <Keyboard />

      <v-dialog v-model="isGameOver" class="mx-auto" max-width="500">
        <v-card
          :color="gameStateColor"
          tile
          class="pa-5 text-center text-white"
          rounded
        >
          <v-card-title class="text-h5 text-wrap">
            {{ gameMessage }}
          </v-card-title>
          <v-card-text v-if="game.gameState !== GameState.Playing" class="my-3">
            The word was: <strong>{{ game.secretWord }}</strong>
          </v-card-text>
          <v-card-text v-else class="my-3">
            You still have <strong>{{ 6 - game.guessIndex }}</strong> attempts
            left..
          </v-card-text>
          <v-card-actions class="mx-auto">
            <v-btn variant="outlined" @click="closeGameDialog">
              <v-icon size="large" class="mr-2"> mdi-restart </v-icon> Restart
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <NameDialog v-model:show="showNameDialog" v-model:name="playerName" />
      <WordList v-model="showWordsList" @validWordsUpdate="captureValidWords" />
    </v-sheet>
  </v-container>
</template>

<script setup lang="ts">
import { Game, GameState } from "../scripts/game";
import { Stopwatch } from "~/scripts/stopwatch";
import nuxtStorage from "nuxt-storage";
import Axios from "axios";
import { addDays, format } from "date-fns";
import dateUtils from "~/scripts/dateUtils";
import {
  playClickSound,
  playEnterSound,
  playLoseSound,
  playWinSound,
} from "../scripts/soundUtils";

const truncate = (text: string, length: number, clamp: string) => {
  clamp = clamp || "...";
  const node = document.createElement("div");
  node.innerHTML = text;
  const content = node.textContent || "";
  return content.length > length
    ? content.substring(0, length) + clamp
    : content;
};

const props = withDefaults(
  defineProps<{
    isDaily: boolean;
  }>(),
  {
    isDaily: false,
  }
);

const route = useRoute();
const showWordsList = ref(false);
const isGameOver = ref(false);
const playerName = ref("");
const showNameDialog = ref(false);
const validWordsNum = ref(0);
const itemSelect = ref("");
const date = route.query.date?.toString();

watch(itemSelect, () => {
  if (itemSelect.value === "showNameDialog") {
    showNameDialog.value = true;
  } else if (itemSelect.value === "showWordsList") {
    showWordsList.value = true;
  } else if (itemSelect.value === "showResult") {
    isGameOver.value = true;
  }

  itemSelect.value = "";
});

const game = reactive(new Game());
provide("GAME", game);
const stopwatch = ref(new Stopwatch());

const captureValidWords = (num: number) => {
  validWordsNum.value = num;
};

const option = ref<string | null>();

game.startNewGame(date);

function closeGameDialog() {
  isGameOver.value = false;
  setTimeout(() => {
    game.startNewGame(date);
  }, 300);
  stopwatch.value.reset();
  stopwatch.value.start();
}

const gameMessage = computed(() => {
  switch (game.gameState) {
    case GameState.Won:
      return "Congratulations! You won! 🥳";
    case GameState.Lost:
      return "You lost! Better luck next time! 😭";
    default:
      return "Giving up already? 🤔";
  }
});

const gameStateColor = computed(() => {
  switch (game.gameState) {
    case GameState.Won:
      return "win";
    case GameState.Lost:
      return "lose";
    default:
      return "play";
  }
});

async function saveScore() {
  let scoreUrl = "player/saveScore";
  let data = {
    name: playerName.value,
    attempts: game.guessIndex + 1,
    seconds: stopwatch.value.getCurrentTime(),
  };
  await Axios.post(scoreUrl, data, {
    headers: { "Content-Type": "application/json" }, // config
  })
    .then((res) => console.log(res))
    .catch((err) => console.log(err));
}

watch(showNameDialog, () => {
  if (playerName.value === "") {
    playerName.value = "Guest";
  } else {
    nuxtStorage.localStorage.setData("name", playerName.value);
  }
});

watch(
  () => game.gameState,
  (newState) => {
    switch (newState) {
      case GameState.Won:
        playWinSound();
        stopwatch.value.stop();
        saveScore();
        isGameOver.value = true;
        break;

      case GameState.Lost:
        playLoseSound();
        stopwatch.value.stop();
        isGameOver.value = true;
        break;

      case GameState.Playing:
        isGameOver.value = false;
        break;
    }
  }
);

onMounted(async () => {
  window.addEventListener("keyup", onKeyup);
  const defaultName = nuxtStorage.localStorage.getData("name");
  showNameDialog.value = defaultName === null || defaultName === "Guest";
  playerName.value = showNameDialog.value ? "Guest" : defaultName;
  stopwatch.value.start();

  if (props.isDaily) {
    option.value = date;
  } else {
    option.value = null;
  }
});

onUnmounted(() => {
  window.removeEventListener("keyup", onKeyup);
});

function onKeyup(event: KeyboardEvent) {
  if (showWordsList.value) {
    return;
  }
  if (showNameDialog.value) {
    return;
  }
  if (event.key === "Enter") {
    let currentGuessIndex = game.guessIndex;
    game.submitGuess(playerName.value, stopwatch.value.getCurrentTime());
    if (currentGuessIndex !== game.guessIndex) {
      playEnterSound();
    }
  } else if (event.key == "Backspace") {
    playClickSound();
    game.removeLastLetter();
  } else if (event.key.match(/[A-z]/) && event.key.length === 1) {
    playClickSound();
    game.addLetter(event.key.toUpperCase());
  }
}

const formattedDate = computed(() => {
  return dateUtils.getFormattedDateWithOrdianl(addDays(new Date(date!), 1));
});
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap");

.font-text {
  font-family: "Press Start 2P", sans-serif;
}
</style>
