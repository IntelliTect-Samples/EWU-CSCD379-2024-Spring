import { createApp } from 'vue'
import App from './app.vue'
import vuetify from './plugins/vuetify' // Import Vuetify instance

const app = createApp(App)

// Use the Vuetify instance
app.use(vuetify)

app.mount('#app')
