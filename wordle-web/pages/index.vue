<template>
  <div class="image-container">
      <v-img :height="imageHeight" :width="imageWidth" cover src="../public/vaporwave-landingPage.jpg">
        <v-divider>
        </v-divider>
        <v-card-actions>
              <v-btn color="secondary" to="/randomWordGame">Play Random Word</v-btn>
              <v-btn color="primary" to="/WordleOfTheDay">Play Wordle of the Day</v-btn>

              <v-btn color="secondary" @click="$router.push('/leaderboard')">Leaderboard</v-btn>
          </v-card-actions>
    </v-img>
  </div>
  <v-divider></v-divider>
  <v-container class="intro">
    <v-card :width="cardWidth">
          <v-card-title>
              <h1 class="display-1 text-md-center">Whurdle</h1>
          </v-card-title>
          <v-card-text>
              <p class="display-2 text-md-center">Welcome to Whurdle!</p>
              
          </v-card-text>

      </v-card>
  </v-container>
</template>
<script setup lang="ts">
import { useDisplay } from 'vuetify';
const display = useDisplay();
const imageHeight = ref(625);
const imageWidth = ref(1800);
const cardWidth = ref(1200);

</script>

<style>
.image-container {
  width: 2000px; /* Adjust size as needed */
  animation: neonPulse 2s infinite;
}

@keyframes neonPulse {
  0%, 100% {
    filter: drop-shadow(0 0 5px cyan) drop-shadow(0 0 10px cyan) drop-shadow(0 0 15px blue);
  }
  50% {
    filter: drop-shadow(0 0 10px cyan) drop-shadow(0 0 20px cyan) drop-shadow(0 0 30px blue);
  }
}

/* OPTION 2: BANNER ANIMATION
  .image-container{
  transform-origin: center center;
  animation: banner 5s ease-in-out alternate infinite;
}
@keyframes banner {
0%,
100% {
  transform: skew(0deg, 0deg) scale(1.35, 1.35);
  filter: saturate(100%) invert(0%);
  }
  75% {
    filter: saturate(150%) invert(20%);
  }
  50% {
    transform: skew(2deg, 2deg) scale(1.35, 1.35);
    filter: saturate(100%) invert(0%);
  }
    25% {
    filter: saturate(180%) invert(10%);
  }
}
  */
</style>
