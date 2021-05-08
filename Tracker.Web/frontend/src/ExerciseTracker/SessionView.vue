<template>
  <div>

    <div class="row">
      <div class="col">
        <div v-for="(exercise, index) in exercises" :key="index">
          <ExerciseView :exerciseId="exercise.id" />
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col">
        <button class="btn btn-primary" @click="addExerciseToRepo">
          Add Exercise
        </button>
        <button class="btn btn-success" @click="saveSession">
          Save Session
        </button>
        <button class="btn btn-danger" @click="clearSession">
          Clear Session
        </button>
      </div>
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
  data() {
    return {
      timer: '',
    };
  },
  created() {
    this.timer = setInterval(this.autoSaveSession, 300000);
  },
  methods: {
    autoSaveSession() {
      this.saveSession();
    },
    cancelAutoSave() {
      clearInterval(this.timer);
    },
  },
  beforeDestroy() {
    this.cancelAutoUpdate();
  },
};
</script>
