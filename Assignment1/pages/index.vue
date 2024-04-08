<template>
    <v-card elevation="16">
      <v-card-title>Hello Welcome to Home</v-card-title>
      <v-btn @click="goToGamePage">Go to Mystery Number Madness</v-btn>
    </v-card>
  </template>
  
  <script setup lang="ts">
  import { useRouter } from 'vue-router'
  const router = useRouter()
  
  const goToGamePage = () => {
    router.push('/game')
  }
  </script>
  