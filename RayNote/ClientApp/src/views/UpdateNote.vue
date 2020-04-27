<template>
  <div class="update-note-root">
    <SmallLogo />
    <GreetBar />
    <el-form class="note-form" label-position="left" label-width="80px" :model="noteForm">
      <el-form-item label="Title">
        <el-input v-model="noteForm.title" placeholder="Note Title"></el-input>
      </el-form-item>
      <el-form-item label="Content">
        <el-input v-model="noteForm.content" type="textarea" rows="16" placeholder="Note Content"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button
          class="update-btn"
          plain
          type="primary"
          :loading="loading"
          @click="updateNote()"
        >Update</el-button>
        <el-button class="back-btn" plain type="info" @click="back()">Cancel</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import BaseUrl from "@/constants";
import { GetData, PostData, DeleteData, PutData, DateFormat } from "@/utils";
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "UpdateNote",
  components: {
    SmallLogo,
    GreetBar
  },
  data() {
    return {
      noteForm: {
        title: "",
        content: ""
      },
      loading: false
    };
  },
  mounted: async function() {
    const result = await GetData(`${BaseUrl}/api/note/${this.$route.query.id}`);
    this.noteForm.title = result.title;
    this.noteForm.content = result.content;
  },
  methods: {
    updateNote: async function() {
      const newNote = {
        title: this.noteForm.title,
        content: this.noteForm.content,
        timestamp: Date.now(),
        ownerId: this.$store.state.id
      };
      console.log("data", newNote);
      const result = await PutData(`${BaseUrl}/api/note/${this.$route.query.id}`, newNote);
      console.log(result);
      this.$router.push("Dashboard");
    },
    back: function() {
      this.$router.push("Dashboard");
    }
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.update-note-root {
  @extend %flex-1020;
  > .note-form {
    width: 90%;
    max-width: 700px;
    margin-top: 40px;
    .update-btn {
      margin-right: 20px;
    }
  }
}
</style>
