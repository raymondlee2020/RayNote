<template>
  <div class="small-logo-root">
    <div class="logo">RayNote</div>
    <div class="slogan">Record Anything In Your Life</div>
  </div>
</template>

<script>
export default {
  name: "SmallLogo",
  components: {}
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.small-logo-root {
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  > .logo {
    color: #fff;
    font-size: 40px;
    font-weight: 700;
    text-shadow: 3px 3px 5px rgba(0, 0, 0, 0.5);
    margin-bottom: 8px;
    margin: 5px;
  }
  > .slogan {
    color: $grey;
    font-size: 10px;
    font-weight: 700;
    text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.5);
    margin-bottom: 35px;
    margin-left: 8px;
  }
}
@media screen and (max-width: 768px) {
  .small-logo-root {
    > .logo {
      font-size: 30px;
      // margin: 5px;
    }
    > .slogan {
      display: none;
    }
  }
}
</style>
