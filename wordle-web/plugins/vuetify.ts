// import this after install `@mdi/font` package
import "@mdi/font/css/materialdesignicons.css";
import colors from "vuetify/lib/util/colors"; // Corrected import path

import "vuetify/styles";
import { createVuetify } from "vuetify";

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: "light",
      themes: {
        light: {
          colors: {
            primary: "#F50057",
            secondary: "#F48FB1",
            error: "#FF5252",
            info: "#2196F3",
            success: "#4CAF50",
            warning: "#FFC107",
            correct: "#4CAF50",
            misplaced: "#FFC107",
            wrong: "#BDBDBD",
            unknown: colors.grey.lighten3,
          },
        },
        dark: {
          colors: {
            primary: "#F50057",
            secondary: "#F48FB1",
            error: "#FF5252",
            info: "#2196F3",
            success: "#4CAF50",
            warning: "#FFC107",
            correct: "#4CAF50",
            misplaced: "#FFC107",
            wrong: "#616161",
            unknown: colors.grey.darken3,
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
