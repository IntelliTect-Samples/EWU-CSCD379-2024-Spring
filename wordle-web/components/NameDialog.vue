<template>
  <v-dialog v-model="showModel" max-width="350" persistent>
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Enter Thy Name, Brave Adventurer!</v-card-title>
      </v-sheet>
      <v-form>
        <v-responsive hide-details="auto" width="350">
          <v-text-field
            append-inner-icon="mdi-sword-cross"
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

