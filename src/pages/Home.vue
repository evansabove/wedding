<template>
  <StoryblokComponent v-if="story" :blok="story.content" />
</template>

<script lang="ts">

import { useStoryblok } from '@storyblok/vue-2';
const story = useStoryblok('home', { version: 'draft' });

export default {
  name: 'Teaser',
  props: {
    blok: Object
  },
  components: {
  }
};
</script>