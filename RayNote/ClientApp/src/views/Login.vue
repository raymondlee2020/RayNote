<template>
  <div class="login-root">
    <div class="logo">RayNote</div>
    <div class="slogan">Record Anything In Your Life</div>
    <el-form label-position="left" label-width="80px" :model="loginForm">
      <el-form-item label="Account" style="color: #fff;">
        <el-input v-model="loginForm.account"></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input v-model="loginForm.password"></el-input>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
export default {
  name: "Login",
  components: {},
  data() {
    return {
      loginForm: {}
    };
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
.login-root {
  height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: -30px;
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
  label {
    color: #fff;
    font-size: 20px;
  }
}
@media screen and (max-width: 768px) {
  .login-root {
    > .logo {
      font-size: 80px;
    }
    > .slogan {
      font-size: 16px;
    }
  }
}
</style>
