<template>
  <div class="about-container">
    <div class="about-content" style="text-decoration-line:underline;">
      <h1 style="font-size:2em; font-family: Georgia">
      Welcome to the About Page
    </h1>
    </div>
  </div>
  <div class="about-container" style="text-align:justify; font-family: Georgia">
    <br>
    This project is for EWU's 379 course. We're building on the wordle
    that we started in class, and making it more functional.<br> For example, 
    adding this about page, a hamburger menu and even making it pretty. 
    <br>
    <br>
    Meg rocks and makes coding fun and easy to follow. 
    Thanks Meg!
  </div>
</template>

<script lang="ts" setup>

</script>

<style scoped>
.about-container{
  display: flex;
  justify-content: center;
  padding: auto;
}
.about-content{
  margin: 0 auto;
  margin-top: 30px
}
</style>