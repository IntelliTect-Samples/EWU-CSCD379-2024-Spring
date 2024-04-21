<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar app color="primary" :elevation="2">
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        
        <v-toolbar-title>
          <v-avatar>
            <v-icon color = "secondary">mdi-book</v-icon>
          </v-avatar>
          WordleApp
        </v-toolbar-title>

        <v-spacer></v-spacer>

        <v-btn icon @click="router.push('/')">
          <v-icon>mdi-home</v-icon>
        </v-btn>

        <v-btn icon @click="router.push('/about')">
          <v-icon>mdi-information</v-icon>
        </v-btn>

        <v-btn icon @click="openSettingsDialog">
          <v-icon>mdi-cog</v-icon>
        </v-btn>

        <v-btn icon>
          <v-icon>mdi-dots-vertical</v-icon>
        </v-btn>
      </v-app-bar>

      <v-navigation-drawer v-model="drawer" app>
        <v-list>
          <v-list-item link @click="router.push('/')">
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>
          
          <v-list-item link @click="router.push('/about')">
            <v-list-item-icon>
              <v-icon>mdi-information</v-icon>
            </v-list-item-icon>
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-main>
        <NuxtPage />
      </v-main>

      <v-dialog v-model="settingsDialog" max-width="500">
        <v-card>
          <v-card-title>Settings</v-card-title>
          <v-card-text>
            <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
            Change between light and dark theme
            <br>
            <v-btn icon="mdi-pine-tree"/>
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" @click="settingsDialog = false">Close</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const theme = useTheme();
const showHelpDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
import { useRouter } from "vue-router";
import { ref } from "vue";

const drawer = ref(false);
const router = useRouter();
const settingsDialog = ref(false);
function openSettingsDialog() {
  settingsDialog.value = true;
}
</script>
