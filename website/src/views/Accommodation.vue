<template>
  <div>
    <h1>Accommodation</h1>
    <Panel>
      <p>
        We have exclusive use of
        <a target="_blank" href="https://www.bakewellretreats.com/haddongrove"
          >Haddon Grove Farm Cottages</a
        >
        for Friday 22nd, Saturday 23rd and Sunday 24th nights.
      </p>
      <p>
        The cottages range from one to five bedrooms sleeping 49 guests across
        the whole site, and each contain a kitchen, bathrooms and communal
        areas.
      </p>
      <p>
        There are also outdoor BBQs, a games room, a playground and a swimming
        pool (so pack your costume!). We would love to have you to stay!
      </p>
      <p>
        As part of our hire, we've paid for all the rooms upfront. The rooms owe
        us about £40 per person per night, so a contribution around this figure
        would be great. Get in touch if you're interested, we'd really love to
        have you! 👍
      </p>
    </Panel>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
export default {
  name: "Accommodation",
  components: {
    Panel,
  },
  data: () => {
    return {};
  },
};
</script>

<style lang="scss" scoped>
</style>
