<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="#FFFFFF"> mdi-flower-poppy </v-icon>
        </template>

        <v-app-bar-title>Johanne & Alexa's Wordle</v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/about')">About</v-btn>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-cog" @click="showSettingsDialog = true" />
        <SettingsDialogue v-model="showSettingsDialog" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>

</template>
