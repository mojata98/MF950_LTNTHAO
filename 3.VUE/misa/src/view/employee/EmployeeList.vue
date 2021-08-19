<template>
  <div>
    <div class="content">
      <div class="content-title">
        <div class="content-title-text">Danh sách nhân viên</div>

        <div class="button button-new btnDel" id="btnDel"
        :class="{'btn-Del-active': turnOn}">
          <div class="button-icon-delete"></div>
            <div 
              class="button-value" 
              @click="btnDeleteAll()"
              ref="deleteAll"
              
            >Xóa nhân viên</div>
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

      <div>
        <div class="hold-scroll"></div>
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
                style="
                  min-width: 100px;
                  text-align: center;
                  background-color: #fff;
                  z-index: 1;
                "
                scope="col"
                fieldName="Action"
                textAlignType="Center"
              >
                Thao tác
              </th>
            </tr>
          </thead>
          <tbody id="tbody">
            <tr 
            v-for="(employee, index) in employees" 
            :key="employee.EmployeeId"
            v-bind:class="{wasChecked: isChecked[index],}"
            >
              <td style="text-align: center">
                <input type="checkbox" class="checkbox" @click="btnCheckedOnClick(employee.EmployeeId)"/>
              </td>
              
              <td style="min-width: 100px">{{ employee.EmployeeCode }}</td>
              <td style="min-width: 100px; max-width: 150px">
                {{ employee.FullName }}
              </td>
              <td style="min-width: 50px">{{ employee.GenderName }}</td>
              <td style="min-width: 50px; text-align: center">
                {{  employee.DateOfBirth? moment(employee.DateOfBirth).format('DD/MM/YYYY') : ""}}
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
                <div class="hold-button">
                  <div
                    class="icon-edit"
                    title="Xem thông tin"
                    @click="fixInfor(employee.EmployeeId)"
                  ></div>
                  <div
                    class="icon-delete"
                    title="Xóa"
                    @click="btnDelete(employee.EmployeeId)"
                  ></div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <!-------------------------------------------------------FOOTER-------------------------------------------------------->
      <!-- <div class="footer">
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
      </div> -->
      <BasePagination2 
      style="position: absolute; bottom: 0;width: 100%;height: 56px; "
      v-bind:active="pageIndex" v-bind:size="pageSize"/>
    </div>
    <EmployeeDetail
      v-bind:employeeId="employeeId"
      v-bind:employeeCode="employeeCode"
      v-bind:mode="modeFormDetail"
      @loadData="loadData"
    />

    <BasePopup />
  </div>
</template>

