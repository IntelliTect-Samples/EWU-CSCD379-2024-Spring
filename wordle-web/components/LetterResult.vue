<template>
  <v-chip :color="color" class="ma-1 pa-2 text-h5">{{ letter.char }} </v-chip>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import { Letter, LetterState } from "~/scripts/letter";
const props = defineProps<{
  letter: Letter;
}>();

const color = computed(() => {
  switch (props.letter.state) {
    case LetterState.Correct:
      return "success";
    case LetterState.Wrong:
      return "error";
    default:
      return "grey";
  }
});
</script>
