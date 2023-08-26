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
    
  </div>
</template>

<script lang="ts">
import Panel from "../components/Panel.vue";
import axios from 'axios'

export default {
  name: "Photos",
  components: {
    Panel,
  },
  data() {
    return {
      file: null,
    };
  },
  methods: {
    upload: function() {
      let formData = new FormData();
      formData.append('file', (this as any).file);

      axios.post('api/upload', formData, {
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
