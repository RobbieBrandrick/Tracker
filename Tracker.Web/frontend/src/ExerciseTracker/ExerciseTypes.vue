<template>
  <div>
    <div class="row">
      <div class="col">
        <label for="exerciseType">Exercise</label>
        <AddExerciseTypeModal />
        <select id="exerciseType" class="form-select" v-model="selected">
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
import AddExerciseTypeModal from './AddExerciseType.vue';

export default {
  name: 'ExerciseTypes',
  mixins: [ExerciseTypesMixins, CurrentSessionMixin],
  components: { AddExerciseTypeModal },
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
