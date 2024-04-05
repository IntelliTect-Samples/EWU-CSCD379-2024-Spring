<template>
  <v-card class="mx-auto my-8" elevation="16" max-width="344">
    <v-card-item>
      <v-card-title> Hurdle Over This Wordle!!! </v-card-title>
      <v-card-subtitle> Hurdle it. I dare you. </v-card-subtitle>
    </v-card-item>

    <v-text-field
      v-model="input"
      label="Will you hurdle? (y/n):"
      outlined
      clearable
    />
    <v-card-actions>
      <v-spacer />
      <v-btn
        color="blue"
        variant="elevated"
        elevation="8"
        @click="enterInput()"
      >
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

<script setup lang="ts">
import { hurdleInput } from "~/scripts/hurdle";

const input = ref("");
const output = ref("");

function enterInput() {
  output.value = hurdleInput(input.value);
}
</script>
