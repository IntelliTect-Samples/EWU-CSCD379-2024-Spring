// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css';

import 'vuetify/styles';
import { createVuetify } from 'vuetify';

export default defineNuxtPlugin(app => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: 'dark',
      themes: {
        regularLight: {
          colors: {
            unknown: "#d6d6d6"
            primary: '#9575CD',
            secondary: '#FFD54F',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#BDBDBD',
          },
        },
        regularDark: {
          colors: {
            primary: '#FFD54F',
            secondary: '#9575CD',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#616161',
            unknown: "#424242"
          },
        },
        jungleLight: {
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
          },
        },
        jungleDark: {
          colors: {
            primary: '#B2FF59',
            secondary: '#388E3C',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#616161',
          },
        },
        flamingoLight: {
          colors: {
            primary: '#F48FB1',
            secondary: '#EC407A',
            error: '#FF5252',
            info: '#2196F3',
            success: '#4CAF50',
            warning: '#FFC107',
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#616161',
          },
        },
        flamingoDark: {
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
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
