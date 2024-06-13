<template>
  <v-dialog v-model="localModelValue" width="500">
    <v-card>
      <v-alert v-if="errorMessage" type="error">
        {{ errorMessage }}
      </v-alert>
      <v-card-text>
        <v-text-field v-model="userName" @keyup.stop label="Username" />
        <v-text-field v-if="isSignUp" v-model="email" @keyup.stop label="Email" />
        <v-text-field
          v-model="password"
          @keyup.stop
          label="Password"
          :type="showPassword ? 'text' : 'password'"
          :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
          @click:append-inner="showPassword = !showPassword"
        />
        <v-text-field v-if="isSignUp" v-model="secretPhrase" @keyup.stop label="Secret Phrase" />
        <v-date-picker v-if="isSignUp" v-model="birthday" label="Birthday" />
      </v-card-text>
      <v-card-actions>
        <v-row justify="center">
          <v-col cols="auto">
            <v-btn color="primary" variant="tonal" @click="closeDialog">
              Cancel
            </v-btn>
          </v-col>
          <v-col cols="auto">
            <v-btn color="primary" variant="flat" @click="handleSubmit">
              {{ isSignUp ? 'Sign Up' : 'Sign In' }}
            </v-btn>
          </v-col>
          <v-col cols="auto">
            <v-btn @click="toggleSignUp">
              {{ isSignUp ? 'Sign In' : 'Sign Up' }}
            </v-btn>
          </v-col>
        </v-row>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import axios from 'axios';
import TokenService from '~/scripts/tokenService';

const props = defineProps<{ modelValue: boolean }>();
const emit = defineEmits(['update:modelValue']);

const localModelValue = ref(props.modelValue);
const showPassword = ref(false);
const userName = ref('');
const password = ref('');
const email = ref('');
const secretPhrase = ref('');
const birthday = ref(null);
const errorMessage = ref('');
const isSignUp = ref(false);

const tokenService = new TokenService();

watch(() => props.modelValue, (newVal) => {
  localModelValue.value = newVal;
});

watch(localModelValue, (newVal) => {
  emit('update:modelValue', newVal);
});

const handleSubmit = () => {
  if (isSignUp.value) {
    signUp();
  } else {
    signIn();
  }
};

const signIn = () => {
  errorMessage.value = '';
  axios
    .post('/api/Token/Authenticate', {
      username: userName.value,
      password: password.value,
    })
    .then((response) => {
      tokenService.setToken(response.data.token);
      closeDialog();
    })
    .catch((error) => {
      errorMessage.value = error.response?.data || 'Sign-in failed.';
    });
};

const signUp = () => {
  errorMessage.value = '';
  axios
    .post('/api/User/Register', {
      username: userName.value,
      password: password.value,
      email: email.value,
      secretPhrase: secretPhrase.value,
      birthday: birthday.value,
    })
    .then(() => {
      // Automatically sign in after successful registration
      signIn();
    })
    .catch((error) => {
      errorMessage.value = error.response?.data || 'Sign-up failed.';
    });
};

const toggleSignUp = () => {
  isSignUp.value = !isSignUp.value;
  errorMessage.value = '';
};

const closeDialog = () => {
  localModelValue.value = false;
  clearFields();
};

const clearFields = () => {
  userName.value = '';
  password.value = '';
  email.value = '';
  secretPhrase.value = '';
  birthday.value = null;
};
</script>