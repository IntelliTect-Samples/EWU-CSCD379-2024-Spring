<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary">
        <v-icon>mdi-book</v-icon>
        <v-app-bar-title>Pentagram</v-app-bar-title>
        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/game')">Pentagram</v-btn>
        <v-btn icon = "mdi-theme-light-dark" @click="toggleTheme()"></v-btn>
        <v-btn icon ="mdiHelpBox"></v-btn>
      </v-app-bar>
      <NuxtPage />
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs';
const theme = useTheme()
const router = useRouter()
const showHelpDialog = ref(false)

onMounted(() =>{
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

</script>
