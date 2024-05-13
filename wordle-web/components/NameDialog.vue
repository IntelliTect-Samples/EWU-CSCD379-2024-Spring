<template>
  <v-dialog v-model="showDialog" max-width="350px" persistent>
    <v-card class="elevation-2">
      <v-card-title class="text-h6">
        <v-icon left>mdi-castle</v-icon>
        Enter Thy Name, Brave Adventurer!
      </v-card-title>
      <v-card-text>
        <v-text-field
          v-model="name"
          label="Name"
          outlined
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
import { ref } from 'vue';
import { useStorage } from '@vueuse/core';

const showDialog = ref(false);
const name = useStorage('userName', 'Guest');

function submitName() {
  if (!name.value.trim()) {
    name.value = 'Guest'; // Default name if empty
  }
  showDialog.value = false;
}

watch(name, (newName) => {
  if (newName && newName !== 'Guest') {
    localStorage.setItem('userName', newName);
  }
});
</script>

<style scoped>
.v-dialog .v-card {
  background-color: #4527a0; /* Deep purple */
  color: #ffe082; /* Amber accent */
}
.v-btn {
  color: #ffe082;
}
</style>
