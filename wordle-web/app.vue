<template>
  <NuxtLayout>
  
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>
        <v-app-bar-title @click="router.push('/')">
          Wordle Web
          <v-icon @click="router.push('/')">
            mdi-lightbulb-on-outline
          </v-icon>
        </v-app-bar-title>
        <v-btn icon="mdi-weather-night" @click="toggleTheme" />
      </v-app-bar>
      
      <v-navigation-drawer
        expand-on-hover
        rail
      >
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
          <v-list-item prepend-icon="mdi-cog-outline" title="Settings" @click="router.push('/openSettings')"></v-list-item>
          <v-list-item prepend-icon="mdi-help-circle" title="About" @click="showHelpDialog = router.push('/aboutPage')"></v-list-item>
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
import nuxtStorage from 'nuxt-storage';

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
var menuOpen= ref(false);
var settingsDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function openMenu(){
  menuOpen = true;
}

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
  // function toggleMenu() {
  //   menuOpen.value=! menuOpen.value;
  // }

</script>
