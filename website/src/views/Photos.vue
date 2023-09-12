<template>
  <div>
    <div class="page-container">
      <h1>Photos</h1>

      <b-form-file
        v-model="file"
        :state="Boolean(file)"
        placeholder="Choose a file or drop it here..."
        drop-placeholder="Drop file here..."
        multiple
      ></b-form-file>

      <Panel :index="1">
        <b-button :disabled="!Boolean(file)" @click="upload">Upload</b-button>
      </Panel>
    </div>

    <div>
      <a v-for="photo in photos" :href="photo.fullImageUrl" :key="photo.name">
        <img :src="photo.thumbnailUrl" />
      </a>
    </div>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import axios from "axios";
import IPhotoResponse from "../IPhotoResponse";
import VueGallery from 'vue-gallery';

export default {
  name: "Photos",
  components: {
    Panel,
    VueGallery
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
  computed: {
  },
  methods: {
    load: async function () {
      let photos = await axios.get<IPhotoResponse>(
        "https://andyandlizwedding.azurewebsites.net/api/media?code=35cMSYzqrogv_bV3x2zjcwCnKRVgnzUGNySxM_HDxLmzAzFuxgCmag=="
      );

      (this as any).photos = photos.data;
    },
    upload: function () {
      let formData = new FormData();
      //attach many
      for (let i = 0; i < (this as any).file.length; i++) {
        formData.append(`file${i}`, (this as any).file[i]);
      }

      axios
        .post(
          "https://andyandlizwedding.azurewebsites.net/api/media?code=lAHQKstJu2b3m-sm2qWP0FcQL-sSHH8JmJCrnaBMQJjsAzFupYAI5Q==",
          formData,
          {
            headers: {
              "Content-Type": "multipart/form-data",
            },
          }
        )
        .then((response) => {
          (this as any).load();
        })
        .catch((error) => {})
        .finally(() => {});
    },
  },
};
</script>

<style lang="scss" scoped>
</style>
