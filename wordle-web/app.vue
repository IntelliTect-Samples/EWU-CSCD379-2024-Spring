<template>
  <NuxtLayout>
    <v-app class="myFont">
      <v-app-bar color="primary">
        
        <v-app-bar-title>Pentagram</v-app-bar-title>
        <template v-slot:prepend>
          <v-icon size="x-large">mdi-pentagram</v-icon>
        </template>
        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/game')">About</v-btn>
        <!-- create dropdown menu to dispay all themes-->
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props" icon>
              <v-icon>mdi-compare</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="theme in themes"  @click="changeTheme(theme.theme)">
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
  { name: "default", theme: "dark"},
  { name: "sans", theme: "sansDark"},
  { name: "watermelon", theme: "jaringDark"},
];
onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? "dark";
});

function changeTheme(themeName: string) {
  theme.global.name.value = themeName;
  nuxtStorage.localStorage.setData('theme', themeName);
}

function toggleTheme() {
  if (theme.global.name.value === "dark") {
    changeTheme("light");
  } else if(theme.global.name.value === "sansLight") {
    changeTheme("sansDark");
  } else if(theme.global.name.value === "sansDark") {
    changeTheme("sansLight");
  } else if(theme.global.name.value === "jaringLight") {
    changeTheme("jaringDark");
  } else if(theme.global.name.value === "jaringDark") {
    changeTheme("jaringLight");
  } else {
    changeTheme("dark");
  }
}

</script>
<style>
.myFont {
  font-family: 'Pentagram';
}
</style>