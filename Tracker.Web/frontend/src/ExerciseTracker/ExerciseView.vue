<template>
  <div :id="'ExerciseView_' + ucid">
    <ExerciseTypes :exerciseId="exerciseId" />
    <SetsView :exerciseId="exerciseId" />
  </div>
</template>

<script>
import ucid from '@/mixins/ucid';
import ExerciseTypes from './ExerciseTypes.vue';
import SetsView from './SetsView.vue';

export default {
  name: 'ExerciseView',
  mixins: [ucid],
  components: { ExerciseTypes, SetsView },
  props: {
    exerciseId: Number,
  },
  data() {
    return {};
  },
  methods: {},
};
</script>
