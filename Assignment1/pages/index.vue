<template>
  <v-card class="mx-8 my-8">
    <h1 class="text-center">Welcome to the Game App</h1>
    <p class="text-center"> Click Wordle button to play </p>
    <div class="d-flex justify-center">
      <v-btn color="pink my-4" variant="elevated" elevation="8" @click="router.push('/game')">Wordle</v-btn>
    </div>
  </v-card>
</template>

<script setup lang="ts">
const router = useRouter();
</script>
