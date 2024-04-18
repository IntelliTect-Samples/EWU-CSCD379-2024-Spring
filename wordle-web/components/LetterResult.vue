<template>
  <v-btn
    :color="letter.color"
    label
    :height="boxSize"
    :width="boxSize"
    variant="flat"
    :class="clickable ? '' : 'no-pointer'"
  >
    {{ letter.char }}
  </v-btn>
</template>

<script setup lang="ts">
import { Letter } from "~/scripts/letter";
import { defineProps } from "vue";

const props = withDefaults(
  defineProps<{
    letter: Letter;
    boxSize?: number | "unset";
    clickable?: boolean;
  }>(),
  {
    boxSize: 50,
    clickable: false,
  }
);

const boxSize = computed(() => {
  if (props.boxSize === "unset") {
    return "";
  }
  return props.boxSize;
});
</script>

<style scoped>
.no-pointer {
  pointer-events: none;
}
</style>
