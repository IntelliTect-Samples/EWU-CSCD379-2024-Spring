// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css'
import colors from "vuetify/lib/util/colors"; // Corrected import path


import 'vuetify/styles'
import { createVuetify } from 'vuetify'

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      themes: {
        light: {
          dark: false,
          colors: {
            primary: colors.pink.accent3, // #E53935
            secondary: colors.pink.lighten5,
            // Define other colors as needed here
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify)
})
