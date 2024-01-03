<template>
  <div>
    <div class="page-container">
      <h1>Official Photos</h1>

    <div v-if="photoData.results && photoData.results.length > 0">
      <div class="image-container">
        <a
          v-for="photo in photoData.results"
          :href="photo.fullImageUrl"
          :key="photo.name"
        >
          <img :src="photo.thumbnailUrl" class="full-image" />
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
    </div>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import axios from "axios";
import IPhotoResponse from "../IPhotoResponse";
import VueGallery from "vue-gallery";

export default {
  name: "OfficialPhotos",
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

      window.scrollTo(0,0);
    },
    previous: function () {
      (this as any).photoData.page--;
      (this as any).load();

      window.scrollTo(0,0);
    },
    load: async function () {
      (this as any).photos = [];

      let pageNumber = (this as any).photoData.page;
      let photos = await axios.get<IPhotoResponse>(
        `https://andyandlizwedding.azurewebsites.net/api/media/official?code=YL30fAAQ6En93ANKv6A2j0GzWzqkRRiAdazMbtXXNcSrAzFu_4Uw8w==&page=${pageNumber}&pageSize=200`
      );

      (this as any).photoData = photos.data;
    },
  },
};
</script>

<style lang="scss" scoped>
.image-container {
  display: flex;
  align-items: center;
  justify-content: space-around;
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

.full-image {
  object-fit: cover;
  width: 300px;
  height: 300px;
  margin-top: 1rem;
}

.page-container {
  max-width: none;
}
</style>
