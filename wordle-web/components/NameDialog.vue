<template>
  <v-dialog v-model="showDialog" max-width="350px" persistent>
    <v-card class="elevation-12">
      <v-sheet color="deep-purple accent-4" dark>
        <v-card-title class="headline">state thy name:</v-card-title>
      </v-sheet>
      <v-form>
        <v-container>
          <v-text-field
            v-model="userName"
            label="Enter Your Heroic Name"
            outlined
            dense
            append-icon="mdi-arrow-right-bold-circle"
            @click:append="saveName"
            @keydown.enter.prevent="saveName"
          ></v-text-field>
        </v-container>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script setup>
import { ref } from 'vue';

const showDialog = ref(true);
const userName = ref(localStorage.getItem('userName') || 'Guest');

function saveName() {
  if (userName.value.trim() === '') {
    userName.value = 'Guest'; // Default name if empty
  }
  localStorage.setItem('userName', userName.value);
  showDialog.value = false;
  // Emit an event if you need to inform the parent component
  emit('entered', userName.value);
}
</script>

<style scoped>
.elevation-12 {
  background-image: linear-gradient(to right, #5433ff, #20bdff, #a5fecb);
  border-radius: 8px;
}
</style>
