<template>
  <v-dialog v-model="showModel" max-width="350">
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Enter your name to play:</v-card-title>
      </v-sheet>
      <v-responsive hide-details="auto" class="mx-auto" width="350">
        <v-text-field label="First name" v-model="nameModel"></v-text-field>
      </v-responsive>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>('show');
const nameModel = defineModel<string>('name');
</script>
