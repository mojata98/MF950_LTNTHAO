<template>
  <div>
    <div class="content">
      <div class="content-title">
        <div class="content-title-text">Danh sách nhân viên</div>

        <div class="button button-new btnDel" id="btnDel">
          <!-- <div class="button-icon"></div> -->
          <div class="button-value" @click="btnDeleteAll()">Xóa nhân viên</div>
        </div>

        <div class="button-new" id="btnAdd">
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
          style="margin-left: 16px; width: 200px"
          nameDropdown="filter-department"
          dropdownType="dropdown-department"
          myUrl="api/Department"
          dropdownValue="drdValueDepartment"
          defaultName="Tất cả phòng ban"
          itemId="DepartmentId"
          itemName="DepartmentName"
        />

        <BaseDropdown
          style="margin-left: 16px; width: 200px"
          nameDropdown="filter-position"
          dropdownType="dropdown-position"
          myUrl="v1/Positions"
          dropdownValue="drdValuePosition"
          defaultName="Tất cả vị trí"
          itemId="PositionId"
          itemName="PositionName"
        />

        <div class="refresh" id="btnRefresh">
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
                style="text-align: center; width: 50px"
                scope="col"
                fieldName="Checkbox"
                textAlignType="Center"
              >
                <input type="checkbox" class="checkbox" />
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="EmployeeCode"
                textAlignType="Left"
              >
                Mã nhân viên
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="FullName"
                textAlignType="Left"
              >
                Họ và tên
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="GenderName"
                textAlignType="Left"
              >
                Giới tính
              </th>
              <th
                style="min-width: 50px"
                scope="col"
                class="text-align-center"
                fieldName="DateOfBirth"
                textAlignType="Center"
                formatType="ddmmyyyy"
              >
                Ngày sinh
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="PhoneNumber"
                textAlignType="Left"
              >
                Điện thoại
              </th>
              <th
                style="min-width: 100px; max-width: 150px"
                scope="col"
                fieldName="Email"
                textAlignType="Left"
              >
                Email
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="PositionName"
                textAlignType="Left"
              >
                Chức vụ
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="DepartmentName"
                textAlignType="Left"
              >
                Phòng ban
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                class="text-align-right"
                fieldName="Salary"
                textAlignType="Right"
                formatType="Money"
              >
                Mức lương cơ bản
              </th>
              <th
                style="min-width: 100px"
                scope="col"
                fieldName="WorkStatus"
                textAlignType="Left"
              >
                Tình trạng công việc
              </th>
              <th
                style="min-width: 100px"
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
              <td style="min-width: 100px">{{ employee.EmployeeCode }}</td>
              <td style="min-width: 100px; max-width: 150px">
                {{ employee.FullName }}
              </td>
              <td style="min-width: 50px">{{ employee.GenderName }}</td>
              <td style="min-width: 50px; text-align: center">
                {{ employee.DateOfBirth | myDate }}
              </td>
              <td style="min-width: 100px">{{ employee.PhoneNumber }}</td>
              <td
                style="min-width: 100px; max-width: 150px"
                :title="employee.Email"
              >
                {{ employee.Email }}
              </td>
              <td style="min-width: 100px">{{ employee.PositionName }}</td>
              <td style="min-width: 100px">{{ employee.DepartmentName }}</td>
              <td style="min-width: 100px; text-align: right">
                {{ formatAutoMoney(employee.Salary) }}
              </td>
              <td style="min-width: 100px">
                {{ formatWorkStatus(employee.WorkStatus) }}
              </td>
              <td style="text-align: center; min-width: 50px; max-width: 100px">
                <div
                  class="button btnDel"
                  @click="btnDelete(employee.EmployeeId)"
                >
                  Xóa
                </div>
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
      v-bind:employeeCode="employeeCode"
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
    BaseDropdown,
  },

  data() {
    return {
      employees: [],
      // header: [],
      employeeId: "",
      employeeCode: "",
      isHide: true,
      modeFormDetail: 0,
      isChecked: [],
    };
  },

  /**------------------------------
   * Sinh dữ liệu cho bảng từ API
   * Author: LNTHAO (29/07/2021)
   */
  created() {
    this.loadData();
  },

  methods: {
    /**
     * Load dữ liệu cho bảng
     * CreatedBy: LNTHAO (4/8)
     */
    loadData() {
      var vm = this;
      axios
        .get("http://cukcuk.manhnv.net/v1/Employees")
        .then((res) => {
          vm.employees = res.data;
          alert("Load data thành công");
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
      let vm = this;
      axios // chuyển sang bên hàm con ||
        .get("http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode")
        .then((res) => {
          vm.employeeCode = res.data;
          alert(vm.employeeCode);
          this.isHide = false;
          this.modeFormDetail = 0;
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Xem thông tin nhân viên khi nhấn đúp chuột
     * CreatedBy: LNTHAO (29/07)
     */
    fixInfor(emplId) {
      this.modeFormDetail = 1;
      this.isHide = false;
      this.employeeId = emplId;
    },
    /**
     * Nhấn nút xóa để xóa 1 nhân viên
     * CreatedBy: LNTHAO (05/08)
     */
    btnDelete(emplId) {
      var id = emplId;
      let vm = this;
      axios
        .delete("http://cukcuk.manhnv.net/v1/Employees/" + id)
        .then((res) => {
          alert("Xóa dữ liệu thành công.");
          console.log(res);
          vm.loadData();
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /** TODO----------------------------------
     * Xóa nhân viên khi chọn check box - Đang làm
     * CreatedBy: LNTHAO (05/08)
     */
    btnDeleteAll() {
      alert("Bạn chắc chắn muốn xóa nhân viên?");
    },
    /**
     *Hàm format lương hiển thị dạng 1.000.000
     *CreateBy LNTHAO (6/8/2021)
     */
    formatAutoMoney(myinput) {
      myinput += "";
      if (myinput != null) {
        myinput.replaceAll(".", "");
        let onlynumber = "";
        for (let i = 0; i < myinput.length; i++) {
          if (!isNaN(parseInt(myinput[i], 10))) {
            onlynumber += myinput[i];
          }
        }
        return Number(onlynumber).toLocaleString("vi");
      }
      return 0;
    },
    /**
     * Format trạng thái hoạt động
     * CreatedBy: LNTHAO (06/08)
     */
    formatWorkStatus(value) {
      switch (value) {
        case 0:
          return "Đang thử việc";
        case 1:
          return "Đang làm việc";
        case 3:
          return "Đang nghỉ phép";
        default:
          return "Đã nghỉ việc";
      }
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