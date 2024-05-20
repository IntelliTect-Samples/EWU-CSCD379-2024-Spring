<template>


    <v-container class="game-container" fluid>
        <v-progress-linear v-if="game.isBusy" color="primary" indeterminate />
        <v-card v-else class="text-center">
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
                <v-row v-if="game.stats" class="mb-1" justify="center">
                    <v-col cols="auto">
                        <v-progress-circular size="75"
                                             width="10"
                                             v-model="game.stats.winPercentage">
                            {{ game.stats.winPercentage }} %
                        </v-progress-circular>
                        <br />
                        <i class="text-caption">
                            Success Rate
                        </i>
                    </v-col>
                    <v-col cols="auto">
                        <v-progress-circular size="75"
                                             width="10"
                                             :model-value="game.stats.averageGuessesPercent(game.maxAttempts)">
                            {{ game.stats.averageGuessesPercent(game.maxAttempts).toFixed(0) }} %
                        </v-progress-circular>
                        <br />
                        <i class="text-caption">
                            Average Guesses
                        </i>
                    </v-col>
                </v-row>
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
        </v-card>
    </v-container>
</template>

<script setup lang="ts">
    import { Game, GameState } from "../scripts/game";
   import { GameOption } from '~/scripts/game';

const game = reactive(new Game(GameOption.WordOfTheDay));
game.startNewGame();
provide("GAME", game);

const myGuess = ref("");

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
</script>

<style scoped>

.game-container {
  background-image: url("../public/landingPageImage.jpg");
  background-size: cover;
  background-position: center;
  min-height: 100vh;
}

@media screen and (max-width: 600px){
  .game-container {
    background-size: contain;
  }
}

@media screen and (max-width: 1440px){
  .game-container {
    background-size: cover;
  }
}







/*

.desktop1080p-container{
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

.tablet-ipadAir-container{
  max-width: 768px;
  margin: 0 auto;
  padding: 15px;
}

.mobile-galaxyS20-container{
  max-width: 400px;
  margin: 0 auto;
  padding: 10px;
}

.mobile-iPhoneSE-container{
  max-width: 320px;
  margin: 0 auto;
  padding: 5px;
}

// Responsive Styles 
@media (min-width: 1024px) {
  // Styles for iPad Air and larger 
  .tablet-ipadAir-container,
  .desktop1080p-container {
    font-size: 16px;
  }
}

@media (max-width: 1023px) and (min-width: 576px) {
  // Styles for Samsung Galaxy S20 Ultra Super Mega Excellent 
  .mobile-galaxyS20-container {
    // Add styles here 
    font-size: 14px;
  }
}

@media (max-width: 575px) {
  // Styles for iPhone SE 
  .mobile-iPhoneSE-container {
    // Add styles here 
    font-size: 12px;
  }
}
*/
</style>
