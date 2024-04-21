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
            primary: colors.pink.accent2,
            secondary: colors.pink.accent1,
            lose: colors.red.lighten1,
            win: colors.green.accent3,
            correct: colors.green.accent4,
            misplaced: colors.yellow.darken1,
            wrong: colors.grey.lighten1,
            unknown: colors.grey.lighten3,
          },
        },
        dark: {
          colors: {
            primary: colors.pink.accent2,
            secondary: colors.pink.accent1,
            lose: colors.red.lighten1,
            win: colors.green.accent3,
            correct: colors.green.accent4,
            misplaced: colors.yellow.darken1,
            wrong: colors.grey.darken2,
            unknown: colors.grey.darken3,
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
