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
  background-image: url('/images/lexiquest_background.jpg');
  background-size: cover;
  text-align: center;
}

.dialog-title {
  font-family: 'MedievalSharp', serif;
  color: #fff;
}

.name-input {
  --v-text-field-label-color: #fff; 
  --v-input-background: rgba(0, 0, 0, 0.5);
  --v-input-color: #fff;
}

.name-input .v-input__icon--append {
  color: #fff;
}
</style>

