<template>
  <div class="custom-table">
    <table>
      <thead>
        <tr>
          <th
            v-for="(item, index) in headerList"
            :key="index"
            :style="{
              width: item.width,
            }"
            :type="item.type"
          >
            {{ item.text }}
          </th>
        </tr>
      </thead>
      <tbody>
        <!-- sử dụng computed -->
        <!-- <tr v-for="(item, index) in field2" :key="index">
          <td
            v-for="header in headerList"
            :key="header.propName"
            :title="item[header.propName]"
            :style="{
              width: header.width,
            }"
            :type="header.type"
          >
            {{ item[header.propName] ? item[header.propName] : "" }}
          </td>
        </tr> -->
        <tr v-for="(item, index) in fields" :key="index">
          <td
            v-for="header in headerList"
            :key="header.propName"
            :title="item[header.propName]"
            :style="{
              width: header.width,
            }"
            :type="header.type"
          >
            {{ item[header.propName] ? item[header.propName] : "" }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
import { formatDate, formatCurrency } from "../../common";
export default {
  name: "BaseTable",
  props: ["headerList", "fieldList"],
  data() {
    return {
      fields: [],
      headerProps: [],
    };
  },
  created() {},
  mounted() {
    // this.getData0();
  },
  watch: {
    fieldList: function (val) {
      this.getData(val);
    },
  },
  computed: {
    // field2: function () {
    //   let arr = [];
    //   this.fieldList.forEach((field) => {
    //     let tmp = {};
    //     this.headerList.forEach((header) => {
    //       if (header.type == "date") {
    //         tmp[header.propName] = formatDate(
    //           field[header.propName],
    //           "dd/mm/yyyy"
    //         );
    //       } else if (header.type == "currency") {
    //         tmp[header.propName] = formatCurrency(field[header.propName]);
    //       } else {
    //         tmp[header.propName] = field[header.propName];
    //       }
    //     });
    //     arr.push(tmp);
    //   });
    //   return arr;
    // },
  },
  methods: {
    getData0: function () {
      //? Chuyển dữ liệu ver2 + loại bỏ data dư thừa
      //? tạo fiedl dữ liệu với các header tương ứng
      this.fieldList.forEach((field) => {
        let tmp = {};
        this.headerList.forEach((header) => {
          if (header.type == "date") {
            tmp[header.propName] = formatDate(
              field[header.propName],
              "dd/mm/yyyy"
            );
          } else if (header.type == "currency") {
            tmp[header.propName] = formatCurrency(field[header.propName]);
          } else {
            tmp[header.propName] = field[header.propName];
          }
        });
        this.fields.push(tmp);
      });
    },
    getData: function (fieldList) {
      this.fields = [];
      fieldList.forEach((field) => {
        let tmp = {};
        this.headerList.forEach((header) => {
          if (header.type == "date") {
            tmp[header.propName] = formatDate(
              field[header.propName],
              "dd/mm/yyyy"
            );
          } else if (header.type == "currency") {
            tmp[header.propName] = formatCurrency(field[header.propName]);
          } else {
            tmp[header.propName] = field[header.propName];
          }
        });
        this.fields.push(tmp);
      });
    },
  },
};
// dùng computed hứng cái list gửi sang / hoặc là lúc nào bên parent load xong hãng gửi ($ref)
</script>

<style scoped>
@import "../../css/table.css";
</style>