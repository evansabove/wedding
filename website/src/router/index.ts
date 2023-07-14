import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from "@/views/Home.vue";
import Gifts from "@/views/Gifts.vue";
import Agenda from "@/views/Agenda.vue";
import Accommodation from "@/views/Accommodation.vue";
import Photos from "@/views/Photos.vue";

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/gifts',
    name: 'gifts',
    component: Gifts
  },
  {
    path: '/agenda',
    name: 'agenda',
    component: Agenda
  },
  {
    path: '/accommodation',
    name: 'accommodation',
    component: Accommodation
  },
  // {
  //   path: '/photos',
  //   name: 'photos',
  //   component: Photos
  // },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
