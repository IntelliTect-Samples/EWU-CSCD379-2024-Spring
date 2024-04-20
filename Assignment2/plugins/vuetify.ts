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
        rainbow: {
          colors: {
            primary: "#FF0000",
            secondary: "#FF8300",
            error: "#FBFF00",
            info: "#61FF00",
            success: "#00FF0F",
            warning: "#00FFDC",
            correct:"#0083FF",
            misplaced:"#A200FF",
            wrong:"#FF00EC",
            unknown: "#775D1C"
          },
        },
        noir: {
          colors: {
            primary: "#000000",
            secondary: "#000000",
            error: "#C7C7C7",
            info: "#ADADAD",
            success: "#919191",
            warning: "#777777",
            correct:"#FFFFFF",
            misplaced:"#505050",
            wrong:"#262626",
            unknown: "#000000"
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
