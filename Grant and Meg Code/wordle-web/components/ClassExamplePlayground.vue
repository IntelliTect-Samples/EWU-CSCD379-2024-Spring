<template>
    <v-btn @click="okayClicked">Okay</v-btn>
    <v-btn @click="emits('nope')">Nope</v-btn>
    <v-btn @click="emits('clicked', clickedText)">Click</v-btn>
    <h1 class="pa-5">
        <!-- Named Slot -->
        <slot name="text" />
    </h1>

    <!-- Default Slot-->
    <v-card class="ma-5" color="primary">
        <slot />
    </v-card>
</template>
<script setup lang="ts">
    const emits = defineEmits<{
        (e: "okay"): void;
        (e: "nope"): void;
        (e: "clicked", clickedText: string): string;
    }>();

    const clickedText = "hello world";

    function okayClicked() {
        emits("okay");
    }
</script>