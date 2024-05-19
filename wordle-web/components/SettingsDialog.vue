<template>
    <v-dialog v-model="modelValue" max-width="500">
        <v-card>
            <v-card-title>Settings</v-card-title>
            <v-card-subtitle>Change the theme of the app or toggle light or dark mode</v-card-subtitle>

            <v-btn @click="toggleTheme" color="primary">Toggle Theme</v-btn>
            <v-menu color="primary">
                <template v-slot:activator="{ props }">
                    <v-btn color="primary" class="justify-center" v-bind="props">
                        select a theme
                    </v-btn>
                </template>
                <v-list>
                    <v-list-item v-for="theme in themes" @click="changeTheme(theme.theme)">
                        <v-list-item-title>{{ theme.name }}</v-list-item-title>
                    </v-list-item>
                </v-list>
            </v-menu>
        </v-card>
    </v-dialog>
</template>
<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const modelValue = defineModel<boolean>({ default: false });
const theme = useTheme();
var dark = ref(true);

const themes = [
    { name: "default", theme: "dark" },
    { name: "sans", theme: "sansDark" },
    { name: "watermelon", theme: "watermelonDark" },
];
function setDark() {
    if (theme.global.name.value.includes("Dark") || theme.global.name.value === "dark") {
        dark.value = true;
    } else {
        dark.value = false;
    }
}
function changeTheme(themeName: string) {
    if (dark.value === false) {
        var themeToSet = themeName;
        if (themeToSet === "dark") {
            themeToSet = "light";
        } else {
            themeToSet = themeToSet.replace("Dark", "Light");
            console.log(themeToSet);
        }
        dark.value = false;
        theme.global.name.value = themeToSet;

    } else {
        theme.global.name.value = themeName;
        dark.value = true;
    }
    nuxtStorage.localStorage.setData('theme', theme.global.name.value);

}
function setTheme(themeName: string) {
    theme.global.name.value = themeName;
    nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}
function toggleTheme() {
    if (theme.global.name.value === "dark") {
        setTheme("light");
        dark.value = false;
    } else if (theme.global.name.value === "sansLight") {
        setTheme("sansDark");
        dark.value = true;
    } else if (theme.global.name.value === "sansDark") {
        setTheme("sansLight");
        dark.value = false;
    } else if (theme.global.name.value === "watermelonLight") {
        setTheme("watermelonDark");
        dark.value = true;
    } else if (theme.global.name.value === "watermelonDark") {
        setTheme("watermelonLight");
        dark.value = false;
    } else {
        setTheme("dark");
        dark.value = true;
    }
}
//watch for dialog to open or close and call setDark
watch(() => modelValue, (value) => {
    if (value) {
        setDark();
    }
});
</script>