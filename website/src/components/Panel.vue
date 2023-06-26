<template>
  <div style="position: relative">
    <div class="card-container">
      <div>
        <div class="container">
          <div class="row">
            <div class="col-sm">
              <p class="white row-title">{{time}}</p>
              <p class="white location">{{location}}</p>

              <p class="card-content">
                <slot></slot>
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script lang="ts">

export default {
  name: 'Panel',
  props: {
    time: String,
    location: String,
    content: String,
    index: Number
  },
  components: {
  }
};
</script>

<style scoped>
.white {
  color: #fff;
}
.container {
  padding-top: 15px;
  padding-bottom: 15px;
}

.card-container {
  margin-top: 50px;
  margin-bottom: 50px;
}
img {
  border-radius: 20px;
}

.row-title {
  font-size: 3rem;
  margin-bottom: 0;
}

.location {
  margin-bottom: 0;
  font-size: 2rem;
}

.card-content {
  margin-top: 50px;
}
</style>
