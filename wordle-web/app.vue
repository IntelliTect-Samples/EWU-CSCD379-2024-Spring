<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary">
        <template v-slot:prepend>
          <v-icon size="x-large">mdi-pentagram</v-icon>
        </template>
        <v-app-bar-title>Pentagram</v-app-bar-title>
        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/game')">Pentagram</v-btn>
        <!-- create dropdown menu to dispay all themes-->
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props" icon>
              <v-icon>mdi-compare</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="theme in themes" :key="theme.name" @click="changeTheme(theme.name)">
              <v-list-item-title>{{ theme.name }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
        <v-btn icon="mdi-help-box" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const themes = [
  { name: "light" },
  { name: "dark" },
  { name: "sans"}
];
onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? "dark";
});


function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark"
  } else {
    theme.global.name.value = "light"
  }
}
function changeTheme(themeName: string) {
  theme.global.name.value = themeName;
  nuxtStorage.localStorage.setData('theme', themeName);
}

</script>
