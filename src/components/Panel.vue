<template>
  <div style="position: relative">
    <span class="dot-outer"></span>
    <span class="dot-inner"></span>
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
  margin-left: 50px;
  border: 1px solid rgba(226, 232, 206, 0.3);
  border-radius: 20px;
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

.dot-outer {
  position: absolute;
  top: 50%;
  height: 24px;
  width: 24px;
  background-color: #E2E8CE;
  border-radius: 50%;
  margin-top: -12px;
}

.dot-inner {
  position: absolute;
  top: 50%;
  height: 16px;
  width: 16px;
  background-color: #222E50;
  border-radius: 50%;
  margin-top: -8px;
  left: 4px;
}
</style>
