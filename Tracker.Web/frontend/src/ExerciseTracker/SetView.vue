<template>
  <div :id="'SetView' + ucid">
    <div class="form-row">
      <div class="form-group col-md-3">
        <label for="weight">Weight</label>
        <input
          class="form-control"
          type="text"
          name="weight"
          v-model="set.weight"
        />
      </div>
      <div class="form-group col-md-3">
        <label for="weight">Reps</label>
        <input
          class="form-control"
          type="text"
          name="weight"
          v-model="set.reps"
        />
      </div>
      <div class="form-group col-md-3">
        <label for="weight">RPE</label>
        <input
          class="form-control"
          type="text"
          name="weight"
          v-model="set.rpe"
        />
      </div>
      <div class="form-group col-md-3">
        <button class="btn btn-danger" @click="remove">x</button>
      </div>
    </div>
  </div>
</template>

<script>
import ucid from '@/mixins/ucid';
import CurrentSessionMixin from '@/mixins/session-mixin';

export default {
  name: 'SetView',
  mixins: [ucid, CurrentSessionMixin],
  props: {
    exerciseId: Number,
    setId: Number,
  },
  computed: {
    set() {
      const set = this.getExerciseSet()(this.exerciseId, this.setId);

      return set;
    },
  },
  methods: {
    getDetails() {
      return {
        exerciseId: this.exerciseId,
        setId: this.setId,
        weight: this.set.weight,
        reps: this.set.reps,
        rpe: this.set.rpe,
      };
    },
    remove() {
      this.removeExerciseSet({ exerciseId: this.exerciseId, setId: this.setId });
    },
  },
};
</script>
