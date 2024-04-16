<template>
    <v-dialog v-modle=showHelpDialog>
        <v-card title="Dialog">
            <v-card-text>insert help here</v-card-text>
        </v-card>
        <v-card-actions>
            <v-spacer></v-spacer>
        </v-card-actions>

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
