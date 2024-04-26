<template>
  <div>
    <div class="pa-3">
      <p>{{ sentence }}</p>
    </div>
    <v-btn icon="mdi-arrow-left" @click="router.push('/')" />
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';

const router = useRouter();
const sentence = "This wordle web app is for my EWU web devlopment class, we have the greatest teacher to ever do it, her name is Meg!";
</script>
