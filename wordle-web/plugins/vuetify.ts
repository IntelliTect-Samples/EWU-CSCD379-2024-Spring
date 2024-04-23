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

const EmeraldIsle: ThemeDefinition = {
  dark: false,
  colors: {
    primary: "#8bc34a",
    secondary: "#ffeb3b",
    accent: "#ffc107",
    error: "#ff5722",
    warning: "#e91e63",
    info: "#03a9f4",
    success: "#4caf50",
    lose: colors.red.lighten1,
    win: colors.green.accent3,
    correct: colors.lightGreen.darken3,
    misplaced: colors.amber.lighten2,
    wrong: colors.lime.darken2,
    unknown: colors.lime.lighten3,
    background: colors.lime.accent1,
  },
};
const AmethystTwilightMist: ThemeDefinition = {
  dark: false,
  colors: {
    primary: "#4A148C",
    secondary: "#AA00FF",
    accent: "#ffc107",
    error: "#ff5722",
    warning: "#e91e63",
    info: "#03a9f4",
    success: "#4caf50",
    lose: colors.red.lighten1,
    win: colors.green.accent3,
    correct: colors.lightGreen.darken3,
    misplaced: colors.amber.lighten2,
    wrong: colors.lime.darken2,
    unknown: colors.lime.lighten3,
    background: colors.purple.lighten4,
  },
};


export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: "dark",
      themes: {
        DeepSeaDive,
        EmeraldIsle,
        AmethystTwilightMist,
        light: {
          dark: false,
          colors: {
            primary: colors.pink.accent2,
            secondary: colors.pink.accent1,
            accent: colors.pink.accent3,
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
            accent: colors.pink.accent3,
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
