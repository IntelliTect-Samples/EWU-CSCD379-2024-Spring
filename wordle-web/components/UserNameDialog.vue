<template>
  <v-dialog v-model="modelValue" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary"></v-sheet>
      <v-tabs v-model="currentPage" align-tabs="center">
        <v-tab>Wordle Name</v-tab>
        <v-tab>Log In</v-tab>
      </v-tabs>
      <div v-if="currentPage === 0">
        <v-card-title>Enter your Wordle Name: </v-card-title>
        <v-card-subtitle>
          Your current username is: {{ userName }}</v-card-subtitle
        >
        <v-text-field
          @keyup.stop
          v-model="userName"
          label="User Name"
          required
        ></v-text-field>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" variant="tonal" @click="modelValue = false"
            >Cancel</v-btn
          >
          <v-btn color="primary" variant="flat" @click="saveUserName"
            >Save</v-btn
          >
        </v-card-actions>
      </div>
      <div v-else>
        <v-card>
          <v-alert
            v-if="errorMessage"
            type="error"
            title-date-format="Function"
          >
            {{ errorMessage }}
          </v-alert>
          <v-card-text v-if="signedIn">You Are Signed In</v-card-text>
          <v-card-text v-else> You Are Not Signed In</v-card-text>
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
          <v-card-actions>
            <v-spacer />
            <v-btn color="primary" variant="tonal" @click="modelValue = false">
              Cancel
            </v-btn>

            <v-btn color="primary" variant="flat" @click="signOut">
              Sign Out
            </v-btn>

            <v-btn color="primary" variant="flat" @click="signIn">
              Sign In
            </v-btn>
          </v-card-actions>
        </v-card>
      </div>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import nuxtStorage from "nuxt-storage";
import Axios from "axios";
import TokenService from "@/scripts/tokenService";

const modelValue = defineModel<boolean>({ default: false });
const userName: Ref<string> = inject("userName")! as Ref<string>;
const currentPage = ref(0);
const router = useRouter();
const tokenService = new TokenService();
const signedIn = computed(() => tokenService.isLoggedIn());
const showPassword = ref(false);
const password = ref("");
const errorMessage = ref("");
const userNameGlobal: Ref<string> = inject("userName")! as Ref<string>;

const saveUserName = () => {
  modelValue.value = false;
  nuxtStorage.localStorage.setData("userName", userName.value);
};

function signIn() {
  errorMessage.value = "";
  Axios.post("/Token/GetToken", {
    username: userName.value,
    password: password.value,
  })
    .then((response) => {
      tokenService.setToken(response.data.token);
      modelValue.value = false;
    })
    .catch((error) => {
      errorMessage.value = error.response.data;
    });
  modelValue.value = false;
  userNameGlobal.value = userName.value;
  router.push("/");
}
function signOut() {
  localStorage.removeItem("token");
  localStorage.removeItem("user");
  router.push("/");
}
</script>
