<template>
  <div>
    <LetterResult
      v-for="(letter, k) of guess.letters"
      :key="k"
      :letter="letter"
    />
  </div>
</template>

<script setup lang="ts">
import { Word } from "~/scripts/word";
import { defineProps } from "vue";

defineProps<{
  guess: Word;
}>();
</script>
