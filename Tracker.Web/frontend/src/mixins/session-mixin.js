import { mapState, mapGetters, mapMutations, mapActions } from 'vuex';

export default {
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
      updateExerciseType: 'updateExerciseType',
      addExerciseToRepo: 'addExercise',
      addExerciseSet: 'addExerciseSet',
      removeExerciseSet: 'removeExerciseSet',
      updateExerciseSet: 'updateExerciseSet',
    }),
  },
};
