<template>
  <div class="large-logo-root">
    <div class="logo">RayNote</div>
    <div class="slogan">Record Anything In Your Life</div>
  </div>
</template>

<script>
export default {
  name: "LargeLogo",
  components: {}
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.large-logo-root {
  @extend %flex-center;
  flex-direction: column;
  > .logo {
    color: #fff;
    font-size: 100px;
    font-weight: 700;
    text-shadow: 3px 3px 5px rgba(0, 0, 0, 0.5);
    margin-bottom: 15px;
  }
  > .slogan {
    color: $grey;
    font-size: 20px;
    font-weight: 700;
    text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.5);
    margin-bottom: 35px;
  }
}
@media screen and (max-width: 768px) {
  .large-logo-root {
    > .logo {
      font-size: 80px;
    }
    > .slogan {
      font-size: 16px;
    }
  }
}
</style>
