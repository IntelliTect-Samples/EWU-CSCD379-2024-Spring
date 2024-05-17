<template>
  <v-card>
    <v-card-title>Hello Welcome to Test</v-card-title>
    <v-card-actions>
      <v-btn>sdf</v-btn>
    </v-card-actions>
    <ClassExamplePlayground
      @clicked="clicked"
      @nope="console.log('nope')"
      @okay="console.log('okay clicked')"
    >
      <template #text> hello world </template>
      I'm inside a card!
    </ClassExamplePlayground>
  </v-card>
</template>

<script setup lang="ts">
function clicked(clickMessage: string) {
  console.log(clickMessage);
}
</script>
