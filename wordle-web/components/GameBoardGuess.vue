<template>
  <v-row dense class="justify-center">
    <v-col cols="auto" v-for="(letter, k) of guess.letters" :key="k">
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
