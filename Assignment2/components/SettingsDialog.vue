<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-text> Settings </v-card-text>
      </v-sheet>
      <v-card-text>
        You can change the color mode of the app by clicking on the buttons
        below.
      </v-card-text>
      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked(1)" block color="secondary">Light Mode</v-btn>
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked(2)" block color="secondary">Dark Mode</v-btn>
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked(3)" block color="secondary">Light Rainbow Mode</v-btn>
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked(4)" block color="secondary">Light Noir Mode</v-btn>
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked(5)" block color="secondary">Dark Rainbow Mode</v-btn>
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked(6)" block color="secondary">Dark Noir Mode</v-btn>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">

import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const modelValue = defineModel<boolean>({ default: false });
const theme = useTheme();

function menuItemClicked(item: number){
  if(item == 1){
    theme.global.name.value = "light";
  }
  else if(item == 2){
    theme.global.name.value = "dark";
  }
  else if(item == 3){
    theme.global.name.value = "lightrainbow";
  }
  else if(item == 4){
    theme.global.name.value = "lightnoir";
  }
  else if(item == 5){
    theme.global.name.value = "darkrainbow";
  }
  else if(item == 6){
    theme.global.name.value = "darknoir";
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
