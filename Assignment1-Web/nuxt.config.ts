// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  build: {
    transpile: ['vuetify'],
  },
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

