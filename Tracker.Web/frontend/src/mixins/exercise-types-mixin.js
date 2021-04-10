import { mapState, mapActions } from 'vuex';

export default {
  created() {
    this.get();
  },
  computed: {
    ...mapState('exerciseTypes', {
      exerciseTypes: 'exerciseTypes',
    }),
  },
  methods: {
    ...mapActions('exerciseTypes', ['get']),
  },
};
