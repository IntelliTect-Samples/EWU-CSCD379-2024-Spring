<template>
    <v-card>
        <v-card-title>Pentagram</v-card-title>
    </v-card>
    <NuxtLayout>
      <v-app>
        <v-btn @click="router.push('/')">Home</v-btn>
        <NuxtPage />
      </v-app>
    </NuxtLayout>
</template>

<script setup lang="ts">
  const router = useRouter()
  
  </script>