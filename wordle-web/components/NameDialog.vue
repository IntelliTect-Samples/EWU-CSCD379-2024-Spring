<template>
    <v-dialog v-model="dialogVisible" persistent>
        <v-card>
            <v-card-title>Enter your name:</v-card-title>
            <v-card-text>
                <v-text-field label="Username" v-model="username" outlined></v-text-field>
            </v-card-text>
            <v-card-actions>
                <v-btn color="primary" @click="saveUsername">Save</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import { ref, onMounted } from 'vue';
    import nuxtStorage from 'nuxt-storage';

    export default {
        setup() {
            const username = ref('');
            const dialogVisible = ref(false);

            onMounted(() => {
                const storedName = nuxtStorage.localStorage.getData('username');
                if (!storedName) {
                    dialogVisible.value = true;
                }
            });

            function saveUsername() {
                nuxtStorage.localStorage.setData('username', username.value);
                dialogVisible.value = false;
            }

            return { username, dialogVisible, saveUsername };
        }
    }
</script>
