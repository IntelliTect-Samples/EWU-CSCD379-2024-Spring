<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>

        <v-app-bar-title>WordleApp</v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/test')">Test</v-btn>
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props"> <v-icon>mdi-account</v-icon> </v-btn>
          </template>
          <v-card>
            <v-card-text>
              <v-btn
              v-if="!tokenService.isLoggedIn()"
                @click="showLoginDialog = true"
                class="mb-5"
                flat
                color="primary"
              >
                <v-icon> mdi-lock </v-icon>
                Login
              </v-btn>
              <div v-else>
                {{  tokenService.getUserName() }}
              </div>
              <br />
              <v-btn @click="toggleTheme" class="mb-5" flat color="primary">
                <v-icon> mdi-theme-light-dark </v-icon>
                Theme
              </v-btn>
              <br />
              <v-btn @click="showHelpDialog = true" flat color="primary">
                <v-icon> mdi-help-circle </v-icon>
                Help
              </v-btn>
            </v-card-text>
          </v-card>
          <HelpDialog v-model="showHelpDialog" />
        </v-menu>
        <SigninDialog v-model="showLoginDialog" />
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
import TokenService from "@/scripts/TokenService";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showLoginDialog = ref(false);

const tokenService = new TokenService();

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
