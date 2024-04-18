<template>
  <NuxtLayout>
    <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify';
import nuxtStorage from 'nuxt-storage';

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? 'dark';
});

function toggleTheme() {
  if (theme.global.name.value === 'light') {
    theme.global.name.value = 'dark';
  } else {
    theme.global.name.value = 'light';
  }

  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}
</script>
