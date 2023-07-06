<template>
  <nav class="navbar navbar-expand-lg">
    <router-link class="navbar-brand" to="/">
        Andy & Liz
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarSupportedContent"
      aria-controls="navbarSupportedContent"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon">
        <font-awesome-icon icon="fa-solid fa-bars" style="color: #fff"/>
      </span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link class="nav-link" to="gifts">Gifts</router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link" to="agenda">Agenda</router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link" to="accommodation">Accommodation</router-link>
        </li>
      </ul>
    </div>
  </nav>
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
}

.nav-item {
    padding-left: 0.5rem;
    padding-right: 0.5rem;
}

.navbar-brand {
    text-decoration: none;
}
</style>
