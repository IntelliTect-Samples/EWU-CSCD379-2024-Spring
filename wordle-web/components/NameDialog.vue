<template>
  <v-dialog v-model="showDialog" max-width="350px" persistent>
    <v-card>
      <v-card-title class="text-h6">
        <v-icon left>mdi-account-circle</v-icon>
        Enter Thy Name, Brave Adventurer!
      </v-card-title>
      <v-card-text>
        <v-text-field
          label="Name"
          outlined
          v-model="name"
          append-icon="mdi-check"
          @click:append="submitName"
          @keydown.enter="submitName"
          single-line
          dense>
        </v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-btn color="success" text @click="submitName">Commit to Quest</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup>
import { ref, defineProps, defineEmits } from 'vue';
import { useStorage } from '@vueuse/core';

const showDialog = ref(false);
const name = useStorage('userName', 'Guest');

const emit = defineEmits(['update:name']);

function submitName() {
  if (!name.value.trim()) {
    name.value = 'Guest'; // Set default name if input is empty
  }
  emit('update:name', name.value);
  showDialog.value = false; 
}
</script>

<style scoped>
.v-dialog .v-card {
  background-color: #4527a0;
  color: #ffe082; 
}
.v-btn {
  color: #ffe082;
}
</style>
