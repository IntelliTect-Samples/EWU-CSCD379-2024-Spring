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
      },
    },
  });
  app.vueApp.use(vuetify);
});
