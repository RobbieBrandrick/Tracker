export default ({
  state: {
    newSetId: 0,
  },
  getters: {
    getExerciseSet: (state, getters) => (exerciseId, setId) => {
      const sets = getters.getExerciseSets(exerciseId);
      const set = sets.find((e) => e.id === setId);
      return set;
    },
  },
  mutations: {
    addExerciseSet(state, sets) {
      sets.push({
        id: state.newSetId,
        weight: 0,
        reps: 0,
        rpe: 0,
      });
    },
    removeExerciseSet(state, details) {
      const { sets, setId } = details;
      const setIndex = sets.findIndex((e) => e.id === setId);
      sets.splice(setIndex, 1);
    },
    updateExerciseSet(state, setDetails) {
      const { set, weight, reps, rpe } = setDetails;
      set.weight = weight;
      set.reps = reps;
      set.rpe = rpe;
    },
    incrementNewExerciseSetId(state) {
      state.newSetId += 1;
    },
  },
  actions: {
    addExerciseSet({ commit, getters }, exerciseId) {
      const sets = getters.getExerciseSets(exerciseId);
      commit('addExerciseSet', sets);
      commit('incrementNewExerciseSetId');
    },
    removeExerciseSet({ commit, getters }, details) {
      const { exerciseId, setId } = details;
      const sets = getters.getExerciseSets(exerciseId);
      commit('removeExerciseSet', { sets, setId });
    },
    updateExerciseSet({ commit, getters }, details) {
      const { exerciseId, setId, weight, reps, rpe } = details;
      const set = getters.getExerciseSet(exerciseId, setId);
      commit('updateExerciseSet', { set, weight, reps, rpe });
    },
  },
});
