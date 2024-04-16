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
            secondary: "",
            error: "",
            info: "",
            success: "",
          },
        },
        dark: {
          colors: {
            primary: "#C2185B",
            secondary: "",
            error: "",
            info: "",
            success: "",
          }
        }
      }
    }
  })
  app.vueApp.use(vuetify)
})
