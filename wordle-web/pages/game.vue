<template>
  <v-card class="mx-auto my-8" elevation="16" max-width="344">
    <v-card-item>
      <v-card-title> Hurdle Over This Wordle!!! </v-card-title>
      <v-card-subtitle>
        <strong class="text-red-accent-4">hurdle it. I dare you. </strong>
      </v-card-subtitle>
    </v-card-item>

    <v-text-field
      v-model="input"
      label="Will you hurdle? (y/n):"
      outlined
      clearable />
    <v-card-actions>
      <v-spacer />
      <v-btn
        color="blue"
        variant="elevated"
        elevation="8"
        @click="enterInput()">
        Enter
      </v-btn>
    </v-card-actions>
    <v-card-text>
      {{ output }}
    </v-card-text>
    <v-card-text>
      <NuxtLink to="/"> Home page </NuxtLink>
    </v-card-text>
  </v-card>
  <v-row justify="center">
    <v-card align-center>
      <v-row>
        <v-img
          aspect-ratio="1"
          width="600"
          src="https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExaXA5Yjc3ZW9rYTFyaHA5eTU1bnhnc2wxdzl6dThrc2owZG55ejE2OSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/uurtMtTKqkJda4dk8Y/giphy.gif"></v-img>
      </v-row>
    </v-card>
  </v-row>
</template>

<script setup lang="ts">
import { hurdleInput } from '~/scripts/hurdle';

const input = ref('');
const output = ref('');

function enterInput() {
  output.value = hurdleInput(input.value);
}
</script>
