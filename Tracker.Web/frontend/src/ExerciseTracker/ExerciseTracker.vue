<template>
  <div>
    <LoadingView />
    <SessionView />
  </div>
</template>

<script>
import LoadingView from '@/components/LoadingView.vue';
import SessionView from './SessionView.vue';

export default {
  name: 'ExerciseTracker',
  components: { LoadingView, SessionView },
};
</script>