<script>
import axios from "axios";
import EmployeeDetail from "../employee/EmployeeDetail.vue";
import BasePopup from "../../components/base/BasePopup.vue";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
import eventBus from '../../js/eventBus';
import BasePagination2 from '../../components/base/BasePagination.vue';
// import $ from 'jquery';
export default {
  name: "EmployeePage",
  components: {
    EmployeeDetail,
    BasePopup,
    BaseDropdown,
    BasePagination2,
  },

  data() {
    return {
      employees: [],
      // header: [],
      employeeId: "",
      employeeCode: "",
      isHideForm: true,
      modeFormDetail: 0,
      isChecked: [],
      employeeClick: null,
      employee: {},
      employeeCheck: [],
      turnOn: false,
      keyword: "",
      positionId: "",
      departmentId: "",
      pageIndex: 1,
      pageSize: 12,
    };
  },

  /**------------------------------
   * Sinh dữ liệu cho bảng từ API
   * Author: LNTHAO (29/07/2021)
   */
  created() {
    this.loadData();
    /**
     * Nhận sự kiện mở Form nhân viên
     * CreatedBy: LNTHAO (10/08)
     */
    eventBus.$on("isHideUpdated", (value) => {
      this.isHideForm = value;
    })
    /**
     * Nhận sự kiện xóa từ Popup
     * CreatedBy: LNTHAO (12/08)
     */
    eventBus.$on("deletePerson", (value) => {
      var id = value;
      let vm = this;
      axios
        .delete("http://cukcuk.manhnv.net/v1/Employees/" + id)
        .then((res) => {
          console.log(res);
          this.$toast.success(
            "Xóa dữ liệu thành công! Vui lòng đợi trong giây lát để hệ thống tải lại dữ liệu!",
            {
              position: "bottom-right",
              timeout: 5000,
              closeOnClick: true,
              pauseOnFocusLoss: true,
              pauseOnHover: true,
              draggable: true,
              draggablePercent: 0.6,
              showCloseButtonOnHover: false,
              hideProgressBar: true,
              closeButton: "button",
              icon: true,
              rtl: false,
            }
          );
          vm.loadData();
        })
        .catch((res) => {
          console.log(res);
        });
    });
    /**
     * Xóa nhiều người
     * CreatedBy: LNTHAO (14/08)
     */
    eventBus.$on("deleteAllChecked", async (value) => {
      this.employeeCheck = value;
      for (var i = 0; i < this.employeeCheck.length; i++) {
        // if (this.isChecked[i]) {
          await axios
            .delete(
              "http://cukcuk.manhnv.net/v1/Employees/" +
                this.employeeCheck[i]
            )
            .then((res) => {
              console.log("res" + res);
              // alert("Xóa thành công!");
              
            })
            .catch((res) => {
              console.log(res);
            });
        // }
      }
      this.loadData();
      this.turnOn = false;
      this.employeeCheck.splice(0, this.employeeCheck.length);
      console.log(this.employeeCheck);
    });
  
    eventBus.$on("pagination", (page) => {
      this.pageIndex = page;
      this.filterEmployees(
        this.pageIndex,
        this.pageSize,
        this.keyword,
        this.departmentId,
        this.positionId
      );
    });
  
    // get all employees
    this.filterEmployees(
      this.pageIndex,
      this.pageSize,
      this.keyword,
      this.departmentId,
      this.positionId
    );
  },

  methods: {
    /**
     * Load dữ liệu cho bảng
     * CreatedBy: LNTHAO (4/8)
     */
    async loadData() {
      var vm = this;
      // vm.$toast.info("Vui lòng đợi hệ thống load dữ liệu!", {
      //       position: "bottom-right",
      //       timeout: 2000,
      //       closeOnClick: true,
      //       pauseOnFocusLoss: true,
      //       pauseOnHover: true,
      //       draggable: true,
      //       draggablePercent: 0.6,
      //       showCloseButtonOnHover: false,
      //       hideProgressBar: true,
      //       closeButton: "button",
      //       icon: true,
      //       rtl: false,
      //     });
      axios//
        .get("https://localhost:44344/api/v1/Employees")//http://cukcuk.manhnv.net/v1/Employees
        .then((res) => {
          // Response.AppendHeader ("Access-Control-Allow-Origin", "*");
          vm.employees = res.data;
          this.$toast.info("Load dữ liệu thành công!", {
            position: "bottom-right",
            timeout: 2000,
            closeOnClick: true,
            pauseOnFocusLoss: true,
            pauseOnHover: true,
            draggable: true,
            draggablePercent: 0.6,
            showCloseButtonOnHover: false,
            hideProgressBar: true,
            closeButton: "button",
            icon: true,
            rtl: false,
          });
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
      vm.isHideForm = false;
      eventBus.$emit("openModalForm", vm.isHideForm);
      vm.modeFormDetail = 0;
    },
    /**
     * Xem thông tin nhân viên khi nhấn biểu tượng edit
     * CreatedBy: LNTHAO (29/07)
     */
    fixInfor(emplId) {
      this.modeFormDetail = 1;
      this.isHideForm = false;
      this.employeeId = emplId;
      eventBus.$emit("openModalFormToEdit", this.isHideForm);
      // alert(emplId.EmployeeId);
    },
    /**
     * Nhấn nút xóa để xóa 1 nhân viên
     * CreatedBy: LNTHAO (05/08)
     */
    btnDelete(empl) {
      eventBus.$emit("openPopUpDelete", empl);
    },


    /** TODO----------------------------------
     * Xóa nhân viên khi chọn check box - Đang làm
     * CreatedBy: LNTHAO (05/08)
     */
    btnDeleteAll() {
      // alert("Bạn chắc chắn muốn xóa nhân viên?");
      eventBus.$emit("openPopUpDeleteMany", this.employeeCheck);
      // eventBus.$emit("deleteAllChecked", this.employeeCheck);
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
     * Format trạng thái hoạt động - Xem lại giá trị để match cho chuẩn
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
    
    /**
     * Hàm xóa nhân viên
     * CreatedBy: LNTHAO (12/8/2021)
     */
    async btnDeleteOnClick() {
      for (var i = 0; i < this.employeeCheck.length; i++) {
        // if (this.isChecked[i]) {
          await axios
            .delete(
              "http://cukcuk.manhnv.net/v1/Employees/" +
                this.employeeCheck[i].EmployeeId
            )
            .then((res) => {
              console.log("res" + res);
              alert("Xóa thành công!");
              // this.showMessage(type.SUCCESS, [message.DELETE_MSG_SUCCESS]);
              // this.isHidePopup = true;
              this.loadData();
            })
            .catch((res) => {
              console.log(res);
              
              // this.showMessage(type.WARNING, [message.EXCEPTION_MSG]);
            });
        // }
      }
    },
    /**
     * Hàm đánh dấu bản ghi đã được chọn
     * CreatedBy: LNTHAO (12/8/2021)
     */
    async btnCheckedOnClick(index) {
      // this.countChecked = 0;
      // this.dialogFormMode = "del";
      // this.$set(this.isChecked, index, !this.isChecked[index]);
      this.turnOn = true;
      this.employeeCheck.push(index);
      console.log(this.employeeCheck);
      // eventBus.$emit("deleteAllChecked", this.employeeCheck);
    },

    /**
     * Filter data by keyword, departmentId, positionId api
     * Author : LP(7/8)
     */
    async filterEmployees(
      pageIndex,
      pageSize,
      keyword,
      departmentId,
      positionId
    ) {
      try {
        let result = await axios.get(
          "http://cukcuk.manhnv.net/v1/Employees" +
            `/paging?keyword=${keyword}&positionId=${positionId}&departmentId=${departmentId}&pageIndex=${
              (pageIndex-1) * pageSize
            }&pageSize=${pageSize}`
        );
        this.employees = result.data;
      } catch (error) {
        console.log("filterEmployees\n" + error);
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
.btn-Del-active{
  opacity: 1;
  background-color: red;
}
</style>