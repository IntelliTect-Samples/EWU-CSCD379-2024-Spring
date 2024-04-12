<template>
  <v-card class="mx-auto my-8" elevation="16" max-width="344">
    <v-card-item>
      <v-card-title>Spell Casting Challenge!</v-card-title>
      <v-card-subtitle>
        <strong class="text-deep-purple-accent-4">Cast the correct spell to vanquish the dragon!</strong>
      </v-card-subtitle>
    </v-card-item>

    <v-text-field
      v-model="guess"
      label="Type 'fireball' to cast the spell:"
      outlined
      clearable />
    <v-card-actions>
      <v-spacer />
      <v-btn
        color="deep-purple accent-4"
        variant="elevated"
        elevation="8"
        @click="castSpell()">
        Cast Spell
      </v-btn>
    </v-card-actions>
    <v-card-text>
      {{ feedback }}
    </v-card-text>
    <v-card-text>
      <NuxtLink to="/"> Return to the Guild </NuxtLink>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const guess = ref('');
const feedback = ref('');

function castSpell() {
  if (guess.value.toLowerCase() === 'fireball') {
    feedback.value = 'Success! The dragon is defeated!';
  } else {
    feedback.value = 'The spell fails... Try again!';
  }
  guess.value = ''; // Clear input after attempt
}
</script>
