<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>

        <v-app-bar-title>WordleApp</v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/wordEditor')">Word Editor</v-btn>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
        <v-btn icon="mdi-login" @click="showLoginDialog = true" /> 
      </v-app-bar>
       <v-dialog v-model="showLoginDialog" max-width="600px">
        <Login @login="handleLogin" />
      </v-dialog>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
import Login from './components/Login.vue';

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showLoginDialog = ref(false);
const user = ref(null);

const handleLogin = (userInfo) => {
  user.value = userInfo;
  showLoginDialog.value = false;
};

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
</script>
