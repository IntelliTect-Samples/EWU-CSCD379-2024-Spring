<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-btn icon @click="router.push('/')">
            <v-icon color="#FFFFFF">mdi-wizard-hat</v-icon> <!-- Wizard hat icon -->
          </v-btn>
          <v-btn @click="router.push('/')">
            Welcome to LexiQuest
          </v-btn>
        </template>

        <v-spacer></v-spacer> <!-- This pushes the rest of the items to the right -->

        <v-btn icon="mdi-cog" @click="toggleSettingsDrawer" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <v-btn icon="mdi-menu" @click="toggleDrawer" />

        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>

      <!-- Navigation Drawer for the About section -->
      <v-navigation-drawer v-model="drawer" right absolute temporary>
        <v-list>
          <v-list-item @click="router.push('/about')" class="text-center">About</v-list-item>
        </v-list>
      </v-navigation-drawer>

      <!-- Navigation Drawer for settings and theme changes -->
      <v-navigation-drawer v-model="settingsDrawer" right absolute temporary>
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
                src="https://media.giphy.com/media/l0ExsgrTuACbtPaqQ/giphy.gif"
                alt="Animated spell casting"
                max-height="200"
              />
            </v-col>
          </v-row>
          <NuxtPage />
        </v-container>
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { ref } from 'vue';
import { useTheme } from "vuetify/lib/framework.mjs";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const drawer = ref(false);
const settingsDrawer = ref(false);

function toggleDrawer() {
  drawer.value = !drawer.value;
}

function toggleSettingsDrawer() {
  settingsDrawer.value = !settingsDrawer.value;
}

function setTheme(themeName) {
  theme.global.name.value = themeName;
}
</script>
