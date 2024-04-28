<template>
  <v-card
    :height="boxSize"
    :width="boxSize"
    :color="letter.color"
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
import { useDisplay } from "vuetify";
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
const boxSize = ref(60);
const display = useDisplay();

function onClicked() {
  if(!game) return;

  if (props.letter.char === "👈") {
    game.removeLastLetter();
  } else {
    game.addLetter(props.letter.char.toUpperCase());
  }
}

watch([display.sm, display.xs, display.md], () => {
  if(display.xs.value){
    boxSize.value = 30;
  }else if (display.sm.value) {
    boxSize.value = 40;
  } else {
    boxSize.value = 60;
  }
});
</script>

<style scoped>
.no-pointer {
  pointer-events: none;
}

.v-card {
  background: linear-gradient(
    0deg,
    rgba(255, 255, 255, 0.0),
    rgba(255, 255, 255, 1)
  );
}
</style>
