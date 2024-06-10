<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-btn icon @click="router.push('/')">
            <v-icon color="deep-purple">mdi-wizard-hat</v-icon> <!-- Wizard hat icon -->
          </v-btn>
          <v-btn @click="router.push('/')">
            Welcome to LexiQuest
          </v-btn>
        </template>

        <v-btn
          @click="showLoginDialog = true"
          class="mb-5"
          flat
          color="primary"
        >
          <v-icon>mdi-lock</v-icon>
          Login
        </v-btn>

        <v-spacer></v-spacer> <!-- This pushes the rest of the items to the right -->

        <v-btn icon="mdi-cog" @click="toggleSettingsDrawer" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <v-btn icon="mdi-menu" @click="toggleDrawer" />

        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>

      <!-- Navigation Drawer for the About section -->
      <v-navigation-drawer v-model="drawer" location="right">
        <v-list>
          <v-list-item @click="router.push('/about')" class="text-center">About</v-list-item>
        </v-list>
      </v-navigation-drawer>

      <!-- Navigation Drawer for settings and theme changes -->
      <v-navigation-drawer v-model="settingsDrawer" location="right">
        <v-list>
          <v-list-item class="text-center">Choose Your Theme!</v-list-item>
          <v-list-item @click="setTheme('White')" class="text-center">White Wizard</v-list-item>
          <v-list-item @click="setTheme('Dark')" class="text-center">Dark Mage</v-list-item>
          <v-list-item @click="setTheme('Forest')" class="text-center">Enchanted Forest</v-list-item>
          <v-list-item @click="setTheme('Merlin')" class="text-center">Merlin's Study</v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-main>
        <v-container class="text-center">
          <v-row>
            <v-col cols="12">
              <v-img
                src="/images/lexiquest_background.jpg"
                alt="Animated spell casting"
                max-height="200"
              />
            </v-col>
          </v-row>
          <NuxtPage />
        </v-container>
      </v-main>

      <!-- Login Dialog -->
      <v-dialog v-model="showLoginDialog" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="headline">Login</span>
          </v-card-title>
          <v-card-text>
            <v-form ref="loginForm" v-model="valid" lazy-validation>
              <v-text-field
                v-model="username"
                :rules="usernameRules"
                label="Username"
                required
              ></v-text-field>
              <v-text-field
                v-model="password"
                :rules="passwordRules"
                label="Password"
                type="password"
                required
              ></v-text-field>
            </v-form>
            <v-alert v-if="loginError" type="error" dismissible>{{ loginError }}</v-alert>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" text @click="showLoginDialog = false">Cancel</v-btn>
            <v-btn color="blue darken-1" text @click="login">Login</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { ref } from 'vue';
import { useTheme } from 'vuetify/lib/framework.mjs';

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const drawer = ref(false);
const settingsDrawer = ref(false);
const showLoginDialog = ref(false);

const username = ref('');
const password = ref('');
const valid = ref(false);
const loginError = ref('');

const usernameRules = [
  v => !!v || 'Username is required',
];

const passwordRules = [
  v => !!v || 'Password is required',
];

async function login() {
  const isValid = await validateForm();
  if (!isValid) return;

  try {
    // Simulate API call for login
    const response = await ApiLogin(username.value, password.value);
    if (response.success) {
      console.log('Login successful');
      showLoginDialog.value = false;
      loginError.value = '';
      // Handle successful login (e.g., store token, redirect, etc.)
    } else {
      loginError.value = 'Invalid username or password';
    }
  } catch (error) {
    loginError.value = 'An error occurred during login';
    console.error('Login error:', error);
  }
}

async function validateForm() {
  const form = ref(null);
  return form.value.validate();
}

function toggleDrawer() {
  drawer.value = !drawer.value;
}

function toggleSettingsDrawer() {
  settingsDrawer.value = !settingsDrawer.value;
}

function setTheme(themeName) {
  theme.global.name.value = themeName;
}


async function ApiLogin(username, password) {
  return new Promise((resolve) => {
    setTimeout(() => {
      if (username === 'admin' && password === 'admin') {
        resolve({ success: true });
      } else {
        resolve({ success: false });
      }
    }, 1000);
  });
}
</script>
