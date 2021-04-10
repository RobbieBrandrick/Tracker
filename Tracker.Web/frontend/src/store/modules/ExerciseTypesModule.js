export default {
  namespaced: true,
  state: {
    exerciseTypes: [],
  },
  mutations: {
    setExerciseType(state, newTypes) {
      const { exerciseTypes } = state;
      exerciseTypes.splice(0, newTypes.length);
      exerciseTypes.unshift(...newTypes);
    },
    addExerciseTypes(state, newTypes) {
      const { exerciseTypes } = state;
      exerciseTypes.unshift(...newTypes);
    },
  },
  actions: {
    get({ commit }) {
      commit('setExerciseType', ['Squat', 'Bench', 'Deadlift', 'Pullups']);
    },
  },
  modules: {
  },
};
