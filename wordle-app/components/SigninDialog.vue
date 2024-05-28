<template>
  <v-dialog v-model="modelValue" width="400">
    <v-card>
      <v-alert v-if="errorMessage" type="error" title-date-format="Function">
        {{ errorMessage }}
      </v-alert>
      <v-card-text>
        <v-text-field v-model="userName" @keyup.stop label="Username" />
        <v-text-field 
          v-model="password"
          @keyup.stop
          label="Password"
          :type="showPassword ? 'text' : 'password'"
          :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
          @click:append-inner="showPassword = !showPassword"/>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="primary" variant="flat" @click="modelValue = false">
          Cancel
        </v-btn>
        <v-btn color="primary" variant="flat" @click="signIn"> Sign In </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import axios from "axios";

const modelValue = defineModel<boolean>({ default: false });
const showPassword = ref(false);
const userName = ref("");
const password = ref("");
const errorMessage = ref("");

function signIn() {
  errorMessage.value = "";
  axios
    .post("/Token/GetToken", {
      userName: userName.value,
      password: password.value,
    })
    .then((response) => {
      modelValue.value = false;
    })
    .catch((error) => {
      errorMessage.value = error.response.data;
    });
}
</script>

<style></style>
