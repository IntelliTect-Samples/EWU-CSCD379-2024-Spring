<template>
  <v-card
    :height="boxSize"
    :width="
      isKeyboard ? (letter.char.length > 2 ? keySize * 2.5 : keySize) : boxSize
    "
    elevation="4"
    flat
    :class="[
      clickable ? '' : 'no-pointer',
      correctState(letter.state),
      'align-center d-flex justify-center',
    ]"
    @click="onClicked()"
  >
    {{ letter.char }}
  </v-card>
</template>

<script setup lang="ts">
import { Letter } from "~/scripts/letter";
import { defineProps } from "vue";
import { useDisplay } from "vuetify";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";

const props = withDefaults(
  defineProps<{
    letter: Letter;
    clickable?: boolean;
    isKeyboard?: boolean;
  }>(),
  {
    clickable: false,
    isKeyboard: false,
  }
);

const game: Game | undefined = inject("GAME", undefined);
const boxSize = ref(60);
const display = useDisplay();
const keySize = ref(40);
function onClicked() {
  if (!game) return;

  if (props.letter.char === "👈") {
    game.removeLastLetter();
  } else if (props.letter.char === "ENTER") {
    game.submitGuess();
  } else {
    game.addLetter(props.letter.char.toUpperCase());
  }
}

function correctState(letterState: LetterState) {
  switch (letterState) {
    case LetterState.Correct:
      return "correct-letter";
    case LetterState.Wrong:
      return "wrong-letter";
    case LetterState.Misplaced:
      return "misplaced-letter";
    default:
      return "unkown-letter";
  }
}
watch([display.sm, display.xs, display.md], () => {
  updateSize();
});

function updateSize() {
  if (display.xs.value) {
    boxSize.value = 45;
    keySize.value = 30;
  } else if (display.sm.value) {
    boxSize.value = 60;
    keySize.value = 40;
  } else {
    boxSize.value = 60;
    keySize.value = 60;
  }
}

onMounted(() => {
  updateSize();
});
</script>

<style scoped>
.no-pointer {
  pointer-events: none;
}
.correct-letter {
  background: linear-gradient(
    to bottom,
    rgba(var(--v-theme-correct), 0.6),
    rgba(var(--v-theme-correct), 0.9)
  );
}
.wrong-letter {
  background: linear-gradient(
    to bottom,
    rgba(var(--v-theme-wrong), 0.6),
    rgba(var(--v-theme-wrong), 0.9)
  );
}
.misplaced-letter {
  background: linear-gradient(
    to bottom,
    rgba(var(--v-theme-misplaced), 0.6),
    rgba(var(--v-theme-misplaced), 0.9)
  );
}
.unkown-letter {
  background: linear-gradient(
    to bottom,
    rgba(var(--v-theme-unknown), 0.6),
    rgba(var(--v-theme-unknown), 0.9)
  );
}
</style>
