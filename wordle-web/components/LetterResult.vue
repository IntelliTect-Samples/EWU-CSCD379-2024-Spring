<template>
  <v-card
    :color="letter.color"
    :height="boxSize"
    :width="boxSize"
    variant="flat"
    :class="[
      clickable ? '' : 'no-pointer',
      'justify-center align-center d-flex',
    ]"
    @click="clickKey"
  >
    {{ letter.char }}
  </v-card>
</template>

<script setup lang="ts">
import { Letter } from "~/scripts/letter";
import { defineProps } from "vue";
import { Game } from "~/scripts/game";
import { useDisplay } from "vuetify";

const display = useDisplay();

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

watch(
  [display.sm, display.xs, display.md],
  () => {
    if (display.sm.value) {
      boxSize.value = 40;
    } else if (display.xs.value) {
      boxSize.value = 30;
    } else {
      boxSize.value = 60;
    }
  }
);

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
