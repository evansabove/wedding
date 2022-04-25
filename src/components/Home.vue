<template>
    <div class="site-container">
        <p class="mega">Andy and Liz</p>
        <p class="sub-heading">are getting married</p>
        <div class="splash-container">
        </div>  

        <Panel :index="0" image="pic1.jpg" title="When is it?" content="We're not entirely sure."/>
        <Panel :index="1" image="pic2.jpg" title="Where is it?" content="We haven't decided yet."/>
        <Panel :index="2" image="pic3.jpg" title="What's the plan afterwards?" content="We haven't decided yet."/>
    </div>
</template>

<script lang="ts">
import Panel from './Panel.vue'
export default {
  name: 'Home',
  components: {
   Panel   
  }
};
</script>

<style scoped>
.left-container {
    display: flex;
    justify-content: left;
    flex-direction: column;
    /* width: 80%; */
}
.outer-container {
    width: auto;
    margin: auto;
}
.site-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    color: #fff;
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

@media only screen and (max-width: 1024px) {
    .splash-container {
        height: 200px;
    }
}
</style>
