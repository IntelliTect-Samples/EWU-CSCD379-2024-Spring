// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import colors from 'vuetify/lib/util/colors' // Corrected import path

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      themes: {
        light: {
          dark: false,
          colors: {
            primary: colors.pink.accent3, // #E53935
            secondary: colors.pink.accent3, // #FFCDD2
            secondarytwo:colors.pink.accent1
            // Define other colors as needed here
          },
        },
      },
    },
  })
  app.vueApp.use(vuetify)
})