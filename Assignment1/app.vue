<template>
  <v-app>
    <NuxtLayout>
      <v-container>
        <v-btn variant="text" @click="router.push('/')">Home</v-btn>
        <v-btn variant="text" @click="router.push('/game')">Mystery Number Madness</v-btn>
      </v-container>
      <NuxtPage />
    </NuxtLayout>
  </v-app>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
const router = useRouter()
</script>
