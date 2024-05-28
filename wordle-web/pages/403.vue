<template>
    <v-container class="d-flex justify-center align-center">
      <v-row>
        <v-col cols="12" class="text-center">
          <v-icon large class="mb-4">mdi-alert-circle-outline</v-icon>
          <h2 class="display-2">403 | Forbidden</h2>
          <p class="subtitle-1">You do not have permission to access this page.</p>
          <v-btn color="primary" @click="goHome">Go Home</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script setup>
  import { useRouter } from 'vue-router';
  
  const router = useRouter();
  
  const goHome = () => {
    router.push('/');
  };
  </script>
  