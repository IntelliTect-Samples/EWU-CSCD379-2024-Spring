<template>
  <v-container>
    <v-card>
      <v-card-title>Hello, Welcome to Pentagram</v-card-title>
      <v-card-subtitle> This is our super basic wordle game called Pentagram. Penta for five, and gram for letter
      </v-card-subtitle>
      <v-card-text>
        This website was built for a school project. we are using vuetify and nuxt to build this website.
        The assignment is to recreate the wordle app: https://www.nytimes.com/games/wordle/index.html
      </v-card-text>
      <v-card-text>One of our instructors is Meghan Woodford, 
        She has been very helpful in teaching the basics and giving us the knowledge to build this website.
        I have never built a website before, so this is all new to me.
      </v-card-text>
      <v-btn color ="primary" @click="router.push('/')">Home</v-btn>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
const router = useRouter();
</script>