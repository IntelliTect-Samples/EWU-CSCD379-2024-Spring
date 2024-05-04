<template>
    <v-dialog v-model="modelValue" max-width="500" persistent>
        <v-card>
            <v-sheet color="primary">
                <v-card-title> Game Player Name </v-card-title>
            </v-sheet>
            <v-card-text>
                <div class="mt-6 mb-8"> 
                    Enter your name to start the game and track your progress!
                </div>
                <v-text-field
                    v-model="playerName"
                    label="Your Name"
                    outlined
                    dense
                ></v-text-field>
            </v-card-text>

            <v-divider />
            <v-card-actions>
                <v-btn color="primary"
                       variant="flat"
                       text="Don't Set Name"
                       @click="modelValue = false" />
                <v-btn color="primary"
                       variant="flat"
                       text="Set Name"
                       @click="modelValue = false"</v-btn> 
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script setup lang="ts">
    import { ref, defineModel, watch } from 'vue';
    import nuxtStorage from "nuxt-storage";


    const modelValue = defineModel<boolean>({ default: false });
    const playerName = ref<string>(''); 

    const setName = () => {
    console.log("Player name set:", playerName.value);
    localStorage.setItem('playerName', playerName.value); 
    modelValue = false; 
    emit('nameSet', playerName.value); 
};

onMounted(() => {
    const savedName = localStorage.getItem('playerName') || 'guest';
    playerName.value = savedName;
});
</script>