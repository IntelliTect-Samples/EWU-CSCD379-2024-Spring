<template>
  <!-- <v-progress-linear
      v-if="game.gameState === GameState.Initializing"
      color="primary"
      indeterminate
    /> -->
  <v-container class="index" >
    <v-card to="/logo" style="cursor: pointer">
      <v-card-title class = "banner" >
        <h1 class="display-1 text-md-center hillbiddle-title" color="secondary">HILLBIDDLE</h1>
      </v-card-title>
      <v-card-text class="text-center"> Welcome, to access the editWords page, please sign in above </v-card-text>
    </v-card>
  </v-container>
  <v-divider :width="cardWidth"> </v-divider>
  <br><br>
  <v-container class="d-flex justify-center align-center;">
    <div class="d-flex justify-center align-center; image-container" >
      <v-img
        :height="computedImageHeight"
        :width="computedImageWidth"
        src="../public/landingpage-1.png"
      >
      </v-img>
    </div>
  </v-container>

  <v-container>
    <v-card-actions class="d-flex flex-column flex-md-row justify-center align-center">
      <v-btn color="rgb(129, 197, 4)" to="/randomWordGame"
        >Play Random Word</v-btn
      >
      <v-divider class="my-2 my-md-0 mx-md-2"> </v-divider>
      
      <v-btn color="rgb(1, 156, 228)" to="/WordOfTheDay"
        >Play Wordle of the Day</v-btn
      >
      
    </v-card-actions>
  </v-container>

  <v-container class="d-flex justify-center align-center; simpleButton">
    <v-btn color="black" to="/instructions" style="position: sticky" prepend-icon="mdi-halloween"
      >INSTRUCTIONS</v-btn
    >
  </v-container>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import { useDisplay } from "vuetify";
const display = useDisplay();
// const imageHeight = ref(625);
// const imageWidth = ref(1800);
// const cardWidth = ref(1200);

const cardWidth = ref('100%');

const computedImageHeight = computed(() => {
  if (display.mdAndUp) return 625;
  if (display.smAndDown) return 300;
  return 400;
});

const computedImageWidth = computed(() => {
  if (display.mdAndUp) return 1800;
  if (display.smAndDown) return '100%';
  return '100%';
});
</script>

<style>
.index {
  width: 100%;
  justify-content: center;
  align-items: center;
  animation: classicPulse 2s infinite;
}
.image-container {
  width: 100%;
  max-width: 1800px;
  animation: peruPulse 2s infinite;
}
.simpleButton {
  width: 100%;
  animation: classicButton 2s infinite;
}

.banner {
  display: flex;
  justify-content: center;
  padding: 20px;
  background-color: #8747ff21;
  color: rgb(19, 81, 161);/*blanchedalmond*/
  font-size: 24px;
  transform-origin: center center;
  animation: ban 2s infinite;
  
}
.bannerSmall {
  padding-right: 20px;
  padding-left: 0px;
  padding-top: 20px;
  padding-bottom: 20px;
  padding-inline-start: 8%;
  background-color: #8747ff21;
  color: rgb(19, 81, 161);/*blanchedalmond*/
  font-size: 24px;
  transform-origin: center center;
  animation: ban 2s infinite;
}
.wordEdit{
  padding-right: 20px;
  padding-left: 20px;
  padding-top: 20px;
  padding-bottom: 20px;
  padding-inline-start: 5%;
  padding-inline-end: 5%;
  background-color: #8747ff21;
  color: rgb(19, 81, 161);/*blanchedalmond*/
  font-size: 24px;
  transform-origin: center center;
  animation: edit 2s infinite;
}
.wordListStyle{
  padding-right: 20px;
  padding-left: 20px;
  padding-top: 20px;
  padding-bottom: 20px;
  padding-inline-start: 5%;
  padding-inline-end: 5%;
  font-size: 18px;
  transform-origin: center center;
}
@keyframes peruPulse {
  0%,
  100% {
    filter: drop-shadow(0 0 5px peru) drop-shadow(0 0 10px purple)
      drop-shadow(0 0 15px peru);
  }
  50% {
    filter: drop-shadow(0 0 10px peru) drop-shadow(0 0 20px purple)
      drop-shadow(0 0 30px peru);
  }
  25% {
    filter: drop-shadow(-30px 0px 30px rgb(129, 197, 4))
      drop-shadow(0 10px 10px purple)
      drop-shadow(30px 0px 30px rgb(1, 156, 228));
  }
}
@keyframes classicPulse {
  0%,
  100% {
    filter: drop-shadow(0 0 5px) drop-shadow(0 0 10px) drop-shadow(0 0 15px);
  }
  50% {
    filter: drop-shadow(0 0 5px) drop-shadow(0 0 10px) drop-shadow(0 0 15px);
  }
}

@keyframes classicButton {
  0%,
  100% {
    filter: drop-shadow(0 0 5px blue) drop-shadow(0 0 10px blue)
      drop-shadow(0 0 15px blue);
    color: blur();
  }
  50% {
    filter: drop-shadow(0 0 5px blue) drop-shadow(0 0 10px blue)
      drop-shadow(0 0 15px blue);
    color: blur();
  }
}
@keyframes ban {
  0%,
  100% {
    transform: skew(0deg, 0deg) scale(1.35, 1.35);
    filter: saturate(100%) invert(0%);
  }
  25% {
    transform: skew(1deg, 1deg) scale(1.4, 1.4);
    filter: saturate(180%) invert(10%) hue-rotate(20deg);
  }
  50% {
    transform: skew(2deg, 2deg) scale(1.45, 1.45);
    filter: saturate(100%) invert(0%) hue-rotate(40deg);
  }
  75% {
    transform: skew(1deg, 1deg) scale(1.4, 1.4);
    filter: saturate(150%) invert(20%) hue-rotate(60deg);
  }
}
@keyframes edit {
  0%,
  100% {
    transform: skew(0deg, 0deg) scale(1.0, 1.0);
    filter: saturate(100%) invert(100%);
  }
  25% {
    transform: skew(0deg, 0deg) scale(1.0, 1.0);
    filter: saturate(25%) invert(100%) hue-rotate(20deg);
  }
  50% {
    transform: skew(0deg, 0deg) scale(1.0, 1.0);
    filter: saturate(50%) invert(100%) hue-rotate(40deg);
  }
  75% {
    transform: skew(0deg, 0deg) scale(1.0, 1.0);
    filter: saturate(75%) invert(100%) hue-rotate(60deg);
  }
}
@media (max-width: 600px) {
  .hillbiddle-title {
    font-size: 8vw; /* Adjust font size for smaller screens */
  }
}
@media (min-width: 1200px) {
  .hillbiddle-title {
    font-size: 2vw; /* Adjust font size for larger screens */
  }
}
</style>
