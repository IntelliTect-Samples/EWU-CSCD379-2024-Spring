<template>
    <v-container>
        <v-card color="secondary"
                class="mx-auto mt-8 w-75 pa-8 rounded text-center"
                elevation="4">
            <v-card-title class="text-h3 mb-3"> About </v-card-title>

            <v-card-text class="text-center">
                This class project is about exploring more of Vue and Vuetify features
                and styling our wordle website more! We are adding more pages and
                creating more options for users on the website, while also creating more
                features with our game, like word lists and a keyboard on the UI. Meg is
                amazing and someone we look up to as women in CS
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
                <v-btn color="white"
                       class="bg-primary pa-2 px-5"
                       to="/"
                       text="Go Home" />
            </v-card-actions>
        </v-card>
    </v-container>
</template>