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
            @keydown.enter
            @click:append-inner="$emit('entered')"
            @keydown.enter.prevent></v-text-field>
        </v-responsive>
      </v-form>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>('show');
const nameModel = defineModel<string>('name');
defineEmits(['entered']);
</script>
