import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import './plugins/bootstrap-vue'
import App from './App.vue'
import './style/site.css'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faRing, faBars } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import router from './router'
import Nav from './components/Nav.vue'
import VueGallery from 'vue-gallery'

library.add(faRing)
library.add(faBars)

Vue.component('VGallery', VueGallery)
Vue.component('font-awesome-icon', FontAwesomeIcon)
Vue.component('navigation', Nav)

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
