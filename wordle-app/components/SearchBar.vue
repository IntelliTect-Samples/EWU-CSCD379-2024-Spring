<template>
  <div>
    <input 
    type="text" 
    v-model="searchQuery"
    placeholder="Search..."
    @input="onInput" />
    
    <ul v-if="filteredWords.length">
      <li v-for="word in filteredWords" :key="word"> {{ word }} </li>
    </ul>
    <p v-else>No words found.</p>
  </div>
</template>

<script lang="ts" setup>

const searchQuery = ref('');
const words = ref(['apple', 'banana', 'cherry', 'date', 'elderberry']);

const filteredWords = computed(() => {
  if (!searchQuery.value) return words.value;
  return words.value.filter(word => word.includes(searchQuery.value));
});

const onInput = () => {
  console.log('searchQuery:', searchQuery.value);
}

</script>

<style>

</style>