// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css';

import 'vuetify/styles';
import { createVuetify } from 'vuetify';

export default defineNuxtPlugin(app => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: 'regularDark',
      themes: {
        regularLight: {
          dark: false,
          colors: {
            primary: '#FFD54F',
            secondary: '#9575CD',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#BDBDBD',
            unknown: '#d6d6d6',
          },
        },
        regularDark: {
          dark: true,
          colors: {
            primary: '#9575CD',
            secondary: '#FFD54F',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#616161',
            unknown: '#424242',
          },
        },
        jungleLight: {
          dark: false,
          colors: {
            primary: '#B2FF59',
            secondary: '#388E3C',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#BDBDBD',
            unknown: '#d6d6d6',
          },
        },
        jungleDark: {
          dark: true,
          colors: {
            primary: '#388E3C',
            secondary: '#B2FF59',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#616161',
            unknown: '#424242',
          },
        },
        flamingoLight: {
          dark: false,
          colors: {
            primary: '#F48FB1',
            secondary: '#EC407A',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#BDBDBD',
            unknown: '#d6d6d6',
          },
        },
        flamingoDark: {
          dark: true,
          colors: {
            primary: '#EC407A',
            secondary: '#F48FB1',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#616161',
            unknown: '#424242',
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
