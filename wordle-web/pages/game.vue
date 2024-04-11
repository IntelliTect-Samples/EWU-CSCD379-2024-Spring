<template>
  <v-card class="mx-auto my-8" elevation="16" max-width="344">
    <v-card-item>
      <v-card-title>LexiQuest: The Spell of Truth</v-card-title>
      <v-card-subtitle>
        <strong class="text-deep-purple-accent-4">Cast the correct spell to reveal the hidden truth!</strong>
      </v-card-subtitle>
    </v-card-item>

    <v-text-field
      v-model="guess"
      label="Enter your spell (guess):"
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
    <v-card-text v-if="isCorrect">
      <p>{{ feedback }}</p>
      <p>You see the creature wince as your spell hits its mark! Onward to the next challenge!</p>
    </v-card-text>
    <v-card-text v-else>
      <p>{{ feedback }}</p>
      <p>The magic fizzles... nothing happens. Try again to master the spell!</p>
    </v-card-text>
    <v-card-text>
      <NuxtLink to="/"> Return to the Guild </NuxtLink>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const correctWord = 'quest';
const guess = ref('');
const feedback = ref('');
const isCorrect = ref(false);

function castSpell() {
  if (guess.value.toLowerCase() === correctWord) {
    feedback.value = 'Perfect!';
    isCorrect.value = true;
  } else {
    feedback.value = 'Incorrect spell!';
    isCorrect.value = false;
  }
  guess.value = ''; // Clear input after casting
}
</script>
