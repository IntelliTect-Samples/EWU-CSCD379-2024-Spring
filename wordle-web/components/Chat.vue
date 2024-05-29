<template>
  <v-card height="92%" variant="tonal" :color="cardColor">
    <v-card-text>
      <p v-for="(message, i) of signalRService.messages.value" :key="i">
        <v-avatar
          icon="mdi-account"
          :color="cardColor"
          size="small"
          class="mr-2"
        />
        <ChatMessage :message="message" />
        <v-divider class="my-2" />
      </p>
    </v-card-text>
  </v-card>
  <v-text-field
    class="mt-2"
    label="Message"
    @keyup.stop
    @keyup.enter="sendMessage"
    v-model="message"
    @click:append-inner="sendMessage"
    append-inner-icon="mdi-send"
  />
</template>

<script setup lang="ts">
import SignalRService from "~/scripts/signalRService";
import { useTheme } from "vuetify";

const message = ref<string>("");
const signalRService = new SignalRService();

const theme = useTheme();
const cardColor = computed(() => {
  return theme.global.name.value == "dark" ? "secondary" : "primary";
});

function parseWord(message: string) {
  return message.split(" ")[1];
}

function sendMessage() {
  signalRService.sendMessage(message.value);
  message.value = "";
}
</script>
