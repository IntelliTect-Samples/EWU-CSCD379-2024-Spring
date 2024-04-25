import { defineVitestConfig } from '@nuxt/test-utils/config'

export default defineVitestConfig({
  test: {
    globals: true,
    setupFiles: ['./tests/vitest-setup.js'], // Adjust the path as necessary
  },
  // any custom Vitest config you require
})
