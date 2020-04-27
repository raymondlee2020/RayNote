<template>
  <div class="sign-up-root">
    <LargeLogo />
    <el-form label-position="left" label-width="80px" :model="signUpForm">
      <el-form-item label="Name">
        <el-input v-model="signUpForm.name" placeholder="Please enter your name"></el-input>
      </el-form-item>
      <el-form-item label="Account">
        <el-input v-model="signUpForm.account" placeholder="Set your account"></el-input>
      </el-form-item>
      <el-form-item label="Password">
        <el-input v-model="signUpForm.password" placeholder="Set your password" type="password"></el-input>
      </el-form-item>
      <el-form-item label="Confirm">
        <el-input
          v-model="signUpForm.confirmPassword"
          placeholder="Repeat your password"
          type="password"
        ></el-input>
      </el-form-item>
      <el-form-item>
        <el-button class="send-btn" plain type="primary" :loading="loading" @click="signUp()">Send</el-button>
      </el-form-item>
    </el-form>
    <Footer />
  </div>
</template>

<script>
import BaseUrl from "@/constants";
import { GetData, PostData } from "@/utils";
import { LargeLogo, Footer } from "@/components";
export default {
  name: "SignUp",
  components: {
    LargeLogo,
    Footer
  },
  data() {
    return {
      signUpForm: {
        name: "",
        account: "",
        password: "",
        confirmPassword: ""
      },
      loading: false
    };
  },
  methods: {
    signUp: async function() {
      const data = {
        name: this.signUpForm.name,
        account: this.signUpForm.account,
        password: this.signUpForm.password
      };
      const result = await PostData(`${BaseUrl}/api/User`, data);
      console.log(result);
      this.$router.push("Login");
    }
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.sign-up-root {
  @extend %flex-center;
  position: relative;
  height: 100vh;
  flex-direction: column;
  .send-btn {
    margin-top: 10px;
    margin-right: 80px;
  }
}
</style>
