<template>
  <div class="login-root">
    <LargeLogo />
    <el-form label-position="left" label-width="80px" :model="loginForm">
      <el-form-item label="Account" style="color: #fff;">
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
  </div>
</template>

<script>
import { LargeLogo } from "@/components";
export default {
  name: "Login",
  components: { LargeLogo },
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
.login-root {
  height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: -30px;
  .link {
    text-decoration: none;
    margin-left: 20px;
  }
}
</style>
