export default {
  namespaced: true,
  state: {
    loading: false,
  },
  getters: {
    getIsLoading(state) {
      return state.loading;
    },
  },
  mutations: {
    setLoading(state, isLoading) {
      state.loading = isLoading;
    },
  },
  actions: {
    setLoading({ commit }, isLoading) {
      commit('setLoading', isLoading);
    },
  },
};
