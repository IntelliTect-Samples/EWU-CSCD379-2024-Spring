<template>
  <v-container>
  <v-dialog :value="modelValue" @update:value="modelValue = $event" width="500">
    <v-card class="login-card">
      <v-card-title class="headline">Login</v-card-title>
      <v-card-text>
        <v-form @submit.prevent="login">
          <v-text-field
            v-model="username"
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
          <v-btn type="submit" color="primary" class="mt-4">Login</v-btn>
        </v-form>
      </v-card-text>
    </v-card>
  </v-dialog>
  </v-container>
</template>

<script setup lang='ts'>
import { defineProps, ref } from 'vue';
import { useRouter } from 'vue-router';
import TokenScript from "~/scripts/tokenScript";
import axios from "axios";

const { modelValue } = defineProps({
  modelValue: Boolean
});

const username = ref('');
const password = ref('');
const router = useRouter();
const errorMsg = ref('');
const tokenService = new TokenScript();

function login() {
  errorMsg.value = "";
  axios.post("/Token/GetToken", {
    username: username.value,
    password: password.value
  })
    .then(response => {
      tokenService.setToken(response.data.token);
      modelValue.value = false;
    })
    .catch(error => {
      errorMsg.value = error.response.data;
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

