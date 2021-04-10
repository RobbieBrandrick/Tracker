<template>
  <div>
    <div v-for="(set, index) in sets" :key="index">
      <SetView :exerciseId="exerciseId" :setId="set.id" />
    </div>
    <button class="btn btn-primary" @click="add">+</button>
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
      const sets = this.getSets()(this.exerciseId);

      return sets;
    },
  },
  methods: {
    add() {
      this.addSet(this.exerciseId);
    },
  },
  mounted() {
    this.addSet(this.exerciseId);
  },
};
</script>
