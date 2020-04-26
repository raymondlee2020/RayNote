import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '@/store'
import { CreateNote, Dashboard, DetailNote, Login, SignUp, UpdateInfo, UpdateNote } from '@/views'

Vue.use(VueRouter)

const routes = [
  {
    path: '',
    redirect: '/Dashboard'
  },
  {
    path: '/Login',
    name: 'Login',
    component: Login
  },
  {
    path: '/CreateNote',
    name: 'CreateNote',
    component: CreateNote,
    beforeEnter: guard
  },
  {
    path: '/Dashboard',
    name: 'Dashboard',
    component: Dashboard,
    beforeEnter: guard
  },
  {
    path: '/DetailNote',
    name: 'DetailNote',
    component: DetailNote,
    beforeEnter: guard
  },
  {
    path: '/SignUp',
    name: 'SignUp',
    component: SignUp,
    beforeEnter: guard
  },
  {
    path: '/UpdateInfo',
    name: 'UpdateInfo',
    component: UpdateInfo,
    beforeEnter: guard
  },
  {
    path: '/UpdateNote',
    name: 'UpdateNote',
    component: UpdateNote,
    beforeEnter: guard
  }
]

function guard(to, form, next) {
  if (store.state.isLogin) {
    next()
  } else {
    next({ path: '/login' })
  }
}

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
