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
            secondary: "#FF5722",
            error: "#FF5252",
            info: "#2196F3",
            success: "#4CAF50",
            warning: "#FFC107",
          },
        },
        dark: {
          colors: {
            primary: "#673AB7",
            secondary: "#FF5722",
            error: "#FF5252",
            info: "#2196F3",
            success: "#4CAF50",
            warning: "#FFC107",
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
