<template>
  <v-dialog v-model="showModel" max-width="500" persistent>
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Enter your name to start playing!</v-card-title>
      </v-sheet>
      <v-card-item>
        <v-text-field label="Name" v-model="nameModel" />
      </v-card-item>
      <v-card-actions>
        <v-spacer />
        <v-btn
          color="secondary"
          variant="flat"
          text="Save"
          @click="showModel = false"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>("show");
const nameModel = defineModel<string>("name");
</script>
