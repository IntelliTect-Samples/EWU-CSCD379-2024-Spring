<template>
  <v-dialog v-model="modelValue" width="400">
    <v-card>
      <v-alert v-if="errorMessage" type="error" title-date-format="Function">
        {{ errorMessage }}
      </v-alert>
      <div v-if="!tokenService.isLoggedIn()">
        <v-card-text>
          <v-text-field v-model="userName" @keyup.stop label="Username" />
          <v-text-field
            v-model="password"
            @keyup.stop
            label="Password"
            :type="showPassword ? 'text' : 'password'"
            :append-inner-icon="
              showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'
            "
            @click:append-inner="showPassword = !showPassword"
          />
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" variant="flat" @click="modelValue = false">
            Cancel
          </v-btn>
          <v-btn color="primary" variant="flat" @click="signIn">
            Sign In
          </v-btn>
        </v-card-actions>
      </div>
      <div v-else>
        <v-card-text>
          <v-alert type="success" title="You are already signed in!">
            You are already signed in as {{ tokenService.getUserName() }}.
          </v-alert>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn color="primary" variant="flat" @click="modelValue = false">
            Close
          </v-btn>
          <v-btn color="primary" variant="flat" @click="signOut">
            Sign Out
          </v-btn>
        </v-card-actions>

      </div>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import axios from "axios";
import TokenService from "../scripts/tokenService";

const tokenService = new TokenService();

const modelValue = defineModel<boolean>({ default: false });
const showPassword = ref(false);
const userName = ref("");
const password = ref("");
const errorMessage = ref("");

function signIn() {
  errorMessage.value = "";
  axios
    .post("/Token/GetToken", {
      userName: userName.value,
      password: password.value,
    })
    .then((response) => {
      tokenService.setToken(response.data.token);
      modelValue.value = false;
      emits("signInClicked");
    })
    .catch((error) => {
      errorMessage.value = error.response.data;
    });
}

function signOut() {
  tokenService.removeToken();
  modelValue.value = false;
  emits("signInClicked");
}

const emits = defineEmits<{
  (e: "signInClicked"): void;
}>();


</script>

<style></style>
