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
        lightrainbow: {
          colors: {
            primary: "#E91E63",
            secondary: "#03A9F4",
            error: "#FF5252",
            info: "#00BCD4",
            success: "#8BC34A",
            warning: "#FFEB3B",
            correct:"#8BC34A",
            misplaced:"#FFEB3B",
            wrong:"#F44336",
            unknown: "#BDBDBD"
          },
        },
        lightnoir: {
          colors: {
            primary: "#9E9E9E",
            secondary: "#757575",
            error: "#E53935",
            info: "#607D8B",
            success: "#43A047",
            warning: "#FB8C00",
            correct:"#FFFFFF",
            misplaced:"#BDBDBD",
            wrong:"#424242",
            unknown: "#E0E0E0"
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
        darkrainbow: {
          colors: {
            primary: "#9C27B0",
            secondary: "#2196F3",
            error: "#E91E63",
            info: "#00BCD4",
            success: "#4CAF50",
            warning: "#CDDC39",
            correct:"#8BC34A",
            misplaced:"#FFC107",
            wrong:"#FF5722",
            unknown: "#607D8B"
          },
        },
        darknoir: {
          colors: {
            primary: "#616161",
            secondary: "#9E9E9E",
            error: "#D32F2F",
            info: "#455A64",
            success: "#388E3C",
            warning: "#FFA000",
            correct:"#EEEEEE",
            misplaced:"#757575",
            wrong:"#212121",
            unknown: "#424242"
          }
        },
        pastelLight: {
          colors: {
            primary: "#CB9CF2",   // Pastel violet
            secondary: "#C7F9CC", // Soft mint
            error: "#F28FAD",     // Soft red
            info: "#9ED2F6",      // Pastel blue
            success: "#A7E9AF",   // Pastel green
            warning: "#FBE4A0",   // Pastel yellow
            correct: "#A7E9AF",   // Pastel green
            misplaced: "#FBE4A0", // Pastel yellow
            wrong: "#F28FAD",     // Soft red
            unknown: "#E0E0E0"    // Off-white
          }
        },
        pastelDark: {
          dark: true,
          colors: {
            primary: "#997DB5",  // Muted violet
            secondary: "#6E9985",// Muted mint
            error: "#9C6877",    // Muted red
            info: "#5F8A9F",     // Muted blue
            success: "#608562",  // Muted green
            warning: "#978B61",  // Muted yellow
            correct: "#608562",  // Muted green
            misplaced: "#978B61",// Muted yellow
            wrong: "#9C6877",    // Muted red
            unknown: "#787878"   // Dark grey
          },
        },
        retroLight: {
          colors: {
            primary: "#FFDB58",  // Mustard yellow
            secondary: "#CC5500",// Rust orange
            error: "#CB4154",    // Brick red
            info: "#008080",     // Teal
            success: "#808000",  // Olive green
            warning: "#FFBF00",  // Amber
            correct: "#808000",  // Olive green
            misplaced: "#FFBF00",// Amber
            wrong: "#CB4154",    // Brick red
            unknown: "#f0f0f0"   // Very light grey
          },
        },
        retroDark: {
          dark: true,
          colors: {
            primary: "#C7A317",  // Dark mustard
            secondary: "#7B3F00",// Dark rust
            error: "#A63D40",    // Dark brick red
            info: "#00585E",     // Dark teal
            success: "#656D3D",  // Dark olive
            warning: "#CC9400",  // Dark amber
            correct: "#656D3D",  // Dark olive
            misplaced: "#CC9400",// Dark amber
            wrong: "#A63D40",    // Dark brick red
            unknown: "#424242"   // Dark grey
          },
        },
        natureLight: {
          colors: {
            primary: "#228B22",  // Forest green
            secondary: "#8B4513",// Saddle brown
            error: "#D53032",    // Berry red
            info: "#87CEEB",     // Sky blue
            success: "#9ACD32",  // Yellow green
            warning: "#FFDA03",  // Sunflower yellow
            correct: "#9ACD32",  // Yellow green
            misplaced: "#FFDA03",// Sunflower yellow
            wrong: "#D53032",    // Berry red
            unknown: "#F5F5F5"   // White smoke
          },
        },
        natureDark: {
          dark: true,
          colors: {
            primary: "#016524",  // Dark green
            secondary: "#563C0D",// Dark brown
            error: "#9B2C30",    // Dark red
            info: "#3B678F",     // Dark blue
            success: "#6B8E23",  // Olive drab
            warning: "#C7A600",  // Mustard
            correct: "#6B8E23",  // Olive drab
            misplaced: "#C7A600",// Mustard
            wrong: "#9B2C30",    // Dark red
            unknown: "#636363"   // Dim gray
          },
        }
      }
    }
  });
  app.vueApp.use(vuetify);
});
