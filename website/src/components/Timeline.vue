<template>
  <div class="panel-outer">
    <div class="panel-container">
      <p class="day-header">Saturday 23rd September</p>
      <Panel :index="0" time="11.30am" location="Guests arrive">
        <p>
          Join us for our wedding ceremony. Please arrive by 11.30am for a
          12.00pm start. You can park at the church or in streets nearby.
        </p>

        <div class="address">
          <p>
            <a href="https://www.greenhillmethodistchurch.com/" target="_blank"
              >Greenhill Methodist Church</a
            >, School Lane, Sheffield, S8 7RL.
          </p>
        </div>

        <button class="btn btn-primary" @click="showChurchMap = !showChurchMap">
          {{ showChurchMap ? "Hide map" : "Show map" }}
        </button>
        <iframe
          v-if="showChurchMap"
          width="100%"
          height="400"
          class="map"
          referrerpolicy="no-referrer-when-downgrade"
          src="https://www.google.com/maps/embed/v1/place?key=AIzaSyDcZJrp_43FrSCUPcS-ZseO1HLa2ygrMUE&q=Greenhill+Methodist+Church&zoom=11"
          allowfullscreen
        >
        </iframe>
      </Panel>

      <Panel
        :index="0"
        time="12pm"
        location="The ceremony"
        content="Join us at Greenhill Methodist Church for the wedding ceremony."
      >
        <p>Let's get married!</p>
      </Panel>

      <Panel :index="0" time="1pm" location="Confetti and nibbles">
        <p>Shower us in confetti!</p>
      </Panel>

      <Panel :index="0" time="2pm" location="Head to Bakewell">
        <p>Leave the church behind and head to the party.</p>

        <div class="address">
          <p>B5055 Monyash Road, Nr Over Haddon, Bakewell, DE45 1JF.</p>
        </div>

        <button class="btn btn-primary" @click="showHaddonMap = !showHaddonMap">
          {{ showHaddonMap ? "Hide route" : "Show route" }}
        </button>

        <iframe
          v-if="showHaddonMap"
          width="100%"
          height="400"
          class="map"
          referrerpolicy="no-referrer-when-downgrade"
          src="https://www.google.com/maps/embed/v1/directions?key=AIzaSyDcZJrp_43FrSCUPcS-ZseO1HLa2ygrMUE
                    &origin=Greenhill+Methodist+Church
                    &destination=Bakewell+Retreats"
          allowfullscreen
        >
        </iframe>
      </Panel>

      <Panel :index="0" time="4pm" location="Food">
        <p>The wedding breakfast is served!</p>
      </Panel>

      <Panel :index="0" time="6pm" location="Games">
        <p>Play some games and mingle.</p>
      </Panel>

      <Panel :index="0" time="7.45pm" location="Cutting of the cake">
        <p>Who doesn't love cake?</p>
      </Panel>

      <Panel :index="0" time="8pm" location="Band - set 1">
        <p>Tunes. Dancing shoes on.</p>
      </Panel>

      <Panel :index="0" time="8.45pm" location="Evening food">
        <p>A little nibble...</p>
      </Panel>

      <Panel :index="0" time="9.30pm" location="Band - set 2">
        <p>Dancing and drinks</p>
      </Panel>

      <Panel :index="0" time="10.15pm" location="Sparklers">
        <p>Ooo pretty</p>
      </Panel>

      <Panel :index="0" time="11pm" location="Winding down">
        <p>Chill out, or head for bed!</p>
      </Panel>

      <p class="day-header">Sunday 24th September</p>
      <Panel :index="2">
        <p>To be decided!</p>
      </Panel>
    </div>
  </div>
</template>

<script lang="ts">
import Panel from "./Panel.vue";
export default {
  name: "Timeline",
  components: {
    Panel,
  },
  data: () => {
    return {
      showChurchMap: false,
      showHaddonMap: false,
    };
  },
};
</script>

<style lang="scss" scoped>
.panel-outer {
  position: relative;
}

.day-header {
  font-size: 4rem;
}

.map {
  border: 0;
  border-radius: 10px;
  margin-top: 1rem;
}

.address {
  margin-bottom: 1rem;

  p {
    margin-bottom: 0;
  }
}
</style>
