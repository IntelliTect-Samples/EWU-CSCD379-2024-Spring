<template>
    <v-dialog v-modle="modleValue" max-width="500">
        <v-card>
            <v-sheet color="primary">
                <v-card-text>
                    How to play worldle
                </v-card-text>
            </v-sheet>
            <v-card-text>
                insert insturctions here
            </v-card-text>
            <v-divider />
        </v-card>
        <v-card-actions>
            <v-spacer></v-spacer>
        </v-card-actions>
        <v-btn text="Close" @click="modelValue = false" color="primary" varient="tonal"></v-btn>

    </v-dialog>
</template>
<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs';
const theme = useTheme()
const router = useRouter()
const showHelpDialog = ref(false)

function toggleTheme() {
    if (theme.global.name.value === "light") {
        theme.global.name.value = "dark"
    } else {
        theme.global.name.value = "light"
    }

}

</script>
