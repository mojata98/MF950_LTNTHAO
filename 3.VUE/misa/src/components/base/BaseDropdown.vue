<template>
  <div :class="[nameDropdown]">
    <label
      :id="id"
      :class="['dropdown', dropdownType]"
      :myurl="myUrl"
      :itemid="itemId"
      :itemname="itemName"
    >
      <div
        class="dropdown-header-wrapper"
        @click="toggleItems"
        :value="currentId"
        :tabindex="tabindex"
      >
        <span class="dropdown-value" :id="dropdownValue">
          {{ currentName }}
        </span>
        <i
          :class="['fas fa-chevron-down icon-down', opened ? 'move-up' : '']"
        ></i>
      </div>
      <ul :class="['dropdown-list', opened ? 'isshow' : 'isnone']">
        <li
          :class="['dropdown-item', item[itemId] == currentId ? 'active' : '']"
          v-for="item in itemlist"
          :key="item[itemId]"
          @click="clickItem(item[itemId], item[itemName])"
        >
          {{ item[itemName] }}
        </li>
      </ul>
    </label>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "BaseDropdown",
  data() {
    return {
      itemlist: [],
      currentId: "-1",
      currentName: "",
      opened: false,
      defaultId: "-1",
    };
  },
  props: {
    id: String,
    nameDropdown: String,
    dropdownType: String,
    propName: String,
    dropdownValue: String,
    myUrl: String,
    itemId: String,
    itemName: String,
    defaultName: String,
    selectedId: String,
    tabindex: String,
  },
  created() {
    this.loadDropdownData();
    this.currentName = this.defaultName;
    this.initChoice();
  },
  watch: {
    selectedId: function () {
      this.initChoice();
    },
  },
  methods: {
    loadDropdownData() {
      switch (this.itemName) {
        case "GenderName":
          this.itemlist = [
            {
              Gender: 0,
              GenderName: "Nữ",
            },
            {
              Gender: 1,
              GenderName: "Nam",
            },
            {
              Gender: 2,
              GenderName: "Không xác định",
            },
          ];
          break;
        case "WorkStatusName":
          this.itemlist = [
            {
              WorkStatus: 0,
              WorkStatusName: "Đang thử việc",
            },
            {
              WorkStatus: 1,
              WorkStatusName: "Đang làm việc",
            },
            {
              WorkStatus: 2,
              WorkStatusName: "Đang nghỉ phép",
            },
            {
              WorkStatus: 3,
              WorkStatusName: "Đã nghỉ việc",
            },
          ];
          break;
        case "StoreName":
          this.itemlist = [
            {
              StoreId: 0,
              StoreName: "Nhà hàng Biển Đông",
            },
            {
              StoreId: 1,
              StoreName: "Nhà hàng Phú Quốc",
            },
            {
              StoreId: 2,
              StoreName: "Nhà hàng Đà Nẵng",
            },
            {
              StoreId: 3,
              StoreName: "Nhà hàng Hà Nội",
            },
          ];
          break;
        default:
          if (this.myUrl) {
            axios
              .get(`http://cukcuk.manhnv.net/${this.myUrl}`)
              .then((res) => {
                this.itemlist = res.data;
              })
              .catch((error) => {
                console.log(error);
              });
          }
          break;
      }
    },
    initChoice() {
      let vm = this;
      if ((vm.selectedId + "").length > 0) {
        vm.itemlist.forEach((item) => {
          if (vm.selectedId == item[vm.itemId]) {
            vm.currentName = item[vm.itemName];
            vm.currentId = item[vm.itemId];
          }
        });
      } else {
        vm.currentId = -1;
        vm.currentName = "";
      }
    },
    clickItem(itemValue, itemName) {
      this.currentId = itemValue;
      this.currentName = itemName;
      this.opened = false;
      this.$emit("input", itemValue);
    },
    toggleItems(){
      this.opened = !this.opened;
    }
  },
};
</script>
<style scoped>
@import "../../css/base/dropdown.css";
@import "../../css/base/icon.css";

.dropdown-list.isshow {
  display: block;
}
.dropdown-list.isnone {
  display: none;
}
#store{
  width: 200px;
  font-size: 15px;
  border: none;
}
</style>

