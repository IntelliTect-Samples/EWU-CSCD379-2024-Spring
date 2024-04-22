<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">

        <template v-slot:append>
          <v-app-bar-nav-icon
            color="secondary"
            @click="toggleMenu"
            :class="{ 'rotate': menuOpen}"
          ></v-app-bar-nav-icon>
        </template>
        
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>

        <v-app-bar-title>WordleApp</v-app-bar-title>

        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>
      
      <v-navigation-drawer
        location="right" 
        v-model="menuOpen" app>
        <v-list>
          <v-list-item link @click="router.push('/')">
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>
          <v-list-item link @click="router.push('/about')">
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

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
const menuOpen = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

const toggleMenu = () => {
  menuOpen.value = !menuOpen.value;
}

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>

<style scoped>
.rotate {
  transform: rotate(90deg);
}
</style>
