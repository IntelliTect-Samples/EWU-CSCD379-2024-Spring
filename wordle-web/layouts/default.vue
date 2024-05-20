<template>
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
        <v-btn icon @click="showSettingsDialog = true">
          <v-icon>mdi-cog</v-icon>
        </v-btn>
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon v-bind="props">
              <v-icon>mdi-book-open-page-variant</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="page in pages" :key="page.name" @click="router.push(page.path)">
              <v-list-item-title>{{ page.name }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
        <SettingsDialog v-model="showSettingsDialog" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
</template>
<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
import { defineProps } from "vue";
const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showUserNameDialog = ref(false);
const showSettingsDialog = ref(false);
const userName = ref("guest");
var dark = ref(true);
const props = defineProps<{
  userName: string
  showUserNameDialog: boolean
}>();
provide("userName", userName);

const pages = [
  { name: "Home", path: "/" },
  {name: "Never Ending Wordle", path: "/neverEndingWordle"},
  { name: "Wordle Of The Day", path: "/wordleOfTheDay" },
  { name: "Leaderboard", path: "/leaderboard" },
  { name: "How To Play", path: "/helpPage"},
  { name: "About", path: "/about" }
];
onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  if (defaultTheme) { changeTheme(defaultTheme); }
  setDark();
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
function setDark() {
  if (theme.global.name.value.includes("Dark") || theme.global.name.value === "dark") {
    dark.value = true;
  } else {
    dark.value = false;
  }
}
</script>