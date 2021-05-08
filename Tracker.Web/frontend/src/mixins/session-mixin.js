import { mapState, mapGetters, mapMutations, mapActions } from 'vuex';

export default {
  created() {
    this.loadSession();
  },
  computed: {
    ...mapState('session', {
      exercises: 'exercises',
    }),
  },
  methods: {
    ...mapGetters('session', {
      getExercise: 'getExercise',
      getExercises: 'getExercises',
      getExerciseSets: 'getExerciseSets',
      getExerciseSet: 'getExerciseSet',
    }),
    ...mapMutations('session', {}),
    ...mapActions('session', {
      saveSession: 'saveSession',
      loadSession: 'loadSession',
      saveSessionToLocalStorage: 'saveSessionToLocalStorage',
      clearSession: 'clearSession',
      updateExerciseType: 'updateExerciseType',
      addExerciseToRepo: 'addExercise',
      removeExercise: 'removeExercise',
      addExerciseSet: 'addExerciseSet',
      removeExerciseSet: 'removeExerciseSet',
      updateExerciseSet: 'updateExerciseSet',
    }),
  },
};
