<template>
  <v-dialog v-model="showModel" max-width="350" persistent>
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Enter your name:</v-card-title>
      </v-sheet>
      <v-form>
        <v-responsive hide-details="auto" width="350">
          <v-text-field
            append-inner-icon="mdi-arrow-right-bold-circle"
            label="Name"
            v-model="nameModel"
            @click:append-inner="enterName"></v-text-field>
        </v-responsive>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import nuxtStorage from 'nuxt-storage';
const showModel = defineModel<boolean>('show', { default: true });
const nameModel = defineModel<string>('name');

function enterName() {
  showModel.value = !showModel.value;
  if (nameModel.value === '') {
    nameModel.value = 'Guest';
  } else {
    // nuxtStorage.localStorage.setData('name', nameModel.value);
  }
}
</script>
