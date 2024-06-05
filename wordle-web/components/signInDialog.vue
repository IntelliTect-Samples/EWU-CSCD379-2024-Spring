<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card color="secondary">
      <v-sheet color="primary">
        <v-card-text style="text-align: center; font-size: larger">
          <header>
            {{ isRegisterMode ? 'Register' : 'Sign In' }}
          </header>
        </v-card-text>
      </v-sheet>
      <v-divider />
      <v-card-text  class="text-center">
        <v-form ref="form" v-model="valid" lazy-validation>
          <template v-if="!isRegisterMode">
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
          </template>
          
          <template v-else>
            <v-text-field
              v-model="fullName"
              label="Full Name"
              prepend-icon="mdi-account-outline"
              required
            ></v-text-field>
            <v-text-field
              v-model="email"
              label="Email"
              prepend-icon="mdi-email-outline"
              required
            ></v-text-field>
            <v-text-field
              v-model="birthdate"
              label="Birthdate"
              prepend-icon="mdi-calendar"
              type="date"
              required
            ></v-text-field>
          </template>
          <v-btn style="box-shadow: inset;" color="primary" @click="toggleMode()">
            {{ isRegisterMode ? 'Sign-In' : 'Register' }}
          </v-btn>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn style="box-shadow: inset;" color="primary" @click="submit">{{ isRegisterMode ? 'Register' : 'Sign In' }}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const modelValue = ref<boolean>(false);
const seeWhileTyping = ref<boolean>(false);
const password = ref<string>('');
const valid = ref<boolean>(false);
const userName = ref<string>('');
const isRegisterMode = ref<boolean>(false);

function toggleMode(){
  isRegisterMode.value = !isRegisterMode.value;
}

</script>

<style>
</style>
