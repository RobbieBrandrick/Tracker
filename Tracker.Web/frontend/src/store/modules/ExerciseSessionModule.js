import ExerciseModule from './ExerciseModule';
import SetModule from './SetModule';

export default {
  namespaced: true,
  state: {
    sessionId: 0,
    exercises: [],
  },
  getters: {
    getExercises: (state) => () => {
      const { exercises } = state;
      return exercises;
    },
  },
  mutations: {
    setSession(state, session) {
      state.id = session.sessionId;
      state.exercises = session.exercises;
    },
    clearSession(state) {
      state.exercises = [];
      state.sessionId = 0;
    },
  },
  actions: {
    loadSession({ commit }, sessionId) {
      if (!sessionId && localStorage.getItem('lastExerciseSession')) {
        const sessionData = JSON.parse(localStorage.getItem('lastExerciseSession'));
        commit('setSession', sessionData);
      }
    },
    saveSessionToLocalStorage({ state }) {
      const session = { id: state.sessionId, exercises: state.exercises };
      localStorage.setItem('lastExerciseSession', JSON.stringify(session));
    },
    clearSession({ commit, dispatch }) {
      commit('clearSession');
      dispatch('saveSessionToLocalStorage');
    },
    saveSession() {
      // eslint-disable-next-line no-alert
      alert('Session Saved');
    },
  },
  modules: {
    ExerciseModule,
    SetModule,
  },
};
