<template>
  <div>
    <h1>Gifts</h1>
    <Panel :index="1">
      <p>In a nutshell... we already have everything we need!</p>
      <p>For our honeymoon, we are planning to go to Europe on our new motorbike (Margaret the BMW), to try and get to the Italian lakes.
        If you wanted to gift us something, we would welcome some money towards pasta, pizza and petrol.
      </p>
    </Panel>
  </div>
</template>

<script lang="ts">
import Panel from '../components/Panel.vue'

export default {
  name: "Gifts",
  components: {
    Panel
  }
};
</script>

<style lang="scss" scoped>
</style>
