<template>
  <NuxtLayout>
  
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        
        <template v-slot:prepend>
         
        </template>
        <v-app-bar-title @click="router.push('/')">
          Wordle Web
          <v-icon @click="router.push('/')">
            mdi-lightbulb-on-outline
          </v-icon>
        </v-app-bar-title>
        <v-btn icon="mdi-weather-night" @click="toggleTheme()" />
      </v-app-bar>
      
      <v-navigation-drawer expand-on-hover rail>
        <v-list>
          <v-list-item
            prepend-avatar="https://randomuser.me/api/portraits/women/86.jpg"
            subtitle="Webdev"
            title="Cynthia"
          ></v-list-item>
          <v-list-item
            prepend-avatar="https://randomuser.me/api/portraits/men/88.jpg"
            subtitle="Webdev"
            title="Hadi"
          ></v-list-item>
        </v-list>

        <v-divider></v-divider>
        <v-list density="compact" nav>
          <v-list-item prepend-icon="mdi-home" title="Home" @click="router.push('/')"></v-list-item>
          <v-list-item prepend-icon="mdi-cog-outline" title="Settings" @click="settingsDialog = true"></v-list-item>
          <v-list-item prepend-icon="mdi-help-circle" title="About" @click="showHelpDialog = router.push('/aboutPage')"></v-list-item>
        </v-list>
      </v-navigation-drawer>

      <!-- Settings Dialog -->
      <v-dialog v-model="settingsDialog" max-width="500">
        <v-card>
          <v-sheet color="primary">
            <v-card-text> Settings </v-card-text>
          </v-sheet>
          <v-card-text>
            <v-container>
              <v-btn @click="themeSettings('light')">Light Mode</v-btn>
              <v-btn @click="themeSettings('dark')">Dark Mode</v-btn>
              <v-btn @click="themeSettings('bCasual')">Business Casual</v-btn>
              <v-btn @click="themeSettings('hillBilly')">Hill Billy</v-btn>
            </v-container>
          </v-card-text>
        </v-card>
      </v-dialog>
      
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from 'nuxt-storage';
import { ref } from "vue";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const settingsDialog = ref(false);
const darkMode = ref(false);
const selected = ref(null);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function toggleTheme() {
  theme.global.name.value = theme.global.name.value === "light" ? "dark" : "light";
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

function themeSettings(item: string) {
  theme.global.name.value = item;
  nuxtStorage.localStorage.setData("themes", theme.global.name.value);
}

function closeSettingsDialog() {
  settingsDialog.value = false;
}
</script>
