<template>
  <div class="greet-bar-root">
    <div class="greet">{{greet}}</div>
    <div class="name">{{name}}</div>
  </div>
</template>

<script>
export default {
  name: "GreetBar",
  components: {},
  props: {},
  data() {
    return {
      name: this.$store.state.name,
      greet: ""
    };
  },
  mounted() {
    const now = new Date();
    const hour = now.getHours();
    if (hour >= 5 && hour < 12) {
      this.greet = "Good Morning, ";
    } else if (hour >= 12 && hour < 16) {
      this.greet = "Good Afternoon, ";
    } else if (hour >= 16 && hour < 20) {
      this.greet = "Good Evening, ";
    } else {
      this.greet = "Good Night, ";
    }
  }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.greet-bar-root {
  @extend %flex-center;
  margin: 20px 0 30px;
  > .greet {
    color: #fff;
    font-size: 50px;
    font-weight: 700;
    text-shadow: 3px 3px 5px rgba(0, 0, 0, 0.5);
    white-space: pre;
  }
  > .name {
    color: #fff;
    font-size: 50px;
    font-weight: 700;
    text-shadow: 3px 3px 5px rgba(0, 0, 0, 0.5);
  }
}
@media screen and (max-width: 768px) {
  .greet-bar-root {
    flex-direction: column;
    > .greet {
      font-size: 35px;
    }
    > .name {
      font-size: 35px;
    }
  }
}
</style>
