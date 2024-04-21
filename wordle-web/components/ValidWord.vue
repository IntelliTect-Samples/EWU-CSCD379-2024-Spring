<template>
  <v-card class="mx-auto" max-width="400">
    <v-card-item class="justify-center">
      <v-card-title>Valid Word{{ WordList.validateWord(props.guess).length }}</v-card-title>
    </v-card-item>
    <v-card-actions class="justify-center">
      <v-btn color="secondary" @click="dialog = !dialog">Submit</v-btn>
    </v-card-actions>
    <v-dialog v-model="dialog"
    activator="#select"
    transition="dialog-bottom-transition"
    width="auto">
    <v-card width="200px">
      <v-select
        no-data-text="Please enter a letter"
        label="Available Words"
        :item="WordList.validateWord(props.guess)"
        v-model:="selected"
        @update:model-value="SelectionAction(selected)"
        onchange="SelectionAction(this.value)"
      >
      </v-select>
      </v-card>
    </v-dialog>
  </v-card>
</template>

<script setup lang="ts">
//import { s } from 'vitest/dist/reporters-P7C2ytIv';
import type { Game } from '~/scripts/game';
import { WordList } from '~/scripts/wordList';
const validator = new WordList();
const props = defineProps<{
  game: Game;
  guess: string;
}>();
const emits =defineEmits<{
  (event: 'SelectionAction', value: string): void
}>()
function SelectionAction(selected: string) {
  props.game.addLetter(selected);
  dialog.value = false;
}
const dialog = ref(false);
const selected = ref('');
</script>
