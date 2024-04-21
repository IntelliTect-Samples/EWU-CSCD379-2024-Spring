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
        ocean: {
          colors: {
            primary: "#0D47A1",
            secondary: "#FF6E40",
            error: "#B71C1C",
            info: "#0288D1",
            success: "#388E3C",
            warning: "#FFD600",
            correct: "#388E3C",
            misplaced: "#FFD600",
            wrong: "#E65100",
            unknown: "#757575"
          },
        },
        forest: {
          colors: {
            primary: "#388E3C",
            secondary: "#FFC107",
            error: "#B71C1C",
            info: "#0288D1",
            success: "#4CAF50",
            warning: "#FFA000",
            correct: "#4CAF50",
            misplaced: "#FFA000",
            wrong: "#795548",
            unknown: "#9E9E9E"
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
