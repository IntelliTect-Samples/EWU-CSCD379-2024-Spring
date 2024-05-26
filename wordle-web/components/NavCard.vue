<template>
  <v-card
    :color="color"
    :to="`/${route}`"
    class="glow-btn d-flex justify-center align-center flex-column pa-3"
    hover
    ripple
    rounded
  >
    <v-icon size="x-large" :icon="icon" />
    <v-card-title class="font-weight-bold">{{ title }}</v-card-title>
  </v-card>
</template>

<style scoped lang="scss"></style>

<script setup lang="ts">
const props = defineProps<{
  title: string;
  icon: string;
  color: string;
}>();

const route = props.title.replace(" ", "");
</script>
