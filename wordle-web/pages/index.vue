<template>
  <Game :option="GameOption.WordleOfTheDay" />
</template>

<script setup lang="ts">
import { GameOption } from '~/scripts/game';
</script>
