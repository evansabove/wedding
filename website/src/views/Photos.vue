<template>
  <div class="page-container">
    <h1>Photos</h1>
    <Panel :index="1">
      <b-form-file
        v-model="files"
        placeholder="Choose files"
        drop-placeholder="Drop file here..."
      ></b-form-file>

      <b-button @click="upload">Upload</b-button>
    </Panel>
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import axios from "axios"

export default {
  name: "Photos",
  components: {
    Panel,
  },
  data() {
    return {
      file: File,
    }
  },
  methods: {
    upload: function() {
      let formData = new FormData();

      console.log((this as any).file)

      formData.append("file", (this as any).file);

      console.log("klajsdfkgsfg")
      axios.post("api/upload", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
    },
  },
};
</script>

<style lang="scss" scoped>
</style>
