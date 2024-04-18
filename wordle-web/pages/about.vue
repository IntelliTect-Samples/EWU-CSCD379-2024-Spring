<template>
  <v-card class="mx-auto w-75">
    <v-sheet color="secondary">
      <v-card-title> About </v-card-title>
    </v-sheet>
    <v-card-text>
      Meg is super cool. She knows all the colors and has a cool GitHub profile
      picture :D
    </v-card-text>
    <v-btn @click="router.go(-1)" class="ma-4" color="secondary">Back</v-btn>
  </v-card>
</template>

<script setup lang="ts">
const router = useRouter();
</script>
