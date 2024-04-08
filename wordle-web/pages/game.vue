<template>
  <v-card>
    <v-card-title>Hello Welcome to Hillbilly Wordle</v-card-title>
  </v-card>

  <v-card class="mx-auto my-8" elevation="16" max-width="344">
    <v-card-item>
      <v-card-title> Website </v-card-title>
      <v-card-subtitle> This is our super basic game </v-card-subtitle>
    </v-card-item>

    <v-card-text>
      <br />
      My Guess: "meow"
      <v-text-field label="Enter ANYTHING" outlined clearable />
    </v-card-text>

    <v-card-actions>
      <v-spacer />
      <v-btn color="pink" variant="elevated" elevation="8" @click="">
        Click Me!
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { Game } from "@/scripts/game";

const game: Game = reactive(new Game("JUMBO"));
const myGuess = ref("");

function submitGuess() {
  game.guess(myGuess.value.toUpperCase());
  myGuess.value = "";
}
</script>
