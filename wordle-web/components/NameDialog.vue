<template>
  <v-dialog v-model="modelValue" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary">
        <v-card-title>Player Name</v-card-title>
      </v-sheet>
      <v-card-text>
        Enter your name to start playing and save your progress!
        <p>Current Name: {{ playerName }}</p>
      </v-card-text>
      <v-card-item>
        <v-text-field
          v-model="playerName"
          label="Your Name"
          clearable
          solo
        ></v-text-field>
      </v-card-item>
      <v-divider />
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          text="Don't Set Name"
          @click="modelValue = false"
          >Don't Set Name</v-btn
        >
        <v-btn color="secondary" text="Set Name" @click="modelValue = false"
          >Set Name</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from "vue";

const modelValue = defineModel<boolean>({ default: false });
const playerName = ref("");

function closeDialog(save: boolean) {
  modelValue.value = false;
  if (save) {
    console.log("Saving name:", playerName.value);
    localStorage.setItem("playerName", playerName.value);
  }
}
</script>
