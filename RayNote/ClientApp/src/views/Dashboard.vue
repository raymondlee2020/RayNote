<template>
  <div class="dashboard-root">
    <SmallLogo />
    <GreetBar />
    <div class="title">Notes</div>
    <el-row :gutter="20" class="notes">
      <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="8">
        <el-card class="note">
          <div slot="header" class="clearfix">
            <span class="note-title">Card name</span>
            <el-button style="float: right; padding: 3px 0" type="text" icon="el-icon-delete"/>
            <el-button style="float: right; padding: 3px 0; margin-right: 10px;" type="text" icon="el-icon-edit"/>
          </div>
        </el-card>
      </el-col>
      <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="8">
        <el-card class="note">
          <div slot="header" class="clearfix">
            <span class="note-title">Card name</span>
            <el-button style="float: right; padding: 3px 0" type="text" icon="el-icon-delete"/>
            <el-button style="float: right; padding: 3px 0; margin-right: 10px;" type="text" icon="el-icon-edit"/>
          </div>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "Dashboard",
  components: {
    SmallLogo,
    GreetBar
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.dashboard-root {
  @extend %flex-1020;
  > .title {
    width: 100%;
    display: flex;
    justify-content: flex-start;
    color: $grey;
    font-size: 30px;
    font-weight: 700;
    text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.5);
    white-space: pre;
    padding-left: 12px;
    margin-bottom: 20px;
  }
  > .notes {
    width: 100%;
  }
  .note {
    width: 100%;
    height: 250px ;
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
  .note-title{
    float: left;
  }
}
</style>
