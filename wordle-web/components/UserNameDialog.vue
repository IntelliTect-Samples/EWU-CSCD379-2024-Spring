<!-- gets the username-->
<template>
    <v-dialog v-model="modelValue" max-width="500">
        <v-card>
            <v-sheet color="primary"></v-sheet>
            <v-card-title>Enter your user name current user is {{ userName }}</v-card-title>
            <v-text-field v-model="userName" label="User Name" required></v-text-field>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary"  @click="modelValue = false">Cancel</v-btn>
                <v-btn color="primary"  @click= saveUserName >Save</v-btn>
            </v-card-actions>
        </v-card>

    </v-dialog>
</template>

<script setup lang="ts">
import nuxtStorage from "nuxt-storage";

const modelValue = defineModel<boolean>({ default: false });
const userName = inject("userName");
console.log(userName);
function saveUserName() {
    nuxtStorage.localStorage.setData('userName', userName);
    modelValue.value = false;
    console.log("UserNameDialog name " + userName);
}


</script>