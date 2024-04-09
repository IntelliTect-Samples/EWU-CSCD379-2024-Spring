// import this after install `@mdi/font` package
import '@mdi/font/css/materialdesignicons.css';

import 'vuetify/styles';
import { createVuetify } from 'vuetify';
import colors from 'vuetify/util/colors';



export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
   theme: {
    themes: {
      light: {
        dark: false,
        colors: {
          
          
        }
      },
    },
  },
  });
  app.vueApp.use(vuetify);
});
