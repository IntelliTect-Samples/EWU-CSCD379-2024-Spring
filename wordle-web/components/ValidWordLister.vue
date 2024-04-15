<template>
    <v-card class="mx-auto" max-width="400">
        <v-card-title>Valid Words</v-card-title>
        <v-card-text>
            <v-list>
                <v-list-item
                    v-for="(word, k) of validWords"
                    :key="k"
                >
                    <v-list-item-content>
                        <v-list-item-title>{{ word }}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-card-text>
</template>