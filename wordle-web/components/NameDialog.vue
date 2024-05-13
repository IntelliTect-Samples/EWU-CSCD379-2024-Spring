<template>
  <v-dialog v-model="show" max-width="350px">
    <v-card>
      <v-card-title>
        <v-icon left>mdi-account-circle</v-icon>
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
          dense />
      </v-card-text>
      <v-card-actions>
        <v-btn color="success" text @click="submitName">Commit to Quest</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup>
import { ref, defineProps, defineEmits } from 'vue';

const props = defineProps({
  show: Boolean,
  name: String
});
const emit = defineEmits(['update:show', 'update:name']);

function submitName() {
  if (!props.name.trim()) {
    props.name = 'Guest'; // Default name if empty
    emit('update:name', 'Guest');
  }
  emit('update:show', false);
}
</script>
