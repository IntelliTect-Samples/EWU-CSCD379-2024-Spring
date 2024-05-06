<template>
  <v-dialog v-model="showModel" max-width="350" persistent>
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Enter your name to start playing!</v-card-title>
      </v-sheet>
      <v-text-field
        append-inner-icon="mdi-arrow-right-bold"
        label="Name"
        v-model="nameModel"
        @click:append-inner="$emit('entered')"
      ></v-text-field>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>("show");
const nameModel = defineModel<string>("name");
defineEmits(["entered"]);
</script>
