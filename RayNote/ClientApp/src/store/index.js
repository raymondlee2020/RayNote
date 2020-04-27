import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isLogin: true,
    id: 0,
    name: "",
    token: "",
  },
  mutations: {
    setLogin: (state, status) => {
      state.isLogin = true;
      state.id = status.id;
      state.name = status.name;
      state.token = status.token;
    }
  },
  actions: {
  },
  modules: {
  }
})
