<template>
  <v-container class="elevation-4 d-flex">
    <v-col>
      {{ word.word }}
    </v-col>
    <v-col>
      <v-chip>{{ word.isCommon ? "Common" : "Uncommon" }}</v-chip>
    </v-col>
    <v-col>
      <v-btn>Edit Common Flag</v-btn>
      <v-btn>Delete Word</v-btn>
    </v-col>
  </v-container>
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";

defineProps<{
  word: WordDto;
}>();
</script>
