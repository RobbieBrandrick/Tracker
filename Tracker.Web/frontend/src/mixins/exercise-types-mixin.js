import { mapState, mapActions } from 'vuex';

export default {
  created() {
    this.get();
  },
  computed: {
    ...mapState('exerciseTypes', {
      exerciseTypes: 'types',
    }),
  },
  methods: {
    ...mapActions('exerciseTypes', ['get']),
  },
};
