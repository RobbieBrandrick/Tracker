<template>
  <div v-if="isLoading">
    <div class="overlay d-flex justify-content-center align-items-center">
      <div class="spinner-border">
        <span class="sr-only"></span>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'LoadingView',
  computed: {
    isLoading() {
      const isLoading = this.$store.getters['loading/getIsLoading'];

      return isLoading;
    },
  },
};
</script>

<style scoped>

.overlay {
  position: absolute;
  z-index: 10000;
  background-color: rgba(255, 255, 255, 0.5);
  width: 100%;
  height: 100%;
  transition: opacity .15s linear;
}
</style>
