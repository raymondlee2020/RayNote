<template>
  <div class="sign-up-root">
    <LargeLogo />
    <el-form
      label-position="left"
      label-width="80px"
      :model="signUpForm"
      ref="signUpForm"
      :rules="rules"
    >
      <el-form-item label="Name">
        <el-input v-model="signUpForm.name" placeholder="Please enter your name"></el-input>
      </el-form-item>
      <el-form-item label="Account">
        <el-input v-model="signUpForm.account" placeholder="Set your account"></el-input>
      </el-form-item>
      <el-form-item label="Password" prop="pass">
        <el-input v-model="signUpForm.password" placeholder="Set your password" type="password"></el-input>
      </el-form-item>
      <el-form-item label="Confirm" prop="checkPass">
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
import md5 from "md5";
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
    const validatePass = (rule, value, callback) => {
      if (this.signUpForm.password !== this.signUpForm.confirmPassword) {
        callback(new Error("Two passwords don't match!"));
      } else {
        callback();
      }
    };
    return {
      rules: {
        checkPass: [{ validator: validatePass, trigger: "blur" }]
      },
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
      this.$refs["signUpForm"].validate(async valid => {
        if (valid) {
          const data = {
            name: this.signUpForm.name,
            account: this.signUpForm.account,
            password: md5(this.signUpForm.password)
          };
          const result = await PostData(`${BaseUrl}/api/User`, data);
          this.$router.push("Login");
        } else {
          this.$message.error("Input Error");
        }
      });
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
