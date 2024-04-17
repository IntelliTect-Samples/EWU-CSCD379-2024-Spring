<template>
    <v-app>
      <v-dialog v-model="settingsDialog" persistent max-width="500px">
        <v-card>
          <v-card-title>
            <v-icon left>mdi-cog</v-icon>
            Settings
          </v-card-title>
          <v-card-text>
            <v-switch v-model="darkTheme" label="Dark Mode"></v-switch>
            <v-select
              v-model="themeColor"
              :items="themeColors"
              label="Theme Color"
              item-text="name"
              item-value="color"
            ></v-select>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="primary" text @click="toggleDialog">Close</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-app>
  </template>
  
  <script>
  export default {
    data() {
      return {
        settingsDialog: false,
        darkTheme: false,
        themeColor: '',
        themeColors: [
          { name: 'Default', color: 'secondary' },
          { name: 'Sunset Glow', color: 'orange' },
          { name: 'Ocean Blue', color: 'blue' },
        ],
      };
    },
    methods: {
      toggleDialog() {
        this.settingsDialog = !this.settingsDialog;
      }
    },
    watch: {
      darkTheme(value) {
        this.$vuetify.theme.dark = value;
      },
      themeColor(value) {
        this.$vuetify.theme.colors.primary = value;
      },
    },
  };
  </script>