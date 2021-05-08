import axios from 'axios';

export default {
  namespaced: true,
  state: {
    exerciseTypes: [],
    loading: false,
    error: false,
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
    addExerciseType(state, newType) {
      const { exerciseTypes } = state;
      exerciseTypes.push(newType);
    },
  },
  actions: {
    getExerciseTypes({ state, commit, dispatch }) {
      dispatch('loading/setLoading', true, { root: true });
      if (localStorage.getItem('allExerciseTypes')) {
        const exerciseTypes = JSON.parse(localStorage.getItem('allExerciseTypes'));
        commit('setExerciseType', exerciseTypes);
      }
      axios.get('/ExerciseTypes', { crossdomain: true })
        .then((response) => {
          commit('setExerciseType', response.data.map((e) => e.name));
          localStorage.setItem('allExerciseTypes', JSON.stringify(state.exerciseTypes));
        })
        .catch((error) => {
          console.info(error);
        })
        .finally(() => {
          dispatch('loading/setLoading', false, { root: true });
        });
    },
    addExerciseType({ commit, dispatch }, newExerciseType) {
      dispatch('loading/setLoading', true, { root: true });
      axios.post('/ExerciseTypes', { type: newExerciseType })
        .then(() => {
          commit('addExerciseType', newExerciseType);
        })
        .catch((error) => {
          console.info(error);
        })
        .finally(() => {
          dispatch('loading/setLoading', false, { root: true });
        });
    },
  },
  modules: {
  },
};
