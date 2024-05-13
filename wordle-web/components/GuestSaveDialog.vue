<template>
  <v-dialog v-model="showModel" max-width="350">
    <v-card>
      <v-sheet color="secondary">
        <v-card-title
          >Would you like to save your score under 'Guest'?</v-card-title
        >
      </v-sheet>
      <v-btn
        @click="
          $emit('saveGuestScore');
          showModel = false;
        "
        >Yes</v-btn
      >
      <v-btn @click="showModel = false">No</v-btn>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>();
defineEmits(['saveGuestScore']);
</script>
