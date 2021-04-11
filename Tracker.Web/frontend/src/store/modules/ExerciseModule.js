export default {
  getters: {
    getExercise: (state, getters) => (exerciseId) => {
      const exercises = getters.getExercises();
      const exercise = exercises.find((e) => e.id === exerciseId);
      return exercise;
    },
    getExerciseSets: (state, getters) => (exerciseId) => {
      const exercise = getters.getExercise(exerciseId);
      return exercise.sets;
    },
  },
  mutations: {
    addExercise(state, exercises) {
      exercises.push({
        id: exercises.length,
        typeId: 0,
        sets: [],
      });
    },
    removeExercise(state, details) {
      const { exercises, id } = details;
      const index = exercises.findIndex((e) => e.id === id);
      exercises.splice(index, 1);
    },
    updateExerciseType(state, typeDetails) {
      const { exercise } = typeDetails;
      exercise.typeId = typeDetails.typeId;
    },
  },
  actions: {
    addExercise({ commit, getters }) {
      const exercises = getters.getExercises();
      commit('addExercise', exercises);
    },
    removeExercise({ commit, getters }, id) {
      const exercises = getters.getExercises();
      commit('removeExercise', { exercises, id });
    },
    updateExerciseType({ commit, getters }, typeDetails) {
      const exercise = getters.getExercise(typeDetails.exerciseId);
      commit('updateExerciseType', { typeId: typeDetails.typeId, exercise });
    },
  },
};
