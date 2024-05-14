<template>
  <v-dialog v-model="showModel" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary" class="dialog-header">
        <v-card-title class="dialog-title">Enter Thy Name, Brave Adventurer!</v-card-title>
      </v-sheet>
      <v-form>
        <v-responsive hide-details="auto" width="500">
          <v-text-field
            append-inner-icon="mdi-sword-cross"
            label="Name"
            v-model="nameModel"
            class="name-input"
            @keydown.enter.prevent
            @click:append-inner="$emit('entered')"
          ></v-text-field>
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

<style scoped>
.dialog-header {
  background-image: url('path/to/your/fantasy-background.jpg'); /* Add a fantasy-themed background image */
  background-size: cover;
  text-align: center;
}

.dialog-title {
  font-family: 'MedievalSharp', serif; /* Use a fantasy-themed font */
  color: #fff;
}

.name-input {
  --v-text-field-label-color: #fff; /* Make label text white */
  --v-input-background: rgba(0, 0, 0, 0.5); /* Add a semi-transparent background to the input */
  --v-input-color: #fff; /* Make input text color white */
}

.name-input .v-input__icon--append {
  color: #fff;
}
</style>

