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
          :items="['Standard', 'Mystic Meadow', 'Enchanted Eclipse']"
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
  const darkMode: boolean = isDark();
  if(chosenTheme.value === "Mystic Meadow"){
    if(darkMode){
      theme.global.name.value = "mysticMeadowDark";
    }
    else {
      theme.global.name.value = "mysticMeadowLight";
    }
  }
  if(chosenTheme.value === "Enchanted Eclipse"){
    if(darkMode){
      theme.global.name.value = "enchantedEclipseDark";
    }
    else {
      theme.global.name.value = "enchantedEclipseLight";
    }
  }
  if(chosenTheme.value === "Standard"){
    if(darkMode){
      theme.global.name.value = "dark";
    }
    else {
      theme.global.name.value = "light"
    }
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

function isDark(): boolean {
  const last4Letters = theme.global.name.value.substring(theme.global.name.value.length - 4).toLowerCase();
  return last4Letters === "dark";
}



function toggleTheme(){
  let changed: boolean = false;
  if(theme.global.name.value === "light"){
    theme.global.name.value = "dark";
    changed = true;
  }
  else if(theme.global.name.value === "dark") {
    theme.global.name.value = "light";
    changed = true;
  }
  
  if(!changed){
    const darkMode: boolean = isDark();
    let themeName: string = theme.global.name.value;
    if(darkMode){
      themeName = themeName.substring(0, themeName.length - 4);
      theme.global.name.value = themeName + "Light";
    }
    else {
      themeName = themeName.substring(0, themeName.length - 5);
      theme.global.name.value = themeName + "Dark";
    }
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);  
}
</script>
