<template>
  <v-container>
    <v-dialog v-model="isDialogVisible" width="500">
      <v-card class="login-card">
        <v-card-title class="headline">Login</v-card-title>
        <v-card-text>
          <v-form @submit.prevent="login">
            <v-text-field
              v-model="username"
              label="Username"
              required
            ></v-text-field>
            <v-text-field
              v-model="password"
              label="Password"
              type="password"
              required
            ></v-text-field>
            <v-btn type="submit" color="primary" class="mt-4">Login</v-btn>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-btn @click="showDialog">Open Login Dialog</v-btn> <!-- Button to trigger dialog -->
  </v-container>
</template>
<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import Axios from 'axios';
import TokenScript from '~/scripts/tokenScript';

const isDialogVisible = ref(false); // Local state for dialog visibility
const username = ref('');
const password = ref('');
const errorMsg = ref('');
const router = useRouter();
const tokenService = new TokenScript();

function login() {
  errorMsg.value = '';
  Axios.post('/Token/GetToken', {
    username: username.value,
    password: password.value,
  })
    .then(response => {
      tokenService.setToken(response.data.token);
      isDialogVisible.value = false;
    })
    .catch(error => {
      errorMsg.value = error.response.data;
    });
}

function showDialog() {
  isDialogVisible.value = true;
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

