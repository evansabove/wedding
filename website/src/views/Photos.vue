<template>
  <div>
    <div class="page-container">
      <h1>Photos</h1>

      <b-form-file
        v-model="files"
        :state="Boolean(files)"
        placeholder="Choose files..."
        drop-placeholder="Drop file here..."
        multiple
        @input="upload"
        :disabled="uploading"
      ></b-form-file>
      <div v-if="uploading">
        <b-spinner variant="primary" label="Spinning" class="mt-5"></b-spinner>
        <p>Uploading...</p>
      </div>
    </div>

    <div class="image-container">
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
      files: null,
      photos: [],
      uploading: false
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
    upload: function (files) {
      (this as any).uploading = true;
      let formData = new FormData();

      for (let i = 0; i < files.length; i++) {
        formData.append(`file${i}`, files[i]);
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
          (this as any).files = []
        })
        .catch((error) => {})
        .finally(() => {
          (this as any).uploading = false;
        });
    },
  },
};
</script>

<style lang="scss" scoped>
.image-container {
  display: flex;
  align-items: ceneter;
  justify-content: center ;
  flex-wrap: wrap;
  margin-top: 2rem;
}
</style>
