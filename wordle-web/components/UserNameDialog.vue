<!-- gets the username-->
<template>
    <v-dialog v-model="modelValue" max-width="500" persistent>
        <v-card>
            <v-sheet color="primary"></v-sheet>
            <v-card-title>Enter your user name: </v-card-title>
            <v-card-subtitle> Your current username is: {{ userName }}</v-card-subtitle>
            <v-text-field @keyup.stop v-model="userName" label="User Name" required></v-text-field>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="primary" variant ="flat" @click="modelValue = false">Cancel</v-btn>
                <v-btn color="primary" variant = "flat" @click=saveUserName>Save</v-btn>
            </v-card-actions>
        </v-card>

    </v-dialog>
</template>

<script setup lang="ts">
import nuxtStorage from "nuxt-storage";
const modelValue = defineModel<boolean>({ default: false });
    const userName: Ref<string>= inject("userName")! as Ref<string>;

const saveUserName = () => {
    modelValue.value = false;
    //console.log("userName in dialog " + userName.value);
    nuxtStorage.localStorage.setData("userName", userName.value);
}
//console.log("userName in dialog " + userName.value);
</script>