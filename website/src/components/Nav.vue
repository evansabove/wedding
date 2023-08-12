<template>
  <div>
    <b-navbar toggleable="lg" type="dark">
      <b-navbar-brand href="/">Andy & Liz</b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item href="agenda">Agenda</b-nav-item>
          <b-nav-item href="accommodation">Accommodation</b-nav-item>
          <b-nav-item href="gifts">Gifts</b-nav-item>
          <!-- <b-nav-item href="photos">Photos</b-nav-item> -->
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script lang="ts">
export default {
  name: "Nav",
  props: {},
  components: {},
};
</script>

<style scoped>
nav {
  background: #222e50;
}

nav a {
  color: #fff;
  font-weight: normal !important;
  text-decoration: none;
}

.nav-item {
  padding-left: 0.5rem;
  padding-right: 0.5rem;
  font-size: 1.25rem;
}

.navbar-brand {
  text-decoration: none;
}
</style>
