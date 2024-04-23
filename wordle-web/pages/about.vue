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
          style="
            color: #ffffff;
            font-size: 23px;
            padding: 20px 20px;
            line-height: 1.5;
          "
        >
          <v-row>
            <v-col cols="12">
              This class project is about exploring more of Vue and Vuetify
              features and styling our wordle website more! We are adding more
              pages and creating more options for users on the website, while
              also creating more features with our game, like word lists and a
              keyboard on the UI. Meg is amazing and someone we look up to as
              women in CS
              <v-icon small class="red--text">mdi-heart</v-icon> She does a
              great job explaining things in class, and we really appreciate her
              immense knowledge!
            </v-col>
            <v-col cols="12">
              <span
                style="
                  font-weight: bold;
                  background-color: #121212;
                  color: #ffffff;
                  padding: 5px 6px;
                  border-radius: 4px;
                "
              >
                #MEGFORPRESIDENT
              </span>
            </v-col>
          </v-row>
        </v-card-text>
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
