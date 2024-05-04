<template>
  <v-app>
    <!-- Existing App Bar -->
    <v-app-bar color="primary" :elevation="2">
      <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
        <v-icon>mdi-flower-poppy</v-icon>
        Aesthetic Wordle
      </v-app-bar-title>
      <v-spacer></v-spacer>

      <v-btn icon @click="showHelpDialog = true">
        <v-icon>mdi-help-circle</v-icon>
      </v-btn>
      <v-btn icon @click="showSettingsDialog = true">
        <v-icon>mdi-cog</v-icon>
      </v-btn>
      <v-btn icon @click="showNameDialog = true">
        <v-icon>mdi-account-edit</v-icon>
      </v-btn>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    </v-app-bar>

    <v-container>
      <v-row>
        <v-col cols="12" class="pa-15 d-flex justify-end">
          <!-- Using v-text for labeling -->
          <v-text
            class="subtitle-2 white--text mr-2 mt-3"
            style="align-self: center"
            >Player Name:</v-text
          >
          <v-chip color="secondary" text-color="white" class="mt-3 mr-3">
            {{ playerName }}
          </v-chip>
        </v-col>
      </v-row>
    </v-container>

    <v-navigation-drawer
      v-model="drawer"
      location="right"
      color="secondary"
      temporary
    >
      <v-list v-for="item in ['About']" :key="item">
        <v-list-item @click="$router.push('/' + item.toLowerCase())">
          <v-list-item-title>{{ item }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main class="mt-5">
      <slot />
    </v-main>

    <NameDialog v-model="showNameDialog" />
    <HelpDialog v-model="showHelpDialog" />
    <SettingsDialogue v-model="showSettingsDialog" />
  </v-app>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const theme = useTheme();
const showHelpDialog = ref(false);
const showSettingsDialog = ref(false);
const showNameDialog = ref(false);
const drawer = ref(false);
const playerName = ref("guest");

onMounted(() => {
  const defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
  const savedName = localStorage.getItem("playerName") || "guest";
  playerName.value = savedName;
});
</script>
