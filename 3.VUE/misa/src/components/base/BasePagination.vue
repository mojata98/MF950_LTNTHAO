<template>
  <div>
    <div class="footer">
      <div class="footer-left">
        Hiển thị
        <b id="employeeTotal"
          >{{ this.start }}-{{ this.end }}/{{ this.amount }}</b
        >
        nhân viên
      </div>
      <div class="pagination">
        <div class="footer-middle"
        style="width: 300px; align-items: center;">
          <a 
          href="# " 
          class="pagination-firstpage"
          @click="clickNumberPage(1)"
          ></a>
          <a 
          href="# " 
          class="pagination-prevpage"
          @click="clickNumberPage(indexCurrent - 1 < 1 ? 1 : indexCurrent - 1)"
          ></a>
          <!-- <a href="# " class="page-number">1</a>
          <a class="active page-number" href="# ">2</a>
          <a href="# " class="page-number">3</a>
          <a href="# " class="page-number">4</a> -->
          <div class="number-page">
            <a
          class="page-number"
          v-for="index in numPages"
          :key="index"
          :class="index == indexCurrent ? 'active' : ''"
          @click="clickNumberPage(index)"
            >
          <div class="page-numbers"
          style="border: none; cursor: pointer;">{{index}}</div>
        </a>
      </div>
          <a 
          href="# " 
          class="pagination-nextpage"
          @click="clickNumberPage(indexCurrent + 1 > numPages ? numPages : indexCurrent + 1)"
          ></a>
          <a 
          href="# " 
          class="pagination-lastpage"
          @click="clickNumberPage(numPages)"
          ></a>
        </div>
      </div>
      <div class="footer-right"><b>{{ this.pageSize }}</b> nhân viên/trang</div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Pagination",
  data() {
    return {
      start: 0,
      end: 0,
      numPages: 0,
      indexCurrent: 0,
      amount: 0,
    };
  },
  props: ["pageIndex", "pageSize"],
  async created() {
    await this.loadData();
    this.paging();
  },
  methods: {
    /**---------------------------------------------------
     * Lấy toàn bộ danh sách
     * CreatedBy: LNT (20/08/2021)
     */
    async loadData() {
      var self = this;
      // binding data
      await axios
        .get("https://localhost:44338/api/v1/Employees") //LINK LẠI https://localhost:44344/api/v1/Employees
        .then((res) => {
          self.amount = res.data.length;
        })
        .catch((res) => {
          console.log(res);
        });
    },

    /**----------------------------------------------------------
     * Chuyển trang
     * CreatedBy: LNT (20/08/2021)
     */
    clickNumberPage(index)
    {
      this.indexCurrent = index;
      if(this.indexCurrent < this.numPages)
      {
        this.start = (this.indexCurrent -1)*this.pageSize +1;
        this.end = this.start + this.pageSize -1;
      }
      else
      {
        this.start = (this.indexCurrent -1)*this.pageSize +1;
        this.end = this.amount;
      }
      this.$emit("paging",this.indexCurrent);
    },

    /**-------------------------------------------------------------------
     * Phân trang
     * CreatedBy: LNT (20/08/2021)
     */
    paging()
    {
      if(this.amount % this.pageSize == 0)
      {
        this.numPages = this.amount / this.pageSize;
      }
      else
      {
        this.numPages = Math.floor(this.amount / this.pageSize) + 1;
      }
      this.indexCurrent = this.pageIndex;
      this.start = this.indexCurrent;
      this.end = this.pageSize;
    },

    /**------------------------------------------------
     * Khi click nút reload thì reset lại paging
     * CreatedBy: LNT (20/08/2021)
     */
    resetPaging()
    {
      this.indexCurrent = 1;
      this.start = this.indexCurrent;
      this.end = this.pageSize;
    },

    /**----------------------------------------------------------
     * Hiển thị nhiều trang
     * CreatedBy: LNT (20/08/2021)
     */
    // displayPaging()
    // {
    //   var total = this.numPages;
    //   var current = this.indexCurrent;
    //   if(current <= 3)
    //   {
    //     return [1,2,3];
    //   }
    //   else if(current > 3 && current < total - 1)
    //   {

    //   }
    // }
  },
};
</script>

<style scoped>
/* Chưa tạo css cho footer */
</style>