<template>
  <div class="dashboard-root">
    <SmallLogo />
    <GreetBar />
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
}
</style>
