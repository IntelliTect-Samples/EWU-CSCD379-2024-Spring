// https://nuxt.com/docs/api/configuration/nuxt-config
import vuetify, { transformAssetUrls } from 'vite-plugin-vuetify'
import { Axios } from 'axios'
export default defineNuxtConfig({
  build: {
    transpile: ['vuetify'],
  },
  plugins: [
    '@/plugins/axios.ts'
  ],
  devtools: { enabled: true },
  modules: [
    '@nuxt/test-utils/module',
    (_options, nuxt) => {
      nuxt.hooks.hook('vite:extendConfig', (config) => {
        // @ts-expect-error
        config.plugins.push(vuetify({ autoImport: true }))
      })
    },
  ],
  vite: {
    vue: {
      template: {
        transformAssetUrls,
      },
    },
  },
})
