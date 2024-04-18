<template>
  <v-btn
    :color="letter.color"
    label
    :height="boxSize"
    :width="boxSize"
    variant="flat"
    :class="clickable ? '' : 'no-pointer'"
    @click="clickKey"
  >
    {{ letter.char }}
  </v-btn>
</template>

<script setup lang="ts">
import { Letter } from "~/scripts/letter";
import { defineProps } from "vue";
import { Game } from "~/scripts/game";

const props = withDefaults(
  defineProps<{
    letter: Letter;
    clickable?: boolean;
  }>(),
  {
    clickable: false,
  }
);

const game: Game | undefined = inject("GAME", undefined);
const boxSize = 50;

function clickKey() {
  if (!game) return;
  if (props.letter.char === "👈") {
    game.removeLastLetter();
  } else {
    game.addLetter(props.letter.char);
  }
}
</script>

<style scoped>
.no-pointer {
  pointer-events: none;
}
</style>
