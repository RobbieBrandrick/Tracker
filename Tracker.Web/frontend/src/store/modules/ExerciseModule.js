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
    addExercise({ commit, getters }) {
      const exercises = getters.getExercises();
      commit('addExercise', exercises);
    },
    removeExercise({ commit, getters }, exerciseId) {
      const exercises = getters.getExercises();
      commit('removeExercise', { exercises, exerciseId });
    },
    updateExerciseType({ commit, getters }, typeDetails) {
      const exercise = getters.getExercise(typeDetails.exerciseId);
      commit('updateExerciseType', { exerciseType: typeDetails.exerciseType, exercise });
    },
  },
};
