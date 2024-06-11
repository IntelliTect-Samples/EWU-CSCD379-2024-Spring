<template>
  <v-dialog v-model="modelValue" width="500">
    <v-card>
      <v-alert v-if="errorMessage" type="error">
        {{ errorMessage }}
      </v-alert>
      <v-card-text>
        <v-text-field v-model="userName" @keyup.stop label="Username" />
        <v-text-field v-if="isSignUp" v-model="email" @keyup.stop label="Email" />
        <v-text-field
          v-model="password"
          @keyup.stop
          label="Password"
          :type="showPassword ? 'text' : 'password'"
          :append-inner-icon="
            showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'
          "
          @click:append-inner="showPassword = !showPassword"
        />
        <v-text-field v-if="isSignUp" v-model="secretPhrase" @keyup.stop label="Secret Phrase" />
        <v-date-picker v-if="isSignUp" v-model="birthday" label="Birthday" />
      </v-card-text>
      <v-card-actions>
        <v-row justify="center">
          <v-col cols="auto">
            <v-btn color="primary" variant="tonal" @click="modelValue = false">
              Cancel
            </v-btn>
          </v-col>
          <v-col cols="auto">
            <v-btn color="primary" variant="flat" @click="isSignUp ? signUp : signIn">
              {{ isSignUp ? 'Sign Up' : 'Sign In' }}
            </v-btn>
          </v-col>
          <v-col cols="auto">
            <v-btn @click="toggleSignUp">
              {{ isSignUp ? 'Sign In' : 'Sign Up' }}
            </v-btn>
          </v-col>
        </v-row>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>




<script setup lang="ts">
import axios from "axios";
const modelValue = defineModel<boolean>({ default: false });
const showPassword = ref(false);
const userName = ref("");
const password = ref("");
const email = ref("");
const secretPhrase = ref("");
const birthday = ref(null);
const errorMessage = ref("");
const isSignUp = ref(false);

function signIn() {
  errorMessage.value = "";
  axios
    .post("/Token/GetToken", {
      username: userName.value,
      password: password.value,
    })
    .then((response) => {
      modelValue.value = false;
    })
    .catch((error) => {
      errorMessage.value = error.response.data;
    });
}

function signUp() {
  errorMessage.value = "";
  axios
    .post("/User/Register", {
      username: userName.value,
      password: password.value,
      email: email.value,
      secretPhrase: secretPhrase.value,
      birthday: birthday.value,
    })
    .then((response) => {
      modelValue.value = false;
    })
    .catch((error) => {
      errorMessage.value = error.response.data;
    });
}

function toggleSignUp() {
  isSignUp.value = !isSignUp.value;
}
</script>
