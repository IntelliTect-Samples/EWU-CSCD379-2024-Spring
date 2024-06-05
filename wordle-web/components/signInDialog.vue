<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card color="secondary">
      <v-sheet color="primary">
        <v-card-text style="text-align: center; font-size: larger">
          <header>
            Sign In
          </header>
        </v-card-text>
      </v-sheet>
      <v-divider />
      <v-card-text>
        <v-form ref="form" v-model="valid" lazy-validation>
          <v-text-field
            v-model="username"
            label="Username"
            prepend-icon="mdi-account"
            required
          ></v-text-field>
          <v-text-field
            v-model="password"
            :type="seeWhileTyping ? 'text' : 'password'"
            label="Password"
            prepend-icon="mdi-lock"
            :append-inner-icon="seeWhileTyping ? 'mdi-eye-outline' : 'mdi-eye-off-outline'"
            @click:append-inner="seeWhileTyping = !seeWhileTyping"
            required
          ></v-text-field>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="submit">Sign In</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const modelValue = ref<boolean>(false);
const username = ref<string>('');
const seeWhileTyping = ref<boolean>(false);
const password = ref<string>('');
const valid = ref<boolean>(false);

const submit = () => {
};
</script>

<style>
</style>
