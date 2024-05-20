<template>
  <v-container fluid class="image-container">
      <v-img src="../public/edited-vaporwave-landingPage.jpg">
        <v-divider>
        </v-divider>
        <v-card-actions>
          <v-col>
              <v-btn color="secondary" to="/randomWordGame">Play Random Word</v-btn>
              <v-btn color="primary" to="/WordleOfTheDay">Play Wordle of the Day</v-btn>
              <v-btn color="secondary" @click="$router.push('/leaderboard')">Leaderboard</v-btn>
            </v-col>
          </v-card-actions>
    </v-img>
  </v-container>
  <v-divider></v-divider>
  <v-container class="intro">
    
          <v-card-title>
              <h1 class="display-1 text-center">Whurdle</h1>
          </v-card-title>
          <v-card-text>
              <p class="display-2 text-center">Welcome to Whurdle!</p>
              
          </v-card-text>
          <v-img class="Whurdle mx-auto w-75" src="../public/WhurdleCompany.png" width="200" height="200"></v-img>

  </v-container>
</template>
<script setup lang="ts">
import { useDisplay } from 'vuetify';
const display = useDisplay();
const imageWidth = ref(1800);
const cardWidth = ref(1200);

</script>

<style>
.Whurdle {
  display: flex;
  justify-content: center;
  align-items: center;
}
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
