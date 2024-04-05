<template>
  <div>
    <NuxtWelcome />
  </div>
</template>

<script setup lang="ts">


  import { Game } from './scripts/Game';
  const game: Game = new Game("JUMBO");

  game.guess("JUMBO");

  console.log(game);
</script>
