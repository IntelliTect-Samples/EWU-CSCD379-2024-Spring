// import this after install `@mdi/font` package
import "@mdi/font/css/materialdesignicons.css";

import "vuetify/styles";
import { createVuetify } from "vuetify";

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: "dark",
      themes: {
        light: {
          colors: {
            primary: "#673AB7",
            secondary: "#FF9800",
            error: "#FF5252",
            info: "#2196F3",
            success: "#4CAF50",
            warning: "#FFC107",
            correct:"#4CAF50",
            misplaced:"#FFC107",
            wrong:"#afafaf",
            unknown: "#d6d6d6"
          },
        },
        dark: {
          colors: {
            primary: "#673AB7",
            secondary: "#FF9800",
            error: "#FF5252",
            info: "#2196F3",
            success: "#4CAF50",
            warning: "#FFC107",
            correct:"#4CAF50",
            misplaced:"#FFC107",
            wrong:"#616161",
            unknown: "#424242"
          },
        },
        mysticMeadowLight: {
          colors: {
            primary: "#6EAD5D",
            secondary: "#FF9E57",
            error: "#FF5E5E",
            info: "#4DA1E0",
            success: "#5AC995",
            warning: "#FFCF5C",
            correct: "#5AC995",
            misplaced: "#FFCF5C",
            wrong: "#7C7C7C",
            unknown: "#A5A5A5"
          },
        },
        mysticMeadowDark: {
          colors: {
            primary: "#41713c",
            secondary: "#E6883B",
            error: "#C53F3F",
            info: "#366DAA",
            success: "#45A66E",
            warning: "#E5A73B",
            correct: "#45A66E",
            misplaced: "#E5A73B",
            wrong: "#4D4D4D",
            unknown: "#707070"
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
