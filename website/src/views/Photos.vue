<template>
  <div class="page-container">
    <h1>Photos</h1>

    <b-form-file
      v-model="file"
      :state="Boolean(file)"
      placeholder="Choose a file or drop it here..."
      drop-placeholder="Drop file here..."
    ></b-form-file>

    <Panel :index="1">
      <b-button :disabled="!Boolean(file)" @click="upload">Upload</b-button>
    </Panel>

    <b-row>
      <b-col v-for="photo in photos" :key="photo.thumbnailUrl">
        <a :href="photo.fullImageUrl"><img :src="photo.thumbnailUrl"/></a>
      </b-col>
    </b-row>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import axios from 'axios'
import IPhotoResponse from '../IPhotoResponse'
export default {
  name: "Photos",
  components: {
    Panel,
  },
  data() {
    return {
      file: null,
      photos: [],
    };
  },
  mounted() {
    (this as any).load();
  },
  methods: {
    load: async function() {
      let photos = await axios.get<IPhotoResponse>('https://andyandlizwedding.azurewebsites.net/api/media?code=35cMSYzqrogv_bV3x2zjcwCnKRVgnzUGNySxM_HDxLmzAzFuxgCmag==');

      (this as any).photos = photos.data;
    },
    upload: function() {
      let formData = new FormData();
      formData.append('file', (this as any).file);

      axios.post('https://andyandlizwedding.azurewebsites.net/api/media?code=lAHQKstJu2b3m-sm2qWP0FcQL-sSHH8JmJCrnaBMQJjsAzFupYAI5Q==', formData, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      }).then((response) => {
      }).catch((error) => {
      }).finally(() => {
      })
    }
  }
};
</script>

<style lang="scss" scoped>
</style>
