<template>
  <NuxtLayout>
    <v-app>
      <v-card class="mx-auto my-8" elevation="16" max-width="344">
        <v-card-item>
          <v-card-title> Wordle </v-card-title>
          <v-card-subtitle> This is our super basic wordle game </v-card-subtitle>
        </v-card-item>

        <v-card-text>
          {{ myText }}
        </v-card-text>

        <v-card-actions>
          <v-spacer />
          <v-btn color="pink" variant="elevated" elevation="8" @click="click()">
            Click Me!
          </v-btn>
        </v-card-actions>
      </v-card>

      <NuxtPage />
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { Game } from "./scripts/game";
const game: Game = new Game("JUMBO");

game.guess("JUMBO");

console.log(game);

const myText = ref("Hello World");

function click() {
  myText.value = "Goodbye World";
  window.alert("Hello World");
}
</script>
