<template>
  <div class="detail-note-root">
    <SmallLogo />
    <GreetBar />
    <div class="note">
      <el-card class="card">
        <div slot="header" class="clearfix">
          <span class="note-title">Card name</span>
          <el-button style="float: right; padding: 3px 0" type="text" icon="el-icon-delete" />
          <el-button
            style="float: right; padding: 3px 0; margin-right: 10px;"
            type="text"
            icon="el-icon-edit"
          />
        </div>
      </el-card>
      <div class="time">Last Modified Time: 2020/04/27</div>
    </div>
  </div>
</template>

<script>
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "DetailNote",
  components: {
    SmallLogo,
    GreetBar
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
