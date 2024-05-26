<template>
  <Game :isDaily="true" />
</template>

<script setup lang="ts">
useHead({
  title: "Daily Wordle",
  meta: [{ name: "description", content: "Cool site!" }],
});
</script>
