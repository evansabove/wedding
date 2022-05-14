<template>
    <div class="site-container">
        <p class="mega">Andy and Liz</p>
        <p class="sub-heading">are getting married</p>
        <div class="splash-container">
        </div>  

        <Timeline />
    </div>
</template>

<script lang="ts">
import Panel from './Panel.vue'
import Timeline from './Timeline.vue'

export default {
  name: 'Home',
  components: {
   Panel,
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
.splash-container {
    width: 100%;
    height: 500px;
    background-image: url('../../public/splash5.jpg');
    background-position: center center;
    background-size: 100% auto;
    background-repeat: no-repeat;
    opacity: 1;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 20px;
}
.mega {
    font-size: 5rem;
    margin: 0;
    margin-bottom: 20px;
    text-align: center;
}
.sub-heading {
    font-size: 1.2rem;
    margin: 0;
    margin-bottom: 20px;
    text-align: center;
}
</style>
