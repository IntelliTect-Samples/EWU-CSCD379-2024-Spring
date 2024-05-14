<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary">

        <v-app-bar-title>Pentagram</v-app-bar-title>
        <template v-slot:prepend>
          <v-btn icon @click="router.push('/')">
            <v-icon size="x-large">mdi-pentagram</v-icon>
          </v-btn>
        </template>
        <v-btn @click="showUserNameDialog = true">{{ userName }}</v-btn>
        <UserNameDialog v-model="showUserNameDialog" />
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon v-bind="props">
              <v-icon>mdi-menu</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="page in pages" :key="page.name" @click="router.push(page.path)">
              <v-list-item-title>{{ page.name }}</v-list-item-title>
            </v-list-item>
            <v-list-item @click="showHelpDialog = true">Help</v-list-item>
          </v-list>
        </v-menu>
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props" icon>
              <v-icon>mdi-compare</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="theme in themes" @click="changeTheme(theme.theme)">
              <v-list-item-title>{{ theme.name }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
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
import { defineProps } from "vue";
import Wordlegame from "./pages/wordleOfTheDay.vue";
const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showUserNameDialog = ref(false);
const userName = ref("guest");
const dark = ref(true)
const props = defineProps<{
  userName: string
  showUserNameDialog: boolean
}>();
provide("userName", userName);


const themes = [
  { name: "default", theme: "dark" },
  { name: "sans", theme: "sansDark" },
  { name: "watermelon", theme: "watermelonDark" },
];

const pages = [
  { name: "Home", path: "/" },
  { name: "About", path: "/about" },
  { name: "Leaderboard", path: "/leaderboard" },
  { name: "wordle of the day", path:"/wordleOfTheDay"}
];
onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  if (defaultTheme) { changeTheme(defaultTheme); }

  var userNameStored = nuxtStorage.localStorage.getData('userName');
  if (userNameStored) {
    userName.value = userNameStored;
    showUserNameDialog.value = false;
  }
  if (userName.value === "guest " || !userNameStored) {
    showUserNameDialog.value = true;
  }

});


function changeTheme(themeName: string) {
  if (dark.value === false) {
    var themeToSet = themeName;
    if (themeToSet === "dark") {
      themeToSet = "light";
    } else {
      themeToSet = themeToSet.replace("Dark", "Light");
      console.log(themeToSet);
    }
    dark.value = false;
    theme.global.name.value = themeToSet;

  } else {
    theme.global.name.value = themeName;
    dark.value = true;
  }
  nuxtStorage.localStorage.setData('theme', theme.global.name.value);

}
function setTheme(themeName: string) {
  theme.global.name.value = themeName;
  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}
function toggleTheme() {
  if (theme.global.name.value === "dark") {
    setTheme("light");
    dark.value = false;
  } else if (theme.global.name.value === "sansLight") {
    setTheme("sansDark");
    dark.value = true;
  } else if (theme.global.name.value === "sansDark") {
    setTheme("sansLight");
    dark.value = false;
  } else if (theme.global.name.value === "watermelonLight") {
    setTheme("watermelonDark");
    dark.value = true;
  } else if (theme.global.name.value === "watermelonDark") {
    setTheme("watermelonLight");
    dark.value = false;
  } else {
    setTheme("dark");
    dark.value = true;
  }
}

</script>
