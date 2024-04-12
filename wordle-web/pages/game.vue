<script setup lang="ts">
import { ref } from 'vue';
import { tellJoke as tellJokeFunction } from '../scripts/joke'; // Adjust the import path as necessary and rename the imported function

const input = ref('');
const punchline = ref('');
const output = ref('');
const jokeAsked = ref(false);

function askForJoke() {
if (input.value.trim().toLowerCase() === 'y') {
  jokeAsked.value = true;
  output.value = "Great! Let's hear a joke.";
} else {
  output.value = "Okay, maybe next time!";
}
}

function checkPunchline() {
output.value = tellJokeFunction(punchline.value); // Use the renamed imported function
}
</script>

<template>
  <v-card color="light-blue-darken-1" class="mx-auto my-8" elevation="16" max-width="500">

    <v-card-item >
      <v-card-title> Would you want to light up your day? </v-card-title>
      <v-card-subtitle> (y/n) </v-card-subtitle>
    </v-card-item>

    <v-text-field
      v-if="!jokeAsked"
      v-model="input"
      label="Obviously Yes:)"
      outlined
      clearable />
    <v-text-field
      v-else
      v-model="punchline"
      label="Why don't scientists trust atoms?"
      outlined
      clearable />

    <v-card-actions>
      <v-spacer />
      <v-btn
          color="blue"
          variant="elevated"
          elevation="8"
          @click="jokeAsked ? checkPunchline() : askForJoke()">
          Enter
      </v-btn>

    </v-card-actions>
    <v-card-text>
      {{ output }}
    </v-card-text>
    <v-card-text>
      <NuxtLink to="/" external> Home page </NuxtLink>
    </v-card-text>
  </v-card>
</template>
