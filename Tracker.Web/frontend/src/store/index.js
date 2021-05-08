import Vue from 'vue';
import Vuex from 'vuex';

import ExerciseSessionModule from './modules/ExerciseSessionModule';
import ExerciseTypes from './modules/ExerciseTypesModule';
import LoadingModule from './modules/LoadingModule';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    session: ExerciseSessionModule,
    exerciseTypes: ExerciseTypes,
    loading: LoadingModule,
  },
});
