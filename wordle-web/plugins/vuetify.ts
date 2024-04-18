// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css'

import 'vuetify/styles'
import { createVuetify } from 'vuetify'

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: 'dark',
      themes: {
        light: {
          colors: {
            primary: "#C2185B",
            secondary: "#8E24AA",
            error: "#DD2C00",
            info: "#64B5F6",
            success: "#4CAF50",
            correct: "#4CAF50",
            misplaced: "#FFFF00",
            wrong: "#BDBDBD",
            unknown: "#d6d6d6"
          },
        },
        dark: {
          colors: {
            primary: "#C2185B",
            secondary: "#8E24AA",
            error: "#DD2C00",
            info: "#64B5F6",
            success: "#4CAF50",
            correct: "#4CAF50",
            misplaced: "#FFFF00",
            wrong: "#757575",
            unknown: "#424242"
          }
        }
      }
    }
  })
  app.vueApp.use(vuetify)
})
