<template>
    <v-dialog v-model="modelValue" max-width="500" persistent>
        <v-card>
            <v-sheet color="primary">
                <v-card-title> Game Player Name </v-card-title>
            </v-sheet>
            <v-card-text>
                <div class="mt-6 mb-8"> 
                    Enter your name to track your progress:
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
                <v-btn color="secondary"
                       variant="flat"
                       text="Close"
                       @click="modelValue = false" />
                <v-btn color="primary" @click="setName">Set Name</v-btn> <!-- Moved Set Name button -->
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script setup lang="ts">
    import { ref, defineModel } from 'vue';

    const modelValue = defineModel<boolean>({ default: false });
    const playerName = ref<string>(''); 

    const setName = () => {
        console.log("Player name set:", playerName.value);
    };
</script>