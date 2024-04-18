<template>
  <v-dialog v-model="modelValue">
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Settings</v-card-title>
      </v-sheet>
      <v-card-text>
        Welcome to settings! Let me know if you wanna set some stuff.
      </v-card-text>
      <v-btn @click="toggleTheme" icon="mdi-theme-light-dark" />
      <v-sheet class="mx-auto" width="300">
        <v-form @submit.prevent>
          <v-select
            label="Select theme"
            :items="['Regular', 'Jungle', 'Flamingo']"></v-select>
          <v-btn class="mt-2" type="submit" block>Submit</v-btn>
        </v-form>
      </v-sheet>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify';
import nuxtStorage from 'nuxt-storage';

const modelValue = defineModel<boolean>({ default: false });
const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? 'dark';
});

function toggleTheme() {
  if (theme.global.name.value === 'light') {
    theme.global.name.value = 'dark';
  } else {
    theme.global.name.value = 'light';
  }

  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}
</script>
