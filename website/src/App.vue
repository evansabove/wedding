<template>
  <div class="site-container">
    <navigation />
    <div class="page-container">
      <router-view />
    </div>
    <!-- <div style="position: relative">
      <p style="font-size: 0.8rem; text-align: center; margin-bottom: 5px">
        Made with <span style="color: red">❤</span> by us
      </p>
    </div> -->
  </div>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}

.site-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  width: 100%;
  margin: auto;
  margin-bottom: 0;
}
</style>
