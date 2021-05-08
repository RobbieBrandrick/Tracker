export default {
  getters: {
    getExercise: (state, getters) => (exerciseId) => {
      const exercises = getters.getExercises();
      const exercise = exercises.find((e) => e.id === exerciseId);
      return exercise;
    },
  },
  mutations: {
    addExercise(state, exercises) {
      exercises.push({
        id: exercises.length,
        exerciseType: 0,
        sets: [],
      });
    },
    removeExercise(state, details) {
      const { exercises, exerciseId } = details;
      const index = exercises.findIndex((e) => e.id === exerciseId);
      exercises.splice(index, 1);
    },
    updateExerciseType(state, typeDetails) {
      const { exercise, exerciseType } = typeDetails;
      exercise.exerciseType = exerciseType;
    },
  },
  actions: {
    addExercise({ commit, dispatch, getters }) {
      const exercises = getters.getExercises();
      commit('addExercise', exercises);
      dispatch('saveSessionToLocalStorage');
    },
    removeExercise({ commit, dispatch, getters }, exerciseId) {
      const exercises = getters.getExercises();
      commit('removeExercise', { exercises, exerciseId });
      dispatch('saveSessionToLocalStorage');
    },
    updateExerciseType({ commit, dispatch, getters }, typeDetails) {
      const exercise = getters.getExercise(typeDetails.exerciseId);
      commit('updateExerciseType', { exerciseType: typeDetails.exerciseType, exercise });
      dispatch('saveSessionToLocalStorage');
    },
  },
};
