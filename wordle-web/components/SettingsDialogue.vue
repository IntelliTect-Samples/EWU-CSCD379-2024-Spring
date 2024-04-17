<template>
    <v-dialog v-model="modelValue" max-width="500">
      <v-card title="Settings">
        <v-card-text>
          settings here 
        </v-card-text>
  
        <v-card-actions>
          <v-spacer></v-spacer>
  
          <v-btn text="Exit Settings" @click="modelValue = false"></v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>
  
  <script setup lang="ts">
  const modelValue = defineModel<boolean>({ default: false });
  </script>