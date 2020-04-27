<template>
  <div class="create-note-root">
    <SmallLogo />
    <GreetBar />
    <el-form class="note-form" label-position="left" label-width="80px" :model="noteForm">
      <el-form-item label="Title">
        <el-input v-model="noteForm.title" placeholder="Note Title"></el-input>
      </el-form-item>
      <el-form-item label="Content">
        <el-input v-model="noteForm.account" type="textarea" rows="16" placeholder="Note Content"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button
          class="create-btn"
          plain
          type="primary"
          :loading="loading"
          @click="create()"
        >Create</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "CreateNote",
  components: {
    SmallLogo,
    GreetBar
  },
  data() {
    return {
      noteForm: {}
    };
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.create-note-root {
  @extend %flex-1020;
  > .note-form {
    width: 90%;
    max-width: 700px;
    margin-top: 40px;
    .create-btn {
      margin-right: 20px;
    }
  }
}
</style>
