<template>
  <v-container>
    <v-card
      color="secondary text-primary"
      class="mx-auto mt-8 w-75 pa-8 rounded text-center"
      elevation="4"
    >
      <v-card-text class="text-center">
        <v-card-title
          class="text-h3"
          style="color: #ffffff; font-size: 24px; margin-bottom: 20px"
        >
          About
        </v-card-title>
        <v-card-text
          class="font-italic"
          style="color: #ffffff; font-size: 20px; padding-top:20px"
        >
          This class project is about exploring more of Vue and Vuetify features
          and styling our wordle website more! We are adding more pages and
          creating more features for users on the website, while also creating
          more features with our game, like word lists and a keyboard on the UI.
          Meg is amazing and someone I look up to as a women in CS! She does a
          great job explaining things in class, and I really appreciate her immense knowledge! 
          #MEGFORPRESIDENT
        </v-card-text>
      </v-card-text>
      <v-spacer />
      <!-- Additional content can go here -->
      <v-card-actions class="d-flex justify-center">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Go Home"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>
