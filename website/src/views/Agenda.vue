<template>
  <div class="page-container">
    <Timeline />
  </div>
</template>

<script lang="ts">
import Panel from '../components/Panel.vue'
import Timeline from '../components/Timeline.vue'

export default {
  name: 'Agenda',
  components: {
    Panel,
    Timeline
  }
};
</script>

<style lang="scss" scoped>
</style>
