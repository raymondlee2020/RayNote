<template>
  <div class="small-logo-root">
    <div class="logo-container">
      <div class="logo">RayNote</div>
      <div class="slogan">Record Anything In Your Life</div>
    </div>
    <el-button class="edit" type="primary" v-if="showEdit">
      Edit Profile
      <i class="el-icon-edit"></i>
    </el-button>
  </div>
</template>

<script>
export default {
  name: "SmallLogo",
  components: {},
  props: {
    showEdit: {
      type: Boolean,
      default: true
    }
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.small-logo-root {
  width: 100%;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 35px;
  .logo {
    color: #fff;
    font-size: 40px;
    font-weight: 700;
    text-shadow: 3px 3px 5px rgba(0, 0, 0, 0.5);
    margin-bottom: 8px;
    margin: 5px;
  }
  .slogan {
    color: $grey;
    font-size: 10px;
    font-weight: 700;
    text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.5);
    margin-left: 8px;
  }
  .logo-container {
    @extend %flex-center;
    flex-direction: column;
    align-items: flex-start;
  }
  > .edit {
    float: right;
  }
}
@media screen and (max-width: 768px) {
  .small-logo-root {
    .logo {
      font-size: 30px;
    }
    .slogan {
      text-shadow: 0.1px 0.1px 0.1px rgba(0, 0, 0, 0.5);
    }
    .logo-container {
      align-items: center;
    }
  }
}
</style>
