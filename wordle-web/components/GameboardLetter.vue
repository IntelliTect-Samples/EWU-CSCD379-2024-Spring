<template>
  <v-col
    cols="1"
    class="guess-letter font-size-2 d-flex justify-center align-center ma-1 rounded-lg text-white text-h4"
    :style="{ background: color }"
    >{{ letter.char.toUpperCase() }}
  </v-col>
</template>

<style scoped>
.guess-letter {
  height: 50px;
  width: 50px;
}
</style>

<script setup lang="ts">
import { defineProps } from "vue";
import { Letter, LetterState } from "~/scripts/letter";
const props = defineProps<{
  letter: Letter;
}>();

const color = computed(() => {
  switch (props.letter.state) {
    case LetterState.Correct:
      return "#66BB6A";
    case LetterState.Wrong:
      return "#EF5350";
    case LetterState.Misplaced:
      return "#FFF176";
    default:
      return "#B0BEC5";
  }
});
</script>
