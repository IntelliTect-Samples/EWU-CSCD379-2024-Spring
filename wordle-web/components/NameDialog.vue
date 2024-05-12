<template>
  <v-dialog v-model="showModel" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary">
        <v-card-title class="text-wrap"
          >Enter your name to start playing!</v-card-title
        >
      </v-sheet>
      <v-card-item>
        <v-form v-model="form" @submit.prevent="onSubmit">
          <v-text-field
            label="Name"
            v-model="nameModel"
            :rules="[lengthValidator]"
          />
          <v-card-actions>
            <v-spacer />
            <v-btn
              color="primary"
              type="submit"
              variant="elevated"
              justify-center
            >
              Save
            </v-btn>
          </v-card-actions>
        </v-form>
      </v-card-item>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>("show");
const nameModel = defineModel<string>("name");

const form = ref(false);

const onSubmit = () => {
  if (form.value) {
    showModel.value = false;
  }
};

const lengthValidator = (value: string) => {
  if (value.length <= 36) {
    return true;
  }
  return "Name must be less than 36 characters";
};
</script>
