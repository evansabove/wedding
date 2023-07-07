<template>
  <div class="site-container">
    <div class="splash-container">
      <div>
        <p class="mega">Andy & Liz</p>
        <p class="sub-heading">Saturday 23rd September 2023</p>
      </div>
    </div>
    <Timeline/>
    <div style="position: relative">
      <p style="font-size: 0.8rem; text-align: center; margin-bottom: 5px;">Made with <span style="color: red">❤</span> by us</p>
    </div>

  </div>
</template>

<script lang="ts">
import Panel from '../components/Panel.vue'
import Timeline from '../components/Timeline.vue'

export default {
  name: 'Home',
  components: {
    Panel,
    Timeline
  }
};
</script>

<style lang="scss" scoped>
.site-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  width: 100%;
  margin: auto;
  margin-bottom: 0;
}

.splash-container {
  width: 100%;
  height: 700px;
  background-image: url('../../public/splash.png');
  background-position: center center;
  background-size: cover;
  background-repeat: no-repeat;
  opacity: 1;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 20px;
  padding-top: 10px;

  @media only screen and (max-width: 600px) {
    height: 500px;
  }
}

.mega {
  font-size: 5rem;
  margin: 0;
  text-align: center;
}

.sub-heading {
  font-size: 2.2rem;
  margin: 0;
  margin-bottom: 20px;
  text-align: center;
}
</style>
