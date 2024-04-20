<template>
  <v-card
    :height="boxHeight"
    :width="boxWidth"
    :color="letter.color"
    flat
    :class="[
      clickable ? '' : 'no-pointer',
      'align-center d-flex justify-center',
      `elevation-10`,
    ]"
    :style="{
      'background-image':
        'radial-gradient(rgb(var(--v-theme-' +
        letter.color +
        ')) 40%, rgb(var(--v-theme-' +
        letter.colorGradient +
        ')) 95%)',
    }"
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
