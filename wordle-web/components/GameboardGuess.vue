<template>
  <v-row justify="center">
    <GameboardLetter
      v-for="(letter, j) of guess.letters"
      :key="j"
      :letter="letter"
    />
  </v-row>

  <v-spacer />
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import { Word } from "~/scripts/word";
defineProps<{
  guess: Word;
}>();
</script>
