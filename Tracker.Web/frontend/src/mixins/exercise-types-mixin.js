import { mapState, mapActions } from 'vuex';

export default {
  created() {
    this.getExerciseTypes();
  },
  computed: {
    ...mapState('exerciseTypes', {
      exerciseTypes: 'exerciseTypes',
    }),
  },
  methods: {
    ...mapActions('exerciseTypes', [
      'getExerciseTypes',
      'addExerciseType',
    ]),
  },
};
