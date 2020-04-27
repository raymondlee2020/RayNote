import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isLogin: true
  },
  mutations: {
    setIsLogin: (state, status) => {
      state.isLogin = status;
    }
  },
  actions: {
  },
  modules: {
  }
})
