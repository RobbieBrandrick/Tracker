<template>
  <div :id="'AddExerciseTypeView' + ucid">

  <a class="link-primary" data-bs-toggle="modal"
    :data-bs-target="'#' + modalId">
    New Type
  </a>

    <div class="modal fade" :id="modalId" tabindex="-1"
      :aria-labelledby="'#' + modalLabelId" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" :id="modalLabelId">
              Add a new exercise type
            </h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal"
              aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col">
                <AlertsView :type="'warning'" :message="'An error as occurred'" />
              </div>
            </div>
            <div class="row">
              <div class="col">
                <label for="newExerciseType">New Exercise Type</label>
                <input
                  class="form-control"
                  type="text"
                  name="newExerciseType"
                  v-model.trim="$v.exerciseType.$model"
                />
                <div class="error" v-if="!$v.exerciseType.required">Exercise Type is required</div>
                <div class="error" v-if="!$v.exerciseType.minLength">
                    Exercise Type must have at least {{$v.exerciseType.$params.minLength.min}} letters.
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary"
              @click="AddNewExerciseType">Save changes</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { required, minLength } from 'vuelidate/lib/validators';
import ExerciseTypesMixins from '@/mixins/exercise-types-mixin';
import ucid from '@/mixins/ucid';
import AlertsView from '@/components/AlertsView.vue';

export default {
  name: 'ExerciseTypes',
  mixins: [ExerciseTypesMixins, ucid],
  components: { AlertsView },
  data() {
    return {
      exerciseType: '',
      showModal: false,
      modalId: `AddExerciseTypeViewModal${this.ucid}`,
      modalLabelId: `AddExerciseTypeViewModalLabel${this.ucid}`,
    };
  },
  validations: {
    exerciseType: {
      required,
      minLength: minLength(3),
    },
  },
  methods: {
    AddNewExerciseType() {
      this.addExerciseType(this.exerciseType);
      this.$emit('NewExerciseTypeAdded', this.exerciseType);
    },
  },
};
</script>
