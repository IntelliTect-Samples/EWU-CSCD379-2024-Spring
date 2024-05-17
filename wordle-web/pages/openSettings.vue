<template>
  <v-dialog v-model="settingsDialog" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-text> SETTINGS </v-card-text>
      </v-sheet>
      <v-card-text>
        <v-container class="button-container">
          <v-btn @click="themeSettings('light')">Light Mode</v-btn>
          <v-btn @click="themeSettings('dark')" >Dark Mode</v-btn>
          <v-btn @click="themeSettings('bCasual')" >Business Casual</v-btn>
          <v-btn @click="themeSettings('hillBilly')" >Hill Billy</v-btn>
        </v-container>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify/framework";
import nuxtStorage from "nuxt-storage";
import { ref } from "vue";

const settingsDialog = ref(false);
const theme = useTheme();

function themeSettings(item: string) {
  theme.global.name.value = item;
  nuxtStorage.localStorage.setData("themes", theme.global.name.value);
}
</script>

<style scoped>
.button-container {
  display: flex;
  justify-content: space-between;
}
</style>
