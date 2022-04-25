<template>
  <div class="card-container">
    <div v-if="index % 2 == 0">
      <b-card no-body class="overflow-hidden" style="max-height: 300px">
        <b-row no-gutters>
          <b-col md="6">
            <b-card-body :title="title">
              <b-card-text>
                {{content}}
              </b-card-text>
            </b-card-body>
          </b-col>

          <b-col md="6">
            <b-card-img :src="image" alt="Image" class="rounded-0"></b-card-img>
          </b-col>
        </b-row>
      </b-card>
    </div>

    <div v-else>
      <b-card no-body class="overflow-hidden" style="max-height: 300px">
        <b-row no-gutters>
          <b-col md="6">
            <b-card-img :src="image" alt="Image" class="rounded-0"></b-card-img>
          </b-col>
          <b-col md="6">
            <b-card-body :title="title">
              <b-card-text>
                {{content}}
              </b-card-text>
            </b-card-body>
          </b-col>
        </b-row>
      </b-card>
    </div>
  </div>

</template>

<script lang="ts">

export default {
  name: 'Panel',
  props: {
    title: String,
    content: String,
    image: String,
    index: Number
  },
  components: {
  }
};
</script>

<style scoped>
.card-container {
  margin-top: 20px;
}
</style>
