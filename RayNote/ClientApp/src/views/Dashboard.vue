<template>
  <div class="dashboard-root">
    <SmallLogo />
    <GreetBar />
    <div class="title">
      <div>Notes</div>
      <i class="el-icon-plus" style="cursor: pointer;" @click="addNote()"></i>
    </div>
    <el-row :gutter="20" class="notes">
      <el-col :xs="24" :sm="12" :md="12" :lg="8" :xl="8" v-for="note in notes" :key="note.id">
        <el-card class="note">
          <div slot="header" class="clearfix">
            <span class="note-title">{{note.title}}</span>
            <el-button
              style="float: right; padding: 3px 0"
              type="text"
              icon="el-icon-delete"
              @click="deleteNote(note.id)"
            />
            <el-button
              style="float: right; padding: 3px 0; margin-right: 10px;"
              type="text"
              icon="el-icon-edit"
              @click="updateNote(note.id)"
            />
          </div>
          <div @click="detail(note.id)">{{note.content}}</div>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import BaseUrl from "@/constants";
import { GetData, PostData, DeleteData } from "@/utils";
import { SmallLogo, GreetBar } from "@/components";
export default {
  name: "Dashboard",
  components: {
    SmallLogo,
    GreetBar
  },
  data() {
    return {
      notes: []
    };
  },
  methods: {
    detail(id) {
      this.$router.push(`DetailNote?id=${id}`);
    },
    addNote() {
      this.$router.push("CreateNote");
    },
    updateNote: function(id) {
      this.$router.push(`UpdateNote?id=${id}`);
    },
    deleteNote: async function(id) {
      const result = await DeleteData(`${BaseUrl}/api/note/${id}`);
      console.log(result);
      const notes = await GetData(
        `${BaseUrl}/api/note/owner/${this.$store.state.id}`, this.$store.state.token
      );
      this.notes = notes;
    }
  },
  mounted: async function() {
    const notes = await GetData(
      `${BaseUrl}/api/note/owner/${this.$store.state.id}`, this.$store.state.token
    );
    this.notes = notes;
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
    justify-content: space-between;
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
    height: 250px;
    margin-bottom: 20px;
    cursor: pointer;
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
}
</style>
