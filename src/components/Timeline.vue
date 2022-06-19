<template>
    <div class="panel-outer">
        <div class="panel-container">
            <Panel 
                :index="0" 
                image="pic1.jpg" 
                time="12pm" 
                date="Saturday 23rd September 2023" 
                location="Greenhill Methodist Church"
                content="Join us at Greenhill methodist church for the wedding ceremony.">
              <p>Join us at Greenhill methodist church for the wedding ceremony.</p>

              <iframe
                  width="100%"
                  height="400"
                  style="border:0"
                  referrerpolicy="no-referrer-when-downgrade"
                  src="https://www.google.com/maps/embed/v1/place?key=AIzaSyC02ljmnzYri49PY-Yxulr8LRivNtbiFDU&q=Greenhill+Methodist+Church&zoom=11"
                  allowfullscreen>
              </iframe>
            </Panel>

            <Panel 
                :index="1" 
                image="pic2.jpg" 
                time="2pm" 
                date="Saturday 23rd September 2023" 
                location="Haddon Grove Farm Cottages">
              <p>The party continues at Haddon Grove farm cottages near Bakewell! Take your time to head on over and join us for some food and music.</p>
              <p>Accommodation is available, please let us know if you want to stay. There's plenty of room!</p>

              <iframe
                  width="100%"
                  height="400"
                  style="border:0"
                  referrerpolicy="no-referrer-when-downgrade"
                  src="https://www.google.com/maps/embed/v1/directions?key=AIzaSyC02ljmnzYri49PY-Yxulr8LRivNtbiFDU
                    &origin=Greenhill+Methodist+Church
                    &destination=Bakewell+Retreats"
                  allowfullscreen>
              </iframe>
            </Panel>

            <Panel 
                :index="2" 
                image="pic3.jpg" 
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

<style scoped>

.panel-outer {
    position: relative;
}
.panel-container::before {
    content: '';
    position: absolute;
    width: 3px; 
    background: #E2E8CE;
    height: 100%;
    top: 50px;
    left: 11px;
    bottom: 0px;
}
</style>
