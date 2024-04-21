<template>
    <v-container>
      <v-btn @click="goBack">
        <v-icon>mdi-arrow-left</v-icon>
        Back
      </v-btn>
      <h1>About WordleApp</h1>
      <p>
        WordleApp is a class project aimed at demonstrating the usage of Nuxt and Vuetify to create a web application.
        It showcases various features such as routing, theming, navigation drawer, and more.
      </p>
      <p>
        Meg is an amazing individual who provided guidance and support throughout the development process.
        Her expertise and encouragement greatly contributed to the success of this project.
      </p>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { useRouter } from "vue-router";
  
  const router = useRouter();
  
  function goBack() {
    router.go(-1); // Go back to the previous page
  }
  </script>