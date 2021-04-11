<template>
  <div :id="'ExerciseView_' + ucid">
    <div class="card">
      <div class="card-header">
        <h5 @click="show = !show">{{ exerciseType }}</h5>
        <button type="button" class="close" @click="remove">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="card-body" v-show="show">
        <ExerciseTypes :exerciseId="exerciseId" />
        <SetsView :exerciseId="exerciseId" />
      </div>
    </div>
  </div>
</template>

<script>
import ucid from '@/mixins/ucid';
import CurrentSessionMixin from '@/mixins/session-mixin';
import ExerciseTypes from './ExerciseTypes.vue';
import SetsView from './SetsView.vue';

export default {
  name: 'ExerciseView',
  mixins: [ucid, CurrentSessionMixin],
  components: { ExerciseTypes, SetsView },
  props: {
    exerciseId: Number,
  },
  data() {
    return {
      show: true,
    };
  },
  computed: {
    exerciseType() {
      const exercise = this.getExercise()(this.exerciseId);

      if (!exercise.exerciseType) {
        return 'Choose an exercise';
      }

      return exercise.exerciseType;
    },
  },
  methods: {
    remove() {
      this.removeExercise(this.exerciseId);
    },
  },
};
</script>
