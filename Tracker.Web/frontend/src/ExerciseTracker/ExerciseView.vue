<template>
  <div :id="'ExerciseView_' + ucid">
    <div class="card">
      <div class="card-header">
        <button @click="remove" type="button" class="btn-close float-end" data-bs-dismiss="modal"
        aria-label="Close"></button>
        <h5 class="" @click="show = !show">{{ exerciseType }}</h5>
      </div>
      <div class="card-body" v-show="show">
        <div class="row">
          <div class="col-md-2">
            <ExerciseTypes :exerciseId="exerciseId" />
          </div>
          <div class="col-md-8">
            <SetsView :exerciseId="exerciseId" />
          </div>
        </div>
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
