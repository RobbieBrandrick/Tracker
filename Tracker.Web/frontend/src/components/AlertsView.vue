<template>
  <div>
    <div class="alert" :class="'alert-' + type" role="alert">
      {{ message }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'AlertsView',
  props: {
    type: String,
    message: String,
  },
};
</script>
