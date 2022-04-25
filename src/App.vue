<template>
  <Home />
</template>

<script lang="ts">
import Home from './components/Home.vue';

export default {
  name: "App",
  components: {
    Home
  }
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

@import'~bootstrap/dist/css/bootstrap.css'
</style>
