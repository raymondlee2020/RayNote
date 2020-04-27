<template>
  <div class="detail-note-root">
    <SmallLogo />
    <GreetBar />
    <div class="note">
      <el-card class="card">
        <div slot="header" class="clearfix">
          <span class="note-title">{{title}}</span>
          <el-button style="float: right; padding: 3px 0" type="text" icon="el-icon-delete" @click="deleteNote()" />
          <el-button
            style="float: right; padding: 3px 0; margin-right: 10px;"
            type="text"
            icon="el-icon-edit"
            @click="updateNote()"
          />
        </div>
        <div>{{content}}</div>
      </el-card>
      <div class="time">{{time}}</div>
    </div>
  </div>
</template>

<script>
import BaseUrl from "@/constants";
import { GetData, PostData, DeleteData, DateFormat } from "@/utils";
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "DetailNote",
  components: {
    SmallLogo,
    GreetBar
  },
  data() {
    return {
      title: "",
      content: "",
      time: ""
    };
  },
  mounted: async function() {
    const result = await GetData(`${BaseUrl}/api/note/${this.$route.query.id}`);
    this.title = result.title;
    this.content = result.content;
    const timestamp = new Date(result.timestamp);
    this.time = timestamp.format("yyyy/MM/dd hh:mm:ss")
  },
  methods: {
    updateNote: function() {
      this.$router.push(`UpdateNote?id=${this.$route.query.id}`);
    },
    deleteNote: async function() {
      const result = await DeleteData(
        `${BaseUrl}/api/note/${this.$route.query.id}`
      );
      console.log(result);
      this.$router.push("Dashboard");
    }
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.detail-note-root {
  @extend %flex-1020;
  > .note {
    width: 100%;
    max-width: 700px;
    display: flex;
    flex: 1;
    flex-direction: column;
    align-items: center;
    margin-top: 40px;
    .card {
      width: 90%;
      height: 250px;
      margin-bottom: 20px;
    }
    .clearfix:before,
    .clearfix:after {
      display: table;
      content: "";
    }
    .clearfix:after {
      clear: both;
    }
    .note-title {
      float: left;
    }
    .time {
      color: $grey;
      font-size: 16px;
      font-weight: 700;
      white-space: pre;
    }
  }
}
</style>
