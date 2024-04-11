<template>
  <v-row justify="center">
    <GameboardLetter
      v-for="j in 5"
      :key="j"
      :letter="
        guess.letters[j - 1] === undefined
          ? new Letter(' ')
          : guess.letters[j - 1]
      "
    />
  </v-row>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import { Word } from "~/scripts/word";
import { Letter } from "~/scripts/letter";
defineProps<{
  guess: Word;
}>();
</script>
