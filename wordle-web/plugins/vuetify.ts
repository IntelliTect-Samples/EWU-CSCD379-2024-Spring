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
            wrong: "#afafaf",
            unknown: "#d6d6d6"
          },
        },
        mysticMeadowDark: {
          colors: {
            background: "#000000",
            surface: "#212121",
            primary: "#41713c",
            secondary: "#E6883B",
            error: "#C53F3F",
            info: "#366DAA",
            success: "#45A66E",
            warning: "#E5A73B",
            correct: "#45A66E",
            misplaced: "#E5A73B",
            wrong: "#616161",
            unknown: "#424242"
          },
        },
        enchantedEclipseLight: {
          colors: {
            primary: "#ffb84d",
            secondary: "#8969d7",
            error: "#FF6f6f",
            info: "#5b9ee8",
            success: "#76ce7d",
            warning: "#FFd54f",
            correct: "#76ce7d",
            misplaced: "#ffd54f",
            wrong: "#afafaf",
            unknown: "#d6d6d6"
          },
        },
        enchantedEclipseDark: {
          colors: {
            background: "#000000",
            surface: "#212121",
            primary: "#d6872e" ,
            secondary: "#5d45a6",
            error: "#ab3030",
            info: "#3a74ad",
            success: "#4f8b58",
            warning: "#d8a331",
            correct: "#4f8b58",
            misplaced: "#d8a331",
            wrong: "#616161",
            unknown: "#424242"
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
