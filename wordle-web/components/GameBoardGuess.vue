<template>
  <v-row class="justify-center" dense>
    <v-col
      v-for="(letter, i) in guess.letters"
      :key="i"
      cols="auto"
      :class="isShaking ? 'shaking' : ''"
    >
      <LetterResult :letter="letter" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { Word } from "~/scripts/word";
import { defineProps } from "vue";

const props = defineProps<{
  guess: Word;
}>();

const isShaking = ref(false);

watch(
  () => props.guess.isFilled,
  () => {
    if (!props.guess.isFilled) {
      isShaking.value = true;
      setTimeout(() => {
        isShaking.value = false;
      }, 300);
    }
  }
);
</script>

<style scoped>
.shake {
  transition: transform 0.1s ease-in-out;
}

.shaking {
  animation: shake 0.3s;
}

@keyframes shake {
  0% {
    transform: translateX(0);
  }
  25% {
    transform: translateX(-5px);
  }
  50% {
    transform: translateX(5px);
  }
  75% {
    transform: translateX(-5px);
  }
  100% {
    transform: translateX(0);
  }
}
</style>
