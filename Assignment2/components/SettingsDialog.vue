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
              <v-btn @click="menuItemClicked('light')" block color="secondary"
                >Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('dark')" block color="secondary"
                >Dark Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('pastelLight')" block color="secondary"
                >Pastel Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('pastelDark')" block color="secondary"
                >Pastel Dark Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('retroLight')" block color="secondary"
                >Retro Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('retroDark')" block color="secondary"
                >Retro Dark Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('natureLight')" block color="secondary"
                >Nature Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('natureDark')" block color="secondary"
                >Nature Dark Mode</v-btn
              >
            </v-col>
          </v-row>

          <v-divider />
      <v-card-actions>
        <v-spacer></v-spacer>

        <v-btn
          color="secondary"
          variant="tonal"
          text="Close"
          @click="modelValue = false"
        />
      </v-card-actions>
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

function menuItemClicked(item: string) {
  theme.global.name.value = item;
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

// function menuItemClicked(item: number){
//   if(item == 1){
//     theme.global.name.value = "light";
//   }
//   else if(item == 2){
//     theme.global.name.value = "dark";
//   }
//   else if(item == 3){
//     theme.global.name.value = "lightrainbow";
//   }
//   else if(item == 4){
//     theme.global.name.value = "lightnoir";
//   }
//   else if(item == 5){
//     theme.global.name.value = "darkrainbow";
//   }
//   else if(item == 6){
//     theme.global.name.value = "darknoir";
//   }
//   nuxtStorage.localStorage.setData("theme", theme.global.name.value);
// }
</script>
