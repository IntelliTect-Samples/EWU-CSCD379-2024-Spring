<template>
  <v-card
    :height="boxHeight"
    :width="boxWidth"
    :color="letter.color"
    flat
    :class="[
      clickable ? '' : 'no-pointer',
      'align-center d-flex justify-center',
      `elevation-20`,
    ]"
    @click="onClicked()">
    {{ letter.char }}
  </v-card>
</template>

<script setup lang="ts">
import { Letter } from '~/scripts/letter';
import { defineProps } from 'vue';
import { useDisplay } from 'vuetify';
import { Game } from '~/scripts/game';

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

const game: Game | undefined = inject('GAME', undefined);
const boxHeight = ref(60);
const boxWidth = ref(60);
updateWidth();
const display = useDisplay();

function onClicked() {
  if (!game) return;

  if (props.letter.char === '👈') {
    game.removeLastLetter();
  } else {
    game.addLetter(props.letter.char.toUpperCase());
  }
}

watch([display.sm, display.xs, display.md], () => {
  if (display.xs.value) {
    boxHeight.value = 30;
  } else if (display.sm.value) {
    boxHeight.value = 40;
  } else {
    boxHeight.value = 60;
  }
  updateWidth();
});
//Need advise on how to tackle gradient css
function setGradient(): string {
  if (props.letter.color == 'correct') {
    return `background: linear-gradient(90deg, white 0%, correct 100%)`;
  } else if (props.letter.color == 'misplaced') {
    return `background: linear-gradient(90deg, white 0%, misplace 100%)`;
  } else if (props.letter.color == 'wrong') {
    return `background: linear-gradient(90deg, white 0%,  misplaced 100%)`;
  } else {
    return `background: linear-gradient(90deg, white 0%, unknown 100%)`;
  }
}

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
</style>
<!--Need advise on how to tackle css-->
<style scoped>
.card {
  color: 'background: linear-gradient(grey, ${props.letter.color})';
}
</style>
