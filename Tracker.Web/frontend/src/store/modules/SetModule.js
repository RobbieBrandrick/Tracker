export default ({
  state: {
    newSetId: 0,
  },
  getters: {
    getSet: (state, getters) => (exerciseId, setId) => {
      const sets = getters.getSets(exerciseId);
      const set = sets.find((e) => e.id === setId);
      return set;
    },
  },
  mutations: {
    addSet(state, sets) {
      sets.push({
        id: state.newSetId,
        weight: 0,
        reps: 0,
        rpe: 0,
      });
    },
    removeSet(state, details) {
      const { sets, setId } = details;
      const setIndex = sets.findIndex((e) => e.id === setId);
      sets.splice(setIndex, 1);
    },
    updateSet(state, setDetails) {
      const { set, weight, reps, rpe } = setDetails;
      set.weight = weight;
      set.reps = reps;
      set.rpe = rpe;
    },
    incrementNewSetId(state) {
      state.newSetId += 1;
    },
  },
  actions: {
    addSet({ commit, getters }, exerciseId) {
      const sets = getters.getSets(exerciseId);
      commit('addSet', sets);
      commit('incrementNewSetId');
    },
    removeSet({ commit, getters }, details) {
      const { exerciseId, setId } = details;
      const sets = getters.getSets(exerciseId);
      commit('removeSet', { sets, setId });
    },
    updateSet({ commit, getters }, details) {
      const { exerciseId, setId, weight, reps, rpe } = details;
      const set = getters.getSet(exerciseId, setId);
      commit('updateSet', { set, weight, reps, rpe });
    },
  },
});
