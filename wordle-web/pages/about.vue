<template>
  <v-container>
    <v-card
      color="secondary"
      class="mx-auto mt-8 pa-8 rounded text-center"
      elevation="4"
    >
      <v-img
        src="../public/logo.svg"
        alt="Logo"
        max-width="240"
        max-height="130"
        class="mx-auto"
      ></v-img>

      <v-card-text class="text-h6 text-center">
        This class project is about exploring more of Vue's features and using
        Axios for routes. We added a SQL database and various controllers to the
        back end! We added a leaderboard to the game and played with animations
        and more styling. Meg is amazing and someone we look up to as women in
        CS
        <v-icon small class="text-red">mdi-heart</v-icon> She does a great job
        explaining things in class, and we really appreciate her immense
        knowledge!
      </v-card-text>
      <v-card-text>
        <span class="text-white text-h5 bg-primary pa-1">
          #MEGFORPRESIDENT
        </span>
      </v-card-text>
      <v-spacer />
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
