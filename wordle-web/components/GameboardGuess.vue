<template>
  <GameboardLetter
    v-for="(letter, j) of guess.letters"
    :key="j"
    :letter="letter"
  />
  <v-spacer />
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import { Word } from "~/scripts/word";
defineProps<{
  guess: Word;
}>();
</script>
