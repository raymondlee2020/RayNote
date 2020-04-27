<template>
  <div class="login-root">
    <LargeLogo />
    <el-form label-position="left" label-width="80px" :model="loginForm">
      <el-form-item label="Account">
        <el-input v-model="loginForm.account"></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input v-model="loginForm.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button plain type="primary" :loading="loading" @click="login">Login</el-button>
        <router-link class="link" to="/SignUp">
          <el-link>Sign up</el-link>
        </router-link>
      </el-form-item>
    </el-form>
    <Footer />
  </div>
</template>

<script>
import { LargeLogo, Footer } from "@/components";
export default {
  name: "Login",
  components: {
    LargeLogo,
    Footer
  },
  data() {
    return {
      loginForm: {},
      loading: false
    };
  },
  methods: {
    login() {}
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.login-root {
  @extend %flex-center;
  position: relative;
  height: 100vh;
  flex-direction: column;
  padding-bottom: 35px;
  box-sizing: border-box;
  .link {
    text-decoration: none;
    margin-left: 20px;
  }
}
</style>
