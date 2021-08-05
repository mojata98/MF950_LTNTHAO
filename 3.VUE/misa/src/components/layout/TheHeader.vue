<template>
  <div class="header">
    <div class="header-left">
      <div class="toggle"></div>
      <div class="logo"></div>
    </div>
    <div class="header-right">
      <div class="header-title">
        <BaseDropdown
          id="store"
          nameDropdown="filter-store"
          dropdownType="store"
          itemId="StoreId"
          itemName="StoreName"
          dropdownValue="txtStore"
          :selectedId="0+ ''"
        />
      </div>
      <div class="header-info">
        <div class="announce">
          <i class="far fa-bell"></i>
        </div>
        <div class="avatar"></div>
        <div class="info-name">Mai Anh Bảo</div>
        <div class="option"></div>
      </div>
    </div>
  </div>
</template>

<script>
import BaseDropdown from "../base/BaseDropdown.vue";
export default {
  name: "TheHeader",
  components: {
    BaseDropdown,
  },
};
</script>

<style scoped>
@import "../../css/layout/header.css";
</style>