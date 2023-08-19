<template>
  <div class="page-container">
    <h1>Gifts</h1>
    <Panel :index="1">
      <p>In a nutshell... we already have everything we need!</p>
      <p>
        For our honeymoon, we are planning to go to Europe on our new motorbike
        (Margaret the BMW GS), to try and get to the Italian lakes. If you wanted
        to gift us something, we would welcome some money towards pasta, pizza
        and petrol.
      </p>
    </Panel>

    <Panel :index="2">
      <div style="text-align: center">
        <img class="margaret" src="margaret.jpg" />
      </div>
    </Panel>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";

export default {
  name: "Gifts",
  components: {
    Panel,
  },
};
</script>

<style lang="scss" scoped>
.margaret {
  width: 50%;

  @media only screen and (max-width: 600px) {
    width: 100%;
  }
}
</style>
