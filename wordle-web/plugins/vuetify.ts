// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css';

import 'vuetify/styles';
import { createVuetify } from 'vuetify';

export default defineNuxtPlugin(app => {
  const vuetify = createVuetify({
    theme: {
      defaultTheme: 'dark',
      themes: {
        light: {
          colors: {
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
        dark: {
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
          },
        },
      },
    },
  });
  app.vueApp.use(vuetify);
});
