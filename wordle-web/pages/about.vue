<template>
  <v-card class="mx-auto w-75">
    <v-sheet color="secondary">
      <v-card-title> About </v-card-title>
    </v-sheet>
    <v-card-text>
      This class project is wordle! Except we renamed it to Whurdle because it's
      a hurdle you'll have to jump over. There's a cheat you can do to look at
      the possible words based on your previous guesses and the current letters
      that are typed in. There's also three color themes :) Meg is super cool.
      She knows all the colors and has a cool GitKraken profile picture :D
    </v-card-text>
    <v-btn @click="router.go(-1)" class="ma-4" color="secondary">Back</v-btn>
  </v-card>
  <v-container class="Whurdle mx-auto w-75">
    <img  src="../public/WhurdleCompany.png" alt="logo" width="150" height="150"/>
  </v-container>
</template>

<script setup lang="ts">
const router = useRouter();
</script>
<style>
.Whurdle {
  display: flex;
  justify-content: center;
  align-items: center;
}
.v-card {
  background-color: var(--v-card-base) !important;
}
</style>
