import ExerciseModule from './ExerciseModule';
import SetModule from './SetModule';

export default {
  namespaced: true,
  state: {
    exercises: [],
  },
  getters: {
    getExercises: (state) => () => {
      const { exercises } = state;
      return exercises;
    },
  },
  mutations: {},
  actions: {},
  modules: {
    ExerciseModule,
    SetModule,
  },
};
