<template>
    <div class="panel-outer">
        <div class="panel-container">
            <p class="day-header">Saturday</p>
            <Panel 
                :index="0" 
                time="12pm Greenhill Methodist Church, Sheffield"
                location=""
                content="Join us at Greenhill Methodist Church for the wedding ceremony.">
              <p>Let's get married! Join us for our wedding ceremony. Please arrive from 11.30am for a 12.00pm start. You can park at the church or in streets nearby.</p>
              <p>The address of the church is:</p>
              <div class="address">
                <p>Greenhill Methodist Church</p>
                <p>School Lane</p>
                <p>Sheffield</p>
                <p>S8 7RL</p>
              </div>

              <!-- Try and find a nicer overlay -->
              <iframe
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
              <p>The party continues at Haddon Grove Farm Cottages in the rolling hills outside Bakewell. Join us for food, fun and (optionally) bad dancing...</p>
              <p>The address of the venue is:</p>

              <div class="address">
                <p>B5055 Monyash Road</p>
                <p>Nr Over Haddon
                <p>Bakewell</p>
                <p>DE45 1JF</p>
              </div>

              <iframe
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
              <p>Fancy sleeping over? When you're all partied out, we've got plenty of space in the farm cottages.</p>
              <p>We've got space for most of the guests - please let us know in advance if you'd like a place to stay.</p>
            </Panel>

            <p class="day-header">
              Sunday
            </p>

          <Panel
              :index="2"
              time="3pm"
              date="Saturday 23rd September 2023"
              location="Haddon Grove Farm Cottages">
            <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>
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
  }
};
</script>

<style lang="scss" scoped>

.panel-outer {
    position: relative;
}
.panel-container::before {
    content: '';
    position: absolute;
    width: 3px; 
    background: #E2E8CE;
    height: 100%;
    top: 100px;
    left: 11px;
    bottom: 0;
}

.day-header {
  font-size: 4rem;
  text-align: center;
}

.map {
  border: 0;
  border-radius: 10px;
}

.address {
  margin-bottom: 1rem;

  p {
    margin-bottom: 0;
  }
}
</style>
