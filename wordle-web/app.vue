<template>
  <NuxtLayout>
    <v-app class="myFontDefault">
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
import { provide, ref, watch, onMounted, inject } from "vue";
const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showUserNameDialog = ref(false);
const userName = ref("guest");

provide("userNameValue", userName.value);
provide("userName", userName);
provide("showUserNameDialog", showUserNameDialog.value);


const themes = [
  { name: "default", theme: "dark" },
  { name: "sans", theme: "sansDark" },
  { name: "watermelon", theme: "jarringDark" },
];

const pages = [
  { name: "Home", path: "/" },
  { name: "About", path: "/about" },
  { name: "Leader Board", path: "/leaderboard" },
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
  theme.global.name.value = themeName;
  nuxtStorage.localStorage.setData('theme', themeName)
}
function toggleTheme() {
  if (theme.global.name.value === "dark") {
    changeTheme("light");
  } else if (theme.global.name.value === "sansLight") {
    changeTheme("sansDark");
  } else if (theme.global.name.value === "sansDark") {
    changeTheme("sansLight");
  } else if (theme.global.name.value === "jarringLight") {
    changeTheme("jarringDark");
  } else if (theme.global.name.value === "jarringDark") {
    changeTheme("jarringLight");
  } else {
    changeTheme("dark");
  }
}

</script>
