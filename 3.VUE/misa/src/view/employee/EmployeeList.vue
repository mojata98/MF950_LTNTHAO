<template>
  <div>
    <div class="content">
      <div class="content-title">
        <div class="content-title-text">Danh sách nhân viên</div>
        <div class="button-new" id="btnAdd">
          <!--onclick="btnAddOnClick();"-->
          <div class="button-icon"></div>
          <div class="button-value" @click="btnAddOnClick()">
            Thêm nhân viên
          </div>
        </div>
      </div>

      <div class="filter">
        <div class="filter-search">
          <input
            type="text"
            placeholder="Tìm kiếm theo Mã, Tên, SĐT"
            onfocus="this.placeholder = ''"
            style="width: 200px"
            class="icon-search input-search"
            tabindex="1"
            name="inputSearch"
            id="txtSearch"
          />
          <button class="btn-reset" style="display: none">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
              class="feather feather-x"
            >
              <line x1="18" y1="6" x2="6" y2="18"></line>
              <line x1="6" y1="6" x2="18" y2="18"></line>
            </svg>
          </button>
        </div>
        
        <BaseDropdown
          id="main-department"
          style="margin-left: 16px; width: 200px;"
          nameDropdown="filter-department"
          dropdownType="dropdown-department"
          myUrl="api/Department"
          dropdownValue="drdValueDepartment"
          defaultName="Tất cả phòng ban"
          itemId="DepartmentId"
          itemName="DepartmentName"
        />
        
        <BaseDropdown
          style="margin-left: 16px; width: 200px;"
          nameDropdown="filter-position"
          dropdownType="dropdown-position"
          myUrl="v1/Positions"
          dropdownValue="drdValuePosition"
          defaultName="Tất cả vị trí"
          itemId="PositionId"
          itemName="PositionName"
        />

        <div class="refresh" id="btnRefresh">
          <!--onclick="btnRefresh()"-->
          <div class="button-refresh" @click="loadData"></div>
        </div>
      </div>

      <div class="content-table">
        <table
          class="table table-striped"
          style="width: 100%"
          id="tbListDataEmployee"
        >
          <thead>
            <tr>
              <th
                style="text-align: center"
                scope="col"
                fieldName="Checkbox"
                textAlignType="Center"
              >
                <input type="checkbox" class="checkbox" />
              </th>
              <th
                style=""
                scope="col"
                fieldName="EmployeeCode"
                textAlignType="Left"
              >
                Mã nhân viên
              </th>
              <th
                style=""
                scope="col"
                fieldName="FullName"
                textAlignType="Left"
              >
                Họ và tên
              </th>
              <th
                style=""
                scope="col"
                fieldName="GenderName"
                textAlignType="Left"
              >
                Giới tính
              </th>
              <th
                style=""
                scope="col"
                class="text-align-center"
                fieldName="DateOfBirth"
                textAlignType="Center"
                formatType="ddmmyyyy"
              >
                Ngày sinh
              </th>
              <th
                style=""
                scope="col"
                fieldName="PhoneNumber"
                textAlignType="Left"
              >
                Điện thoại
              </th>
              <th scope="col" fieldName="Email" textAlignType="Left">
                <span style="width: 100px">Email</span>
              </th>
              <th
                style=""
                scope="col"
                fieldName="PositionName"
                textAlignType="Left"
              >
                Chức vụ
              </th>
              <th
                style=""
                scope="col"
                fieldName="DepartmentName"
                textAlignType="Left"
              >
                Phòng ban
              </th>
              <th
                style=""
                scope="col"
                class="text-align-right"
                fieldName="Salary"
                textAlignType="Right"
                formatType="Money"
              >
                Mức lương cơ bản
              </th>
              <th
                style=""
                scope="col"
                fieldName="WorkStatus"
                textAlignType="Left"
              >
                Tình trạng công việc
              </th>
              <th
                style=""
                scope="col"
                fieldName="Action"
                textAlignType="Center"
              ></th>
            </tr>
          </thead>
          <tbody id="tbody">
            <tr
              v-for="employee in employees"
              :key="employee.EmployeeId"
              v-on:dblclick="fixInfor(employee.EmployeeId)"
            >
              <td style="text-align: center">
                <input type="checkbox" class="checkbox" />
              </td>
              <td style="">{{ employee.EmployeeCode }}</td>
              <td style="">{{ employee.FullName }}</td>
              <td style="">{{ employee.GenderName }}</td>
              <td style="max-width: 100px; text-align: center">
                {{ employee.DateOfBirth }}
              </td>
              <td style="">{{ employee.PhoneNumber }}</td>
              <td style="max-width: 150px">{{ employee.Email }}</td>
              <td style="">{{ employee.PositionName }}</td>
              <td style="">{{ employee.DepartmentName }}</td>
              <td style="text-align: right">{{ employee.Salary }}</td>
              <td style="">{{ employee.WorkStatus }}</td>
              <td style="text-align: center">
                <div class="button btnDel">Xóa</div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <!-------------------------------------------------------FOOTER-------------------------------------------------------->
      <div class="footer">
        <div class="footer-left">
          Hiển thị <b id="employeeTotal">1-10/1000</b> nhân viên
        </div>
        <div class="pagination">
          <div class="footer-middle">
            <a href="# " class="pagination-firstpage"></a>
            <a href="# " class="pagination-prevpage"></a>
            <a href="# " class="page-number">1</a>
            <a class="active page-number" href="# ">2</a>
            <a href="# " class="page-number">3</a>
            <a href="# " class="page-number">4</a>
            <a href="# " class="pagination-nextpage"></a>
            <a href="# " class="pagination-lastpage"></a>
          </div>
        </div>
        <div class="footer-right">10 nhân viên/trang</div>
      </div>
    </div>
    <EmployeeDetail
      v-bind:isHide="isHide"
      @isHideUpdated="isHide = $event"
      v-bind:employeeId="employeeId"
      v-bind:mode="modeFormDetail"
      @loadData="loadData"
    />

    <BasePopup v-bind:isHide="isHide" @isHideUpdated="isHide = $event" />
  </div>
