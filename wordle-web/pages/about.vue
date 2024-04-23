<template>
  <div>
    <div class="text-box">
      <p>{{ sentence }}</p>
    </div>
    <v-btn icon="mdi-arrow-left" @click="router.push('/')"></v-btn>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';

const router = useRouter();
const sentence = "This wordle web app is for my EWU web devlopment class, we have the greatest teacher to ever do it, her name is Meg!";
</script>

<style scroped>
.text-box {
  border: 1px solid #ccc;
  padding: 10px;
  margin: 10px;
}
</style>
