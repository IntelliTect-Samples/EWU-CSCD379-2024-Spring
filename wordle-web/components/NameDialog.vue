<template>
  <v-dialog v-model="showModel" max-width="350px" persistent>
    <v-card>
      <v-sheet color="deep-purple accent-4">
        <v-card-title class="white--text">Enter Thy Name, Brave Adventurer!</v-card-title>
      </v-sheet>
      <v-form>
        <v-responsive hide-details="auto" width="350">
          <v-text-field
            append-inner-icon="mdi-sword-cross"
            label="Name"
            v-model="submitName"
            @keydown.enter
            @click:append-inner="$emit('entered')"
            @keydown.enter.prevent
            outlined>
          </v-text-field>
        </v-responsive>
      </v-form>
      <v-card-actions>
        <v-btn color="green" text @click="$emit('entered')">Confirm</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { defineProps, defineEmits } from 'vue';

const props = defineProps({
  showModel: Boolean,
  submitName: String
});
const emits = defineEmits(['entered']);
</script>

<style scoped>
.v-card {
  background-color: #3e2723;
  color: #bcaaa4; 
}

.v-btn {
  color: #bcaaa4; 
}
</stype>
