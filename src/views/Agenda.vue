<template>
  <div class="site-container">
    <Timeline />
  </div>
</template>

<script lang="ts">
import Timeline from '../components/Timeline.vue'

export default {
  name: 'Home',
  components: {
    Timeline
  }
};
</script>

<style scoped>
.site-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  width: 80%;
  margin: auto;
  margin-bottom: 50px;
}
</style>
