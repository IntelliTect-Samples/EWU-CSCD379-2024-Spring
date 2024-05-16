// import this after installing `@mdi/font` package
import "@mdi/font/css/materialdesignicons.css";

import "vuetify/styles";
import { createVuetify } from "vuetify";

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: 'Dark',  // Set the default theme
      themes: {
        'White': {
          dark: false,
          colors: {
              primary: "#FFFFFF",
              secondary: "#424242",
              accent: "#FFC107",
              error: "#FF5722",
              info: "#03A9F4",
              success: "#4CAF50",
              warning: "#FFEB3B",
              correct: "#4CAF50",
              misplaced: "#FFEB3B",
              wrong: "#FF5722",
              unknown: "#BDBDBD" 
          },
        },
        'Dark': {
          dark: true,
          colors: {
            primary: "#212121",
            secondary: "#424242",
            accent: "#616161",
            error: "#D32F2F",
            info: "#FF0000",
            success: "#388E3C",
            warning: "#FFA000",
            correct: "#388E3C",
            misplaced: "#FFA000",
            wrong: "#D32F2F",
            unknown: "#616161"
          },
        },
        'Forest': {
          dark: false,
          colors: {
            primary: "#388E3C",
            secondary: "#4A5D23",
            accent: "#C5E1A5",
            error: "#EF5350",
            info: "#29B6F6",
            success: "#2E7D32",
            warning: "#FFCA28",
            correct: "#2E7D32",
            misplaced: "#C5E1A5",
            wrong: "#EF5350",
            unknown: "#9E9E9E"
          },
        },
        'Merlin': {
          dark: true,
          colors: {
            primary: "#3E2723",
            secondary: "#795548",
            accent: "#D7CCC8",
            error: "#E53935",
            info: "#1E88E5",
            success: "#43A047",
            warning: "#FFB300",
            correct: "#43A047",
            misplaced: "#D7CCC8",
            wrong: "#E53935",
            unknown: "#3E2723"
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});