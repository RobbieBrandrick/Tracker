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
      getSets: 'getSets',
      getSet: 'getSet',
    }),
    ...mapMutations('session', {}),
    ...mapActions('session', {
      updateExerciseType: 'updateExerciseType',
      addExerciseToRepo: 'addExercise',
      addSet: 'addSet',
      removeSet: 'removeSet',
      updateSet: 'updateSet',
    }),
  },
};
