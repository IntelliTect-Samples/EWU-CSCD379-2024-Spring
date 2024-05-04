<template>
  <v-app>
   
    <v-main>
      
      <v-dialog v-model="modelValue" max-width="500" persistent>
        <v-card>
          <v-sheet color="primary"> </v-sheet>
          <v-card-text color="primary" class="text-h6 mb-3 pa-6 text-center">
            Enter your name to start the game and track your progress!
            <v-text-field
              class="pa-6"
              v-model="playerName"
              label="Your Name"
              outlined
              dense
            ></v-text-field>
          </v-card-text>

          <v-divider />
          <v-card-actions>
            <v-btn color="primary" @click="modelValue = false">
              Don't Set Name
            </v-btn>
            <v-btn color="primary" @click="setName; modelValue = false"> Set Name </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref, onMounted, defineComponent } from 'vue';

const modelValue = ref(false);
const playerName = ref('guest');

const setName = () => {
  console.log("Player name set:", playerName.value);
  localStorage.setItem("playerName", playerName.value);
};

onMounted(() => {
  const savedName = localStorage.getItem("playerName");
  if (savedName) {
    playerName.value = savedName;
  }
});
</script>