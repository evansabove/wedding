<template>
  <div>
    <div class="splash-container">
      <div>
        <p class="mega">Andy & Liz</p>
        <p class="sub-heading">Saturday 23rd September 2023</p>
      </div>
    </div>

    <div class="page-container">
      <h1 class="centered">It's getting closer!</h1>

      <Panel :index="1">
        <p>
          We're really looking forward to celebrating our day with you! Check
          out the agenda for the day
          <router-link to="/agenda">here</router-link>.
        </p>
      </Panel>

      <Panel :index="2">
        <div>
          <div style="text-align: center">
            <img class="together" src="together.webp" />
          </div>
        </div>
      </Panel>
    </div>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import Timeline from "../components/Timeline.vue";

export default {
  name: "Home",
  components: {
    Panel,
    Timeline,
  },
};
</script>

<style lang="scss" scoped>
.splash-container {
  width: 100%;
  height: 700px;
  background-image: url("../../public/splash.webp");
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
  color: white;
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

.centered {
  text-align: center;
}

.together {
  width: 50%;

  @media only screen and (max-width: 600px) {
    width: 100%;
  }
}
</style>
