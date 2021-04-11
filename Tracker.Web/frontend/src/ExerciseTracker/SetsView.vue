<template>
  <div>
    <div v-for="(set, index) in sets" :key="index">
      <SetView :exerciseId="exerciseId" :setId="set.id" />
    </div>
    <div class="form-group col-md-3">
      <button class="btn btn-primary" @click="add">+</button>
    </div>
  </div>
</template>

<script>
import CurrentSessionMixin from '@/mixins/session-mixin';
import SetView from './SetView.vue';

export default {
  name: 'SetsView',
  mixins: [CurrentSessionMixin],
  components: { SetView },
  props: {
    exerciseId: Number,
  },
  computed: {
    sets() {
      const sets = this.getExerciseSets()(this.exerciseId);

      return sets;
    },
  },
  methods: {
    add() {
      this.addExerciseSet(this.exerciseId);
    },
  },
  mounted() {
    this.addExerciseSet(this.exerciseId);
  },
};
</script>
