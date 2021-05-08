export default ({
  state: {},
  getters: {
    getExerciseSet: (state, getters) => (exerciseId, setId) => {
      const sets = getters.getExerciseSets(exerciseId);
      const set = sets.find((e) => e.id === setId);
      return set;
    },
    getAllExerciseSets: (state, getters) => () => {
      const sets = getters
        .getExercises()
        .map((e) => e.sets)
        .reduce((a, b) => a.concat(b));
      return sets;
    },
    getExerciseSets: (state, getters) => (exerciseId) => {
      const exercise = getters.getExercise(exerciseId);
      return exercise.sets;
    },
    getNewSetId: (state, getters) => () => {
      const sets = getters.getAllExerciseSets()
        .slice()
        .sort((lhs, rhs) => rhs.id - lhs.id);
      if (sets.length === 0) {
        return 0;
      }
      return sets[0].id + 1;
    },
  },
  mutations: {
    addExerciseSet(state, details) {
      const { setId, sets, order } = details;

      // Adjust ordering for new set
      sets
        .filter((e) => e.order >= order)
        .forEach((e) => { e.order += 1; });

      sets.push({
        id: setId,
        weight: 0,
        reps: 0,
        rpe: 0,
        order,
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
    updateSetsOrder(state, details) {
      const { sets } = details;
      let order = 0;
      sets.forEach((e) => {
        e.order = order;
        order += 1;
      });
    },
  },
  actions: {
    addExerciseSet({ commit, dispatch, getters }, details) {
      const { exerciseId, order } = details;
      const sets = getters.getExerciseSets(exerciseId);
      const setId = getters.getNewSetId();
      commit('addExerciseSet', { setId, sets, order });
      dispatch('saveSessionToLocalStorage');
    },
    removeExerciseSet({ commit, dispatch, getters }, details) {
      const { exerciseId, setId } = details;
      const sets = getters.getExerciseSets(exerciseId);
      commit('removeExerciseSet', { sets, setId });
      commit('updateSetsOrder', { sets });
      dispatch('saveSessionToLocalStorage');
    },
    updateExerciseSet({ commit, dispatch, getters }, details) {
      const { exerciseId, setId, weight, reps, rpe } = details;
      const set = getters.getExerciseSet(exerciseId, setId);
      commit('updateExerciseSet', { set, weight, reps, rpe });
      dispatch('saveSessionToLocalStorage');
    },
  },
});
