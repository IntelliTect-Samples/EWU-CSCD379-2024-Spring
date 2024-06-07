import Axios from 'axios'

export default defineNuxtPlugin(() => {
  if (process.client) {
    if (
      window.location.hostname === "localhost" ||
      window.location.hostname === "127.0.0.1"
    ) {
      Axios.defaults.baseURL = "http://localhost:5297/";
    } else {
      Axios.defaults.baseURL = "https://wordleapiewu.azurewebsites.net/";
    }
  }
})
