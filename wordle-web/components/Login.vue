<template>
  <v-dialog v-model="modelValue" width="500">
  <v-card class="login-card">
    <v-card-title class="headline">Login</v-card-title>
    <v-card-text>
      <v-form @submit.prevent="login">
        <v-text-field
          v-model="userName"
          @keyup.stop
          label="Username"
          required
        ></v-text-field>
        <v-text-field
          v-model="password"
          @keyup.stop
          label="Password"
          type="password"
          required
        ></v-text-field>
        <v-btn type="submit" color="primary" class="mt-4" @click="login">Login</v-btn>
      </v-form>
    </v-card-text>
  </v-card>
  </v-dialog>
</template>

<script setup lang='ts'>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import TokenScript from "~/scripts/tokenScript";
import axios from "axios";


const modelValue = defineModel<boolean>({ default: false });
const username = ref('');
const password = ref('');
const router = useRouter();
const errorMsg = ref('');
const tokenService = new TokenScript();

function login() {
  errorMsg.value = "";
  axios.post("/Token/GetToken", {
    username: userName.value,
    password: password.value
  })
    .then(response => {
      tokenService.setToken(reponse.data.token);
      modelValue.value = false;
    })
    .catch(error => {
      errorMsg.value = error.reponse.data;
    });
}
</script>

<style scoped>
.login-card {
  max-width: 600px;
  min-width: 400px;
  margin: 0 auto;
  padding: 20px;
}
</style>

