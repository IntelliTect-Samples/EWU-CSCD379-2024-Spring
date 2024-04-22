// import this after install `@mdi/font` package
import "@mdi/font/css/materialdesignicons.css";
import colors from "vuetify/lib/util/colors"; // Corrected import path

import "vuetify/styles";
import { createVuetify, type ThemeDefinition } from "vuetify";

const DeepSeaDive: ThemeDefinition = {
  dark: false,
  colors: {
    primary: colors.indigo.accent2,
    secondary: colors.indigo.accent1,
    lose: colors.red.lighten1,
    win: colors.green.accent3,
    correct: colors.blue.darken1,
    misplaced: colors.cyan.darken1,
    wrong: colors.teal.lighten1,
    unknown: colors.lightBlue.lighten3,
    background: colors.blue.lighten4,
  },
};

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: "dark",
      themes: {
        DeepSeaDive,
        light: {
          dark: false,
          colors: {
            primary: colors.pink.accent2,
            secondary: colors.pink.accent1,
            lose: colors.red.lighten1,
            win: colors.green.accent3,
            correct: colors.green.accent4,
            misplaced: colors.yellow.darken1,
            wrong: colors.grey.lighten1,
            unknown: colors.grey.lighten3,
            background: "#FFFFFF",
          },
        },
        dark: {
          dark: true,
          colors: {
            primary: colors.pink.accent2,
            secondary: colors.pink.accent1,
            lose: colors.red.lighten1,
            win: colors.green.accent3,
            correct: colors.green.accent4,
            misplaced: colors.yellow.darken1,
            wrong: colors.grey.darken2,
            unknown: colors.grey.darken3,
            background: "#121212",
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
