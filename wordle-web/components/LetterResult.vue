<template>
  <v-card
    :height="boxSize"
    :width="boxSize"
    :color="letter.color"
    flat
    :class="[
      clickable ? '' : 'no-pointer',
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

const game: Game = inject("GAME")!;
const boxSize = 50;

function onClicked(){
  if(props.letter.char === "👈"){
    game.removeLastLetter();
  } else {
    game.addLetter(props.letter.char.toUpperCase());
  }
}
</script>

<style scoped>
.no-pointer {
  pointer-events: none;
}
</style>
