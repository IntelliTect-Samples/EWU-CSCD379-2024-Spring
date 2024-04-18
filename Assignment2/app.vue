<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <!-- <template v-slot:prepend >
          <v-icon color="secondary" @click="router.push('/')"> mdi-bookshelf</v-icon>
        </template> -->

        <v-btn icon="mdi-bookshelf" @click="router.push('/')"></v-btn>

        <v-app-bar-title>
          <v-btn @click="router.push('/')">Wordle</v-btn>
        </v-app-bar-title>

        <v-btn icon="mdi-menu"></v-btn>

      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
const router = useRouter();
</script>
