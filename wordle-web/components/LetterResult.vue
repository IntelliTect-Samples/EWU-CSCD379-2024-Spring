<template>
  <div class="letter-box" :class="color">
    {{ letter.char }}
  </div>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { defineProps } from "vue";

const props = defineProps<{
  letter: Letter;
}>();

const color = computed(() => {
  switch (props.letter.state) {
    case LetterState.Correct:
      return "correct";
    case LetterState.Misplaced:
      return "misplaced";
    case LetterState.Wrong:
      return "wrong";
    default:
      return "unknown";
  }
});

</script>

<style scoped>
.letter-box {
  border: 1px solid black;
  margin: 3px;
  text-align: center;
  font-size: 32px;
  height: 50px;
  width: 50px;
  display: inline-block;
}

.letter-box.correct {
  background-color: green;
}

.letter-box.misplaced {
  background-color: yellow;
}

.letter-box.wrong {
  background-color: grey;
}

.letter-box.unknown {
  background-color: white;
}
</style>
