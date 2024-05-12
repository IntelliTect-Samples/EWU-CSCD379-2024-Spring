<template>
  <v-app>
    <v-app-bar color="primary" :elevation="2">
      <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
        <v-img
          src="../public/logo.svg"
          alt="Logo"
          max-width="180"
          max-height="95"
        />
      </v-app-bar-title>

      <v-btn icon="mdi-help-circle" @click="$router.push('/instructions')" />
      <v-btn icon="mdi-cog" @click="showSettingsDialog = true" />
      <v-btn icon="mdi-trophy-variant" @click="$router.push('/leaderboard')" />

      <v-app-bar-nav-icon
        variant="text"
        @click="drawer = !drawer"
      ></v-app-bar-nav-icon>
    </v-app-bar>
    <v-navigation-drawer
      v-model="drawer"
      location="right"
      color="secondary"
      temporary
    >
      <v-list
        v-for="item in [
          'Daily Wordle',
          'About',
          'Leaderboard',
          'Instructions',
          'Latest Wordles',
        ]"
        :key="item"
      >
        <v-list-item
          @click="$router.push('/' + item.toLowerCase().replaceAll(' ', ''))"
        >
          <v-list-item-title> {{ item }} </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <slot />
    </v-main>
    <SettingsDialogue v-model="showSettingsDialog" />
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const theme = useTheme();
const showSettingsDialog = ref(false);
const drawer = ref(false);
onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
});
</script>
