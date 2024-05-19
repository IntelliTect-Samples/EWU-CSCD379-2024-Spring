<template>
  <v-container class="intro">
    <v-card>
      <v-card-title>
        <h1 class="display-1 text-md-center">Wordle</h1>
      </v-card-title>
      <v-card-text>
        <p class="display-2 text-md-center">Welcome to the Game of Words</p>
      </v-card-text>
    </v-card>
  </v-container>
  <div class="image-container">
    <v-img :height="imageHeight" :width="imageWidth" cover src="../public/wordleLandingImage.png">
      <v-divider>
      </v-divider>
      <v-card-actions>
        <v-btn color="secondary" @click="router.push('/wordOfTheDay')">Wordle - Word of the Day</v-btn>
        <v-btn color="secondary" @click="router.push('/')">Wordle - Last 10 Days</v-btn>
      </v-card-actions>
    </v-img>
  </div>
</template>

<script setup lang="ts">
import { useDisplay }  from "vuetify";
const display = useDisplay();
const imgHeight = ref(630);
const imgWidth = ref(1200);

</script>

<style>
.image-container{
  width: 1800px;
}
</style>
