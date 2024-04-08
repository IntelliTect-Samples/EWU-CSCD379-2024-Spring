<template>
  <v-card class="mx-auto my-8" elevation="16" max-width="430">
    <v-card-item>
      <v-card-title> "Marco!" </v-card-title>
      <v-card-subtitle> What will you reply? </v-card-subtitle>
    </v-card-item>
    <v-card-text>
      <v-text-field
        v-model="myGuess"
        label="You say:"
        outlined
        clearable
      >
      </v-text-field>
    </v-card-text>
    <v-card-text>
      <p class="my-2 font-weight-bold">Hint: {{ hintText }}</p>
    </v-card-text>

    <v-card-text>
      <div>Result: {{ guessText }}</div>
    </v-card-text>

    <v-card-actions>
      <v-btn color="pink" variant="elevated" elevation="8" @click="submit()">
        Submit
      </v-btn>
      <v-btn color="teal" variant="elevated" elevation="8" @click="hint()">
        Hint
      </v-btn>

      <v-btn
        color="black"
        variant="elevated"
        elevation="8"
        @click="router.push('/')"
      >
        Return
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
const router = useRouter();

const hintText = ref("");
const myGuess = ref("");
const guessText = ref("");

function submit() {
  if (myGuess.value.toUpperCase() === "POLO") {
    guessText.value = "Correct!";
  } else if (myGuess.value.toUpperCase() === "MONTOYA") {
    guessText.value = "Mark, it's not C# class anymore!";
  } else {
    guessText.value = "Incorrect!";
  }
}

function hint() {
  hintText.value = "Also an explorer";
}
</script>
