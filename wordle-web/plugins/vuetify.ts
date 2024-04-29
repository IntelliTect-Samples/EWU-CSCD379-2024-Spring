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
        },
        sansLight: {
          dark: false,
          colors:{
            primary: "#0071E3",
            secondary: "#FF00FF",
            error: "#FF0000",
            info: "#64B5F6",
            success: "#00E5E5",
            correct: "#00E5E5",
            misplaced: "#FEFE00",
            wrong: "#424242",
            unknown: "#757575"
          }
        },
          sansDark:{
              dark: true,
              colors:{
                primary: "#0071E3",
                secondary: "#FF00FF",
                error: "#FF0000",
                info: "#64B5F6",
                success: "#00E5E5",
                correct: "#00E5E5",
                misplaced: "#FEFE00",
                wrong: "#757575",
                unknown: "#424242"
              }
        },
        jaringLight:{
          dark: false,
          colors:{
            //background: "#516D2F",
            primary: "#263527",
            secondary: "#B64833",
            error: "#FF1a00",
            info: "#64B5F6",
            success: "#EF5C59",
            correct: "#EF5C59",
            misplaced: "#FEaa9e",
            wrong: "#F8F1D7",
            unknown: "#a5bb9b"
          }
        },
        jaringDark:{
          dark: true,
          colors:{
            //background: "#516D2F",
            primary: "#263527",
            secondary: "#B64833",
            error: "#FF1a00",
            info: "#64B5F6",
            success: "#EF5C59",
            correct: "#EF5C59",
            misplaced: "#F8F1D7",
            wrong: "#B8D178",
            unknown: "#a5bb9b"
          }
        },
      }
    }
  })
  app.vueApp.use(vuetify)
})
