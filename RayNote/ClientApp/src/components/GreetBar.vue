<template>
  <div class="greet-bar-root">
    <div class="greet">{{greet}}</div>
    <div class="name">Raymond</div>
  </div>
</template>

<script>
export default {
  name: "GreetBar",
  components: {},
  props: {
    name: String
  },
  data() {
    return {
      greet: ""
    };
  },
  mounted() {
    const now = new Date();
    const hour = now.getHours();
    console.log(hour);
    if (5 <= hour < 12) {
      this.greet = "Good Morning, ";
    } else if (12 <= hour < 16) {
      this.greet = "Good Afternoon, ";
    } else if (16 <= hour < 20) {
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
  margin-top: 20px;
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
