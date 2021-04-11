<template>
  <div>
    <div v-for="(exercise, index) in exercises" :key="index">
      <ExerciseView :exerciseId="exercise.id" />
    </div>

    <div class="form-group col-md-3">
      <button class="btn btn-primary" @click="addExerciseToRepo">
        Add Exercise
      </button>
    </div>
  </div>
</template>

<script>
import CurrentSessionMixin from '@/mixins/session-mixin';
import ExerciseView from './ExerciseView.vue';

export default {
  name: 'SessionView',
  mixins: [CurrentSessionMixin],
  components: { ExerciseView },
};
</script>
