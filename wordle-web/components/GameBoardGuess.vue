<template>
  <v-row class="justify-center" dense>
    <v-col
      v-for="(letter, i) in guess.letters"
      :key="i"
      cols="auto"
    >
      <LetterResult :letter="letter" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { Word } from "~/scripts/word";
import { defineProps } from "vue";

defineProps<{
  guess: Word;
}>();
</script>
