import Axios from 'axios'

export default defineNuxtPlugin(() => {
  if (process.client) {
    if (
      window.location.hostname === "localhost" ||
      window.location.hostname === "127.0.0.1"
    ) {
      Axios.defaults.baseURL = "https://localhost:7108/";
    } else {
      Axios.defaults.baseURL = "TODO";
    }
  }
})
