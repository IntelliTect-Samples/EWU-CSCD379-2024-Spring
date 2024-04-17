<template>
  <v-row
    class="justify-center"
    v-for="(keyboardRow, rowIndex) in keyboardKeys"
    :key="rowIndex"
    dense
  >
    <v-col
      cols="auto"
      v-for="key in keyboardRow"
      :key="key"
      :class="'ml-1 px-0'"
    >
      <v-btn color="grey">
        {{ key }}
      </v-btn>
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { useDisplay } from "vuetify";

const display = useDisplay();

const keyboardKeys = [
  ["Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P"],
  ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
  ["Z", "X", "C", "V", "B", "N", "M", "👈"],
];
</script>
