<template>
  <div>
    <div class="text-box">
      <p>{{ sentence }}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      sentence: "This wordle web app is for my EWU web devlopment class, we have the greatest teacher to ever do it, her name is Meg!"
    };
  }
};
</script>

<style scroped>
.text-box {
  border: 1px solid #ccc;
  padding: 10px;
  margin: 10px;
}
</style>
