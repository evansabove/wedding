<template>
  <div class="card-container">
    <div>
      <b-card :img-src="image" :img-left="index % 2 == 0" :img-right="index % 2 != 0">
        <b-card-header :header="title" header-class="panel-header">
        </b-card-header>

        <b-card-text>
          {{content}}
        </b-card-text>
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
  margin-top: 50px;
  margin-bottom: 50px;
}
.panel-header {
  font-size: 2rem;
  padding: 0;
}
.card-img-right {
  border-radius: 20px;
}
.card-img-left {
  border-radius: 20px;
}
.card-header {
  border: 0;
  background: transparent;
}
</style>
