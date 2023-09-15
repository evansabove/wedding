<template>
  <div>
    <div class="page-container">
      <h1>Photos</h1>

      <p>Please share your photos of our special day with us!</p>

      <b-form-file
        v-model="files"
        :state="Boolean(files)"
        placeholder="Choose files..."
        drop-placeholder="Drop file here..."
        multiple
        @input="upload"
        :disabled="uploading"
      ></b-form-file>
      <div v-if="uploading" class="mt-5">
        <b-spinner variant="primary" label="Spinning"></b-spinner>
        <p>Uploading...</p>
      </div>
      <div v-if="error" class="mt-5">
        <b-alert variant="danger" show>{{ error }}</b-alert>
      </div>
    </div>

    <div v-if="photoData.results.length > 0">
      <div class="image-container">
        <a
          v-for="photo in photoData.results"
          :href="photo.fullImageUrl"
          :key="photo.name"
        >
          <img :src="photo.thumbnailUrl" />
        </a>
      </div>
      <div class="pagination">
        <b-button
          variant="info"
          @click="previous"
          :disabled="photoData.page <= 1"
          >Previous</b-button
        >
        <span>Page {{ photoData.page }} of {{ photoData.totalPages }}</span>
        <b-button
          variant="info"
          @click="next"
          :disabled="photoData.page >= photoData.totalPages"
          >Next</b-button
        >
      </div>
    </div>
    <div v-else class="empty-message">
      <p>No photos yet - you could be the first!</p>
    </div>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import axios from "axios";
import IPhotoResponse from "../IPhotoResponse";
import VueGallery from "vue-gallery";

export default {
  name: "Photos",
  components: {
    Panel,
    VueGallery,
  },
  data() {
    return {
      files: null,
      uploading: false,
      error: "",
      photoData: {} as IPhotoResponse,
    };
  },
  mounted() {
    (this as any).load();
  },
  computed: {},
  methods: {
    next: function () {
      (this as any).photoData.page++;
      (this as any).load();
    },
    previous: function () {
      (this as any).photoData.page--;
      (this as any).load();
    },
    load: async function () {
      (this as any).photos = [];

      let pageNumber = (this as any).photoData.page;
      let photos = await axios.get<IPhotoResponse>(
        `https://andyandlizwedding.azurewebsites.net/api/media?code=35cMSYzqrogv_bV3x2zjcwCnKRVgnzUGNySxM_HDxLmzAzFuxgCmag==&page=${pageNumber}`
      );

      (this as any).photoData = photos.data;
    },
    upload: function (files) {
      (this as any).uploading = true;
      (this as any).error = "";
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
          //we don't need to do a full load again - we can just push if we have the right response.
          (this as any).load();
          (this as any).files = [];

          if (response.data.failed.length > 0) {
            (
              this as any
            ).error = `${response.data.failed.length} files failed to upload.`;
          }
        })
        .catch((error) => {
          console.log("There was a problem uploading the files.");
        })
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
  justify-content: center;
  flex-wrap: wrap;
  margin-top: 2rem;
}

.pagination {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 2rem;
  gap: 2rem;
}

.empty-message {
  text-align: center;
  margin-top: 4rem;
}
</style>
