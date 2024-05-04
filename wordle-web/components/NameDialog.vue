<template>
  <v-dialog v-model="modelValue" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary">
        <v-card-title>Player Name</v-card-title>
      </v-sheet>
      <v-card-text>
        Enter your name to start playing and save your progress!
      </v-card-text>
      <v-card-item>
        <v-text-field v-model="playerName" label="Your Name"></v-text-field>
      </v-card-item>

      <v-divider />

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          variant="flat"
          text="Don't Set Name"
          @click="modelValue = false"
        >
        </v-btn>
        <v-btn
          color="secondary"
          variant="flat"
          text="Set Name"
          @click="modelValue = false"
        >
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";
import GameBoardGuess from "~/components/GameBoardGuess.vue"; // Ensure this import if the component is used

const modelValue = defineModel<boolean>({ default: false });

const playerName = ref("");

function closeDialog(save: boolean) {
  if (save) {
    console.log("Saving name:", playerName.value); // Here you could actually save the name to a store or localStorage
    // localStorage.setItem('playerName', playerName.value); Uncomment or modify according to your context
  }
  modelValue.value = false;
}
</script>