</template>

<script>
import axios from "axios";
import EmployeeDetail from "../employee/EmployeeDetail.vue";
import BasePopup from "../../components/base/BasePopup.vue";
import BaseDropdown from "../../components/base/BaseDropdown.vue";

export default {
  name: "EmployeePage",
  components: { 
    EmployeeDetail,
    BasePopup,
    BaseDropdown, },

  data() {
    return {
      employees: [],
      // header: [],
      employeeId: "",
      isHide: true,
      modeFormDetail: 0,
    };
  },

  /**------------------------------
   * Sinh dữ liệu cho bảng từ API
   * Author: LNTHAO (29/07/2021)
   */
  mounted() {
    var vm = this;
    // Gọi API lấy dữ liệu
    axios
      .get("http://cukcuk.manhnv.net/v1/Employees")
      .then((res) => {
        // console.log(res);
        vm.employees = res.data;
      })
      .catch((res) => {
        console.log(res);
      });
  },

  methods: {
    /**
     * Load dữ liệu cho bảng
     * CreatedBy: LNTHAO (4/8)
     */
    loadData(){
      axios
        .get("http://cukcuk.manhnv.net/v1/Employees")
        .then((res) => {
          this.employees = res.data;
          // this.isChecked = new Array(this.employees.length).fill(false);
          console.log("ok");
          alert("Load dữ liệu thành công.")
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Ẩn hiện form thêm nhân viên
     * CreatedBy: LNTHAO (29/07/2021)
     */
    btnAddOnClick() {
      this.isHide = false;
      this.modeFormDetail = 0;
    },
    /**
     * Xem và sửa thông tin nhân viên
     * CreatedBy: LNTHAO (29/07)
     */
    fixInfor(emplId) {
      this.modeFormDetail = 1;
      this.isHide = false;
      this.employeeId = emplId;
    },
    
  },
};
</script>

<style scoped>
@import "../../css/layout/modal-form.css";

.checkbox {
  height: 16px;
  width: 16px;
}

.checkbox:hover {
  cursor: pointer;
}
</style>