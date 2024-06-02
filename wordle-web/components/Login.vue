<template>
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
</template>

<script setup lang='ts'>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const username = ref('');
const password = ref('');
const router = useRouter();

const login = () => {
  // Replace with actual login logic
  const userInfo = {
    username: username.value,
    birthdate: '2000-01-01', // Replace with actual birthdate
    claims: ['MasterOfTheUniverse'] // Replace with actual claims
  };
  // Emit the login event with the user info
  emit('login', userInfo);
};
</script>

<style scoped>
.login-card {
  max-width: 600px;
  min-width: 400px;
  margin: 0 auto;
  padding: 20px;
}
</style>

