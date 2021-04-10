<template>
  <div>
    <div v-for="(exercise, index) in exercises" :key="index">
      <ExerciseView :exerciseId="exercise.id" />
    </div>

    <button @click="addExerciseToRepo">Add Exercise</button>
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
