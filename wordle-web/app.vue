<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>

        <v-app-bar-title></v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/wordOfTheDay')">WOTD</v-btn>
        <!--<v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />   -->
        <v-app-bar-nav-icon
            color="secondary"
            @click="toggleMenu"
            :class="{ 'rotate': menuOpen}"
          ></v-app-bar-nav-icon>
      </v-app-bar>

      <v-navigation-drawer
        location="right" 
        v-model="menuOpen" app>
        <v-list>
          <v-list-item link @click="router.push('/')">
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>
          <v-list-item link @click="router.push('/wordOfTheDay')">
            <v-list-item-title>WOTD</v-list-item-title>
          </v-list-item>
          <v-list-item link @click="router.push('/instructionsPage')">
            <v-list-item-title>Instructions</v-list-item-title>
          </v-list-item>
          <v-list-item>
            <v-btn @click="showHelpDialog = true">Help</v-btn>
            <HelpDialog v-model="showHelpDialog"/>
          </v-list-item>
          <v-list-item>
            <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
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

//test for workflow pt 2 can delete
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

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}


const toggleMenu = () => {
  menuOpen.value = !menuOpen.value;
}

</script>

<style scoped>
.rotate {
  transform: rotate(90deg);
}
</style>
