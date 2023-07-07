<template>
    <div class="panel-outer">
        <div class="panel-container">
            <p class="day-header">Saturday</p>
            <Panel 
                :index="0" 
                time="12pm Greenhill Methodist Church, Sheffield"
                location=""
                content="Join us at Greenhill Methodist Church for the wedding ceremony.">
              <p>Let's get married! Join us for our wedding ceremony. Please arrive by 11.30am for a 12.00pm start. You can park at the church or in streets nearby.</p>

              <div class="address">
                <p><a href="https://www.greenhillmethodistchurch.com/" target="_blank">Greenhill Methodist Church</a>, School Lane, Sheffield, S8 7RL.</p>
              </div>

              <button class="btn btn-light" @click="showChurchMap = !showChurchMap">{{ showChurchMap ? 'Hide map' : 'Show map'}}</button>
              <iframe
                  v-if="showChurchMap"
                  width="100%"
                  height="400"
                  class="map"
                  referrerpolicy="no-referrer-when-downgrade"
                  src="https://www.google.com/maps/embed/v1/place?key=AIzaSyDcZJrp_43FrSCUPcS-ZseO1HLa2ygrMUE&q=Greenhill+Methodist+Church&zoom=11"
                  allowfullscreen>
              </iframe>
            </Panel>

            <Panel 
                :index="1" 
                image="pic2.jpg" 
                time="2pm Haddon Grove Farm Cottages, Bakewell"
                location="">
              <p>The party continues at <a target="_blank" href="https://www.bakewellretreats.com/haddongrove">Haddon Grove Farm Cottages</a> in the rolling hills outside Bakewell. Join us for food, fun and games!</p>
              <p>Parking is available on site.</p>

              <div class="address">
                <p>B5055 Monyash Road, Nr Over Haddon, Bakewell, DE45 1JF.</p>
              </div>

              <button class="btn btn-light" @click="showHaddonMap = !showHaddonMap">{{ showHaddonMap ? 'Hide route' : 'Show route'}}</button>

              <iframe
                  v-if="showHaddonMap"
                  width="100%"
                  height="400"
                  class="map"
                  referrerpolicy="no-referrer-when-downgrade"
                  src="https://www.google.com/maps/embed/v1/directions?key=AIzaSyDcZJrp_43FrSCUPcS-ZseO1HLa2ygrMUE
                    &origin=Greenhill+Methodist+Church
                    &destination=Bakewell+Retreats"
                  allowfullscreen>
              </iframe>
            </Panel>

          <Panel
                :index="2"
                time="Bedtime"
                location="">
              <p>We have exclusive use of <a target="_blank" href="https://www.bakewellretreats.com/haddongrove">Haddon Grove Farm Cottages</a> for Friday, Saturday and Sunday nights.
                The cottages range from one to five bedrooms sleeping 49 guests across the whole site, and each
                contain a kitchen, bathrooms and communal areas. There are also outdoor BBQs, a games room, a playground and
                a swimming pool (so pack your costume!). We would love to have you to stay!
                </p>
<!--              <p>If you'd like to stay, we're charging £30 per person per night.</p>-->
<!--              <p>If you'd like to stay, the price we have paid is £30 per person per night but speak to us about this (thumb) </p>-->
<!--              <p>The cottages average at £30 per person per night.  We'd love to you stay so do speak to us about this (smilie) </p>-->
<!--&lt;!&ndash;              <p>Want to sleep over?  We have paid £30 kper person per night-ish.  Do chat to us about different options. </p>&ndash;&gt;-->
<!--              <p>Let's have a sleep over!  Do chat to us about how long and where you'd like to stay (we've paid about £30 pppn but we can chat about this) </p>-->
<!--              <p>We have paid around £30pppn but we'd rather have you than you're money so let's chat it through </p>-->
              <p>As part of our hire, we've paid for all the rooms upfront. The rooms owe us about £40 per person per night,
                so a contribution around this figure would be great. Get in touch if you're interested, we'd really love to have you! 👍
<!--              <p>Want to stay over? The rooms owe us about £30 per person per night, so a contribution like this could help fund more fun for the next day or night before!-->
            </p>
            </Panel>

            <p class="day-header">
              Sunday
            </p>
          <Panel
              :index="2"
              date="Saturday 23rd September 2023">
            <p>To be decided, but may include:</p>
            <ul>
              <li>A delicious brunch</li>
              <li>Collecting empty bottles</li>
              <li>Aimlessly wandering around</li>
              <li>A walk in the beautiful Peak District</li>
              <li>Pool party</li>
              <li>A BBQ</li>
            </ul>
          </Panel>

          <p class="day-header">
            Are you in?
          </p>

          <Panel
          :index="3">
            <p>Please send an email to rsvp@<span>andyandliz.wedding</span> confirming your numbers and any dietary requirements!</p>
            <div >
              <div style="text-align: center">
                <img class="together" src="together.jpg" />
              </div>
            </div>
          </Panel>
        </div>
    </div>
</template>

<script lang="ts">
import Panel from './Panel.vue'
export default {
  name: 'Timeline',
  components: {
   Panel
  },
  data: () => {
    return {
      showChurchMap: false,
      showHaddonMap: false,
    }
  }
};

</script>

<style lang="scss" scoped>

.panel-outer {
    position: relative;
}

.day-header {
  font-size: 4rem;
  text-align: center;
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

.together {
  width: 50%;

  @media only screen and (max-width: 600px) {
    width: 100%;
  }
}
</style>
