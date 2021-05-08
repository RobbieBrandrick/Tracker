<template>
  <div :id="'SetView' + ucid">
    <div class="card">
      <div class="card-header">
        <span>Set # {{set.order + 1}}</span>
      </div>
      <div class="card-body">
        <div class="row">
          <div class="col-md-2">
            <label class="form-label" for="weight">Weight</label>
            <input
              class="form-control"
              type="text"
              name="weight"
              v-model="set.weight"
            />
          </div>
          <div class="col-md-2">
            <label class="form-label" for="weight">Reps</label>
            <input
              class="form-control"
              type="text"
              name="weight"
              v-model="set.reps"
            />
          </div>
          <div class="col-md-2">
            <label class="form-label" for="weight">RPE</label>
            <input
              class="form-control"
              type="text"
              name="weight"
              v-model="set.rpe"
            />
          </div>
          <div class="col-md-2">
            <label class="form-label" for="">Add</label>
            <button class="btn btn-primary form-control" @click="this.add">+</button>
          </div>
          <div class="col-md-2">
            <label class="form-label" for="">Remove</label>
            <button class="btn btn-danger form-control" @click="this.remove">x</button>
          </div>
        </div>
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
  updated() {
    this.saveSessionToLocalStorage();
  },
  methods: {
    getDetails() {
      return {
        exerciseId: this.exerciseId,
        setId: this.setId,
        weight: this.set.weight,
        reps: this.set.reps,
        rpe: this.set.rpe,
        order: this.set.order,
      };
    },
    setDetails(set) {
      this.weight = set.weight;
      this.reps = set.reps;
      this.rpe = set.rpe;
      this.order = set.order;
    },
    remove() {
      this.removeExerciseSet({
        exerciseId: this.exerciseId,
        setId: this.setId,
      });
    },
    add() {
      const details = {
        exerciseId: this.exerciseId,
        order: this.set.order + 1,
      };
      this.addExerciseSet(details);
    },
  },
};
</script>
