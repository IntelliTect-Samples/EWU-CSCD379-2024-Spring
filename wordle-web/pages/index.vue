<template>
  <v-container class="game-container" fluid>
    <v-card color="primary">
      <v-card-title>
        <h1 class="display-1 text-md-center" color="primary">Wordle</h1>
      </v-card-title>
      <v-card-text>
        <p class="display-2 text-md-center" color ="primary">Welcome to the Game of Words</p>
      </v-card-text>
    </v-card>
      <v-divider>
      </v-divider>
      <v-card-actions>
        <v-box class="elevation-3" color="primary">
          <v-btn color="secondary" @click="router.push('/wordOfTheDay')">Wordle - Word of the Day</v-btn>
        </v-box>
      </v-card-actions>
      <v-card-actions>
        <v-box class="elevation-3" color="primary">
          <v-btn color="secondary" @click="router.push('/')">Wordle - Last 10 Days</v-btn>
        </v-box>
      </v-card-actions>
  </v-container>

</template>

<script setup lang="ts">
import { useDisplay }  from "vuetify";
const display = useDisplay();
const imgHeight = ref(630);
const imgWidth = computed(() => calculateWidth());

const calculateWidth = () => {
  if(display.xs){
    return '100%';
  }
  else if(display.sm){
    return '90%';
  }
  else {
    return '75%';
  }
};

</script>

<style>
.image-container{
  width: 100%;
}

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

</style>
