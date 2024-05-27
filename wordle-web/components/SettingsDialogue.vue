<template>
  <v-dialog v-model="modelValue" max-width="1000">
    <v-card>
      <v-sheet color="primary">
        <v-card-title> Settings </v-card-title>
      </v-sheet>
      <v-card-item>
        <ThemePicker color="transparent" />
      </v-card-item>
      <v-card-actions>
        <v-spacer />
        <v-btn
          color="primary"
          variant="elevated"
          justify-center
          @click="modelValue = false"
        >
          Close
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const modelValue = defineModel<boolean>({ default: false });
</script>
