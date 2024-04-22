<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-text> Settings </v-card-text>
      </v-sheet>
      <v-card-text>
        Dark/Light:   
        <v-btn 
          icon="mdi-theme-light-dark" @click="toggleTheme" />
      </v-card-text>
      
      <v-sheet class="ml-6">
        <v-select
          color="secondary"
          v-model="chosenTheme"
          label="Choose a Theme"
          :items="['Standard', 'Mystic Meadow']"
        ></v-select>
        <v-btn color="secondary" @click="changeTheme" class="mb-6" type="submit">Activate</v-btn>
      </v-sheet>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const theme = useTheme();
const modelValue = defineModel<boolean>({ default: false });
const chosenTheme = ref('Standard');


function changeTheme() {
  //is light change meadow
  if(theme.global.name.value == "light" || theme.global.name.value == "mysticMeadowLight" && chosenTheme == "Mystic Meadow"){
    theme.global.name.value = "mysticMeadowLight";
  }
  //is dark change meadow
  if(theme.global.name.value == "dark" || theme.global.name.value == "mysticMeadowDark" && chosenTheme == "Mystic Meadow"){
    theme.global.name.value = "mysticMeadowDark";
  }
  //is light change standard
  if(theme.global.name.value === "light" || theme.global.name.value === "mysticMeadowLight" && chosenTheme === "Standard"){
    theme.global.name.value = "light";
  }
  //is dark change standard
  if(theme.global.name.value === "dark" || theme.global.name.value === "mysticMeadowDark" && chosenTheme === "Standard"){
    theme.global.name.value = "dark";
  }
}



function toggleTheme(){
  if(theme.global.name.value === "light"){
    theme.global.name.value = "dark";
  }
  else {
    theme.global.name.value = "light";
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);  
}
</script>
