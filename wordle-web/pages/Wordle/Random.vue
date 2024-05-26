<template>
  <Game :isDaily="false" />
</template>
<script setup lang="ts">
useHead({
  title: "Random Wordle",
  meta: [{ name: "description", content: "Cool site!" }],
});
</script>
