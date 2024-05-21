<template>
  <v-card
    :height="boxHeight"
    :width="boxWidth"
    :elevation="4"
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
import { LetterState } from "~/scripts/letter";
import { defineProps } from "vue";
import { useDisplay } from "vuetify";
import { Game } from "~/scripts/game";

const props = withDefaults(
  defineProps<{
    letter: Letter;
    clickable?: boolean;
    widthPercentOfHeight?: string;
  }>(),
  {
    clickable: false,
  }
);

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

const game: Game | undefined = inject("GAME", undefined);;
const boxSize = ref(60);
const display = useDisplay();
const boxHeight = ref(60);
const boxWidth = ref(60);
updateWidth();

function onClicked() {
  if (!game) return;

  if (props.letter.char === "⌫ ") {
    game.removeLastLetter();
  } else {
    game.addLetter(props.letter.char.toUpperCase());
  }
}

watch([display.sm, display.xs, display.md], () => {
  if(display.xs.value){
    boxHeight.value = 30;
  }else if (display.sm.value) {
    boxHeight.value = 40;
  } else {
    boxHeight.value = 60;
  }
  updateWidth();
});

function updateWidth() {
  if (props.widthPercentOfHeight !== undefined) {
    boxWidth.value = Math.floor(
      (parseInt(props.widthPercentOfHeight) / 100) * boxHeight.value
    );
  } else {
    boxWidth.value = boxHeight.value;
  }
}
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