<template>
  <div class="login-root">
    <LargeLogo />
    <el-form label-position="left" label-width="80px" :model="loginForm">
      <el-form-item label="Account">
        <el-input
          v-model="loginForm.account"
          placeholder="Please enter your account"
          @keyup.enter.native="login"
        ></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input
          v-model="loginForm.password"
          placeholder="Please enter your password"
          @keyup.enter.native="login"
          type="password"
        ></el-input>
      </el-form-item>
      <el-form-item>
        <el-button plain type="primary" :loading="loading" @click="login">Login</el-button>
        <span class="link" @click="signUp()">
          <el-link>Sign up</el-link>
        </span>
      </el-form-item>
    </el-form>
    <Footer />
  </div>
</template>

<script>
import md5 from 'md5'
import BaseUrl from "@/constants";
import { GetData, PostData } from "@/utils";
import { LargeLogo, Footer } from "@/components";
export default {
  name: "Login",
  components: {
    LargeLogo,
    Footer
  },
  data() {
    return {
      loginForm: {
        account: "",
        password: ""
      },
      loading: false
    };
  },
  methods: {
    login: async function() {
      const data = {
        account: this.loginForm.account,
        password: md5(this.loginForm.password)
      };
      const result = await PostData(`${BaseUrl}/api/user/login`, data);
      console.log(result);
      this.$store.commit("setLogin", result);
      this.$router.push("Dashboard");
    },
    signUp: function() {
      this.$router.push("SignUp");
    }
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
