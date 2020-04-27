<template>
  <div class="dashboard-root">
    <SmallLogo />
  </div>
</template>

<script>
import { SmallLogo } from "@/components";
export default {
  name: "Dashboard",
  components: { SmallLogo }
};
</script>

<style lang="scss" scoped>
@import "../assets/styles/colors";
@import "../assets/styles/layouts";
.dashboard-root {
  @extend %flex-1020;
}
</style>
