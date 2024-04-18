<template>
  <v-card
    :height="boxSize"
    :width="boxSize"
    :color="letter.color"
    flat
    class="align-center d-flex justify-center"
  >
    {{ letter.char }}
  </v-card>
</template>

<script setup lang="ts">
import { Letter } from "~/scripts/letter";
import { defineProps } from "vue";

const props = defineProps<{
  letter: Letter;
}>();

const boxSize = 50;
</script>
