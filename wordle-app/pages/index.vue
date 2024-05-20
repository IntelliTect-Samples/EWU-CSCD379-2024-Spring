<template>
  <v-container>

      <!-- Single row to display multiple blocks of game pages -->
      <v-row class="text-center pa-5">
        <!-- Word of the Day Game Block -->
        <v-col cols="12" md="6" class="mb-4">
          <v-card 
          class="game-card pa-5 d-flex flex-column align-center justify-center" 
          outlined 
          @mousedown="pressEffect"
          @mouseup="releaseEffect"
          @mouseleave="releaseEffect"
          elevation="2" 
          hover>
            <v-icon size="x-large">mdi-calendar-today</v-icon>
            <h2>Word of The Day Game</h2>
            <p>Challenge yourself with a new word every day!</p>
          </v-card>
        </v-col>

        <!-- Random Word Game Block -->
        <v-col cols="12" md="6" class="mb-4">
          <v-card 
          class="game-card pa-5 d-flex flex-column align-center justify-center"
          outlined 
          @mousedown="pressEffect"
          @mouseup="releaseEffect"
          @mouseleave="releaseEffect"
          elevation="2" 
          hover>
            <v-icon size="x-large">mdi-shuffle-variant</v-icon>
            <h2>Random Word Game</h2>
            <p>Guess the word with the fewest guesses!</p>
          </v-card>
        </v-col>
      </v-row>

  </v-container>
</template>

<script setup lang="ts">

const router = useRouter();
const isPressed = ref(false);

function pressEffect() {
  isPressed.value = true;
}

function releaseEffect() {
  isPressed.value = false;
}


</script>

<style scoped>
.v-card {
  cursor: pointer;
  transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
}

.v-card:hover {
  transform: scale(1.05); /* Scale up the card slightly */
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.25); /* Enhance shadow for depth */
}

.game-card {
  transition: transform 0.1s ease;
  cursor: pointer;
  min-height: 300px;
}

@media(max-width: 600px) {
  .game-card {
    min-height: 200px;
  }
}

.game-card:active {
  transform: scale(0.95);
}
</style>
