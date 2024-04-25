// import this after install `@mdi/font` package
import "@mdi/font/css/materialdesignicons.css";

import "vuetify/styles";
import { createVuetify } from "vuetify";

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: "light",
      themes: {
        light: {
          colors: {
            primary: "#1BF0BE",
            secondary: "#FFE605",
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
        default: {
          colors: {
            backgoundColor:"#1BF0BA",
            primary: "#1BF0BE",
            secondary: "#FFE605",
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
            primary: "#1BF0BE",
            secondary: "#424242",
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
        hadi: {
          colors: {
            primary: "#CD853F",
            secondary: "#800080",
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
        hillBilly: {
          colors: {
            primary: "#006400",
            secondary: "#FFE605",
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
        bCasual: {
          colors: {
            primary: "#00008B",
            secondary: "#FFFDD0",
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
