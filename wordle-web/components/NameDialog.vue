<template>
  <v-dialog v-model="showDialog" persistent max-width="400px">
    <v-card class="elevation-12">
      <v-card-title class="text-h3">🏰 Herald, State Thy Name!</v-card-title>
      <v-card-text>
        <v-text-field
          v-model="userName"
          label="Enter Your Heroic Name"
          outlined
          dense
          solo
          placeholder="e.g., Guest"
        ></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="deep-purple accent-4" dark @click="saveName">
          <v-icon left>mdi-shield-check</v-icon>
          Proclaim
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  data() {
    return {
      showDialog: !localStorage.getItem('userName'),
      userName: localStorage.getItem('userName') || 'Guest'
    };
  },
  methods: {
    saveName() {
      if (this.userName.trim() === '') {
        this.userName = 'Guest'; // Default name if empty
      }
      localStorage.setItem('userName', this.userName);
      this.showDialog = false;
    }
  }
};
</script>

<style scoped>
.elevation-12 {
  background-image: linear-gradient(to right, #5433ff, #20bdff, #a5fecb);
  border-radius: 8px;
}
</style>
