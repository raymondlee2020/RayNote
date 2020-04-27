<template>
  <div class="update-info-root">
    <SmallLogo :showEdit="false" />
    <GreetBar />
    <div class="profile">
      <div class="data-set" v-if="!editMode">
        <div class="tag">Name</div>
        <div class="value">Raymond</div>
        <div class="tag">Account</div>
        <div class="value">MockAccount</div>
        <div class="tag">Password</div>
        <div class="value">********</div>
        <el-button class="edit" type="primary" @click="edit()">
          Reset Password
          <i class="el-icon-edit"></i>
        </el-button>
      </div>
      <el-form
        class="passwordForm"
        label-position="left"
        label-width="80px"
        :model="passwordForm"
        v-if="editMode"
      >
        <el-form-item label="Verify">
          <el-input v-model="passwordForm.account" placeholder="Please enter your origin password"></el-input>
        </el-form-item>
        <el-form-item label="Password">
          <el-input v-model="passwordForm.password" placeholder="Please set your new password"></el-input>
        </el-form-item>
        <el-form-item label="Confirm">
          <el-input
            v-model="passwordForm.confirmPassword"
            placeholder="Please repeat your new password"
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-button class="send-btn" type="primary" :loading="loading" @click="send()">Login</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "UpdateInfo",
  components: {
    SmallLogo,
    GreetBar
  },
  data() {
    return {
      editMode: false,
      passwordForm: {}
    };
  },
  methods: {
    edit() {
      this.editMode = true;
    },
    send() {}
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.update-info-root {
  @extend %flex-1020;
  height: 100vh;
  > .profile {
    width: 100%;
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    max-width: 400px;
    margin: auto 0;
    padding-left: 8px;
    > .data-set {
      width: 100%;
      display: flex;
      flex: 1;
      flex-direction: column;
      align-items: center;
      margin-top: 80px;
      .tag {
        color: #fff;
        font-size: 25px;
        font-weight: 700;
        text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.5);
        margin-bottom: 20px;
      }
      .value {
        color: $grey;
        font-size: 20px;
        font-weight: 700;
        text-shadow: 1px 1px 0px rgba(0, 0, 0, 0.5);
        margin-bottom: 30px;
      }
    }
    > .passwordForm {
      margin-top: 80px;
      .send-btn {
        margin-right: 40px;
        margin-top: 20px;
      }
    }
  }
}
@media screen and (max-width: 768px) {
  .update-info-root {
    > .profile {
      > .data-set {
        margin-top: 50px;
      }
    }
  }
}
</style>
