import Axios from "axios";

export default defineNuxtPlugin(() => {
  if (process.client) {
    if (
      window.location.hostname === "localhost" ||
      window.location.hostname === "127.0.0.1"
    ) {
      Axios.defaults.baseURL = "https://localhost:7266/";
    } else {
      Axios.defaults.baseURL = "https://aestheticwordle.azurewebsites.net/";
    }
  }
  Axios.defaults.headers.common["Content-Type"] = "application/json";
  Axios.defaults.headers.common["Accept"] = "application/json";
  Axios.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
});
