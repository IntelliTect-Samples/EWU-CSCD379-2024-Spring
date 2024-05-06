<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary"></v-sheet>
      <v-card-title>Enter a username.</v-card-title>
      <v-text-field v-model="userName" label="UserName" required></v-text-field>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="closeDialog">Cancel</v-btn>
        <v-btn color="primary" @click=saveUsername>Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import {defineModel, inject} from 'vue-demi';
import nuxtStorage from 'nuxt-storage';

const modelValue = defineModel<boolean>({ default: false });
const userName = inject("userName");

function saveUsername() { 
  try {
    nuxtStorage.localStorage.setData("userName", userName.value);
    modelValue.value = false;
    console.log("Username saved: " + userName);
  }
  catch (error) {
    console.error("Error saving name: ", error);
  }
}

function closeDialog() {
  modelValue.value = false;
}

</script>
