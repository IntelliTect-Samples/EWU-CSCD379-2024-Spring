<template>
  <NuxtLayout>
    <v-app>
      <NuxtPage />
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">

  //import type { NuxtLayout, NuxtPage } from '#build/components';
  import { Game } from './scripts/game';
  const game: Game = new Game("JUMBO");

  game.guess("JUMBO");

  console.log(game);
</script>
