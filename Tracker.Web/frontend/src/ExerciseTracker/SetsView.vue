<template>
  <div>
    <div class="row">
      <div class="col">
        <div v-for="(set, index) in sets" :key="index">
          <SetView :exerciseId="exerciseId" :setId="set.id" />
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <button class="btn btn-primary" @click="this.add">Add Set</button>
      </div>
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
      return sets
        .slice()
        .sort((lhs, rhs) => lhs.order - rhs.order);
    },
  },
  methods: {
    add() {
      const details = { exerciseId: this.exerciseId, order: this.sets.length };
      this.addExerciseSet(details);
    },
  },
};
</script>
