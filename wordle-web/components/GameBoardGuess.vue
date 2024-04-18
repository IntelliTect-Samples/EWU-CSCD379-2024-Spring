<template>
  <v-row dense class="justify-center">
    <v-col :class="isShaking ? 'shaking' : ''" cols="auto" v-for="(letter, k) of guess.letters" :key="k">
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

watch(() => props.guess.isFilled,
() => {
  if(!props.guess.isFilled){
    isShaking.value = true;
    setTimeout(() => {
      isShaking.value = false;
    }, 300);
  }
});
</script>

<style scoped>
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
