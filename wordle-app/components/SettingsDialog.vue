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
              <v-btn @click="menuItemClicked('light')" block color="#673AB7"
                >Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('dark')" block color="#673AB7"
                >Dark Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('pastelLight')" block color="#CB9CF2"
                >Pastel Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('pastelDark')" block color="#997DB5"
                >Pastel Dark Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('retroLight')" block color="#FFDB58"
                >Retro Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('retroDark')" block color="#C7A317"
                >Retro Dark Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('natureLight')" block color="#228B22"
                >Nature Light Mode</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6">
              <v-btn @click="menuItemClicked('natureDark')" block color="#016524"
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
</script>
