<template>
  <div>
    <div class="form-row">
      <div class="form-group col-md-3">
        <label for="exerciseType">Exercise</label>
        <select id="exerciseType" class="form-control" v-model="selected">
          <option
            v-for="(type, index) in exerciseTypes"
            :key="index"
            v-bind:value="type"
          >
            {{ type }}
          </option>
        </select>
      </div>
    </div>
  </div>
</template>

<script>
import ExerciseTypesMixins from '@/mixins/exercise-types-mixin';
import CurrentSessionMixin from '@/mixins/session-mixin';

export default {
  name: 'ExerciseTypes',
  mixins: [ExerciseTypesMixins, CurrentSessionMixin],
  props: {
    exerciseId: Number,
  },
  data() {
    return {
      selected: '',
    };
  },
  mounted() {
    const exercise = this.getExercise()(this.exerciseId);

    this.selected = exercise.exerciseType;
  },
  updated() {
    this.updateExerciseType({ exerciseId: this.exerciseId, exerciseType: this.selected });
  },
};
</script>
