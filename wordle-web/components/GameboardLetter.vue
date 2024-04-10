<template>
  <v-col
    cols="1"
    class="ma-1 rounded-lg text-white"
    :style="{ background: color }"
    >{{ letter.char.toUpperCase() }}
  </v-col>
</template>

<style scoped>
.v-col {
  height: 75px;
  width: 75px;
  font-size: 3em;
  display: flex;
  justify-content: center;
  align-items: center;
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
      return "#FFEE58";
    default:
      return "#BDBDBD";
  }
});
</script>
