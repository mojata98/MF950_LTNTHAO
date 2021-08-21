<template>
  <div>
    <div class="content">
      <div class="content-title">
        <div class="content-title-text">Danh sách nhân viên</div>

        <div
          class="button button-new btnDel"
          id="btnDel"
          :class="{ 'btn-Del-active': turnOn }"
        >
          <div class="button-icon-delete"></div>
          <div class="button-value" @click="btnDeleteAll()" ref="deleteAll">
            Xóa nhân viên
          </div>
        </div>

        <div class="button-new" id="btnAdd">
          <div class="button-icon"></div>
          <div class="button-value" @click="btnAddOnClick()">
            Thêm nhân viên
          </div>
        </div>
      </div>

      <div class="filter">
        <div class="filter-search" style="align-items: center; display: flex">
          <input
            type="text"
            placeholder="Tìm kiếm theo Mã, Tên, SĐT"
            
            style="width: 200px; z-index: 100"
            class="icon-search input-search"
            tabindex="1"
            name="inputSearch"
            id="txtSearch"
            v-model="keysearch"
            @input="openIconDelete"
          />

          <div
            class="clear-search-icon"
            :class="{ 'icon-delete-close': isClose }"
            @click="clearValueInput"
          ></div>
        </div>

        <BaseDropdown
          id="main-department"
          style="margin-left: 16px; width: 200px"
          nameDropdown="filter-department"
          dropdownType="dropdown-department"
          myUrl="v1/Departments"
          dropdownValue="drdValueDepartment"
          defaultName="Tất cả phòng ban"
          itemId="DepartmentId"
          itemName="DepartmentName"
          ref="textDropdownDepartment"
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
          ref="textDropdownPostion"
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
            <tr v-for="employee in employees" :key="employee.EmployeeId">
              <td style="text-align: center">
                <input
                  type="checkbox"
                  class="checkbox"
                  @click="btnCheckedOnClick(employee.EmployeeId)"
                />
              </td>

              <td style="min-width: 100px">{{ employee.EmployeeCode }}</td>
              <td style="min-width: 100px; max-width: 150px">
                {{ employee.FullName }}
              </td>
              <td style="min-width: 50px">{{ employee.GenderName }}</td>
              <td style="min-width: 50px; text-align: center">
                {{
                  employee.DateOfBirth
                    ? moment(employee.DateOfBirth).format("DD/MM/YYYY")
                    : ""
                }}
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
      <BasePagination
        style="position: absolute; bottom: 0; width: 100%; height: 56px"
        :pageIndex="pageIndex"
        :pageSize="pageSize"
        ref="resetPaging"
        @paging="paging"
      />
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
import eventBus from "../../js/eventBus";
import BasePagination from "../../components/base/BasePagination.vue";
// import $ from 'jquery';
export default {
  name: "EmployeePage",
  components: {
    EmployeeDetail,
    BasePopup,
    BaseDropdown,
    BasePagination,
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
      // data cho việc filter
      keysearch: "",
      positionId: "",
      departmentId: "",
      pageIndex: 1,
      pageSize: 15,
      amount: 0, //số bản ghi trong 1 trang
      isClose: true, // hidden icon delete trong input search
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
    });
    /**
     * Nhận sự kiện xóa từ Popup
     * CreatedBy: LNTHAO (12/08)
     */
    eventBus.$on("deletePerson", (value) => {
      var id = value;
      let vm = this;
      axios
        .delete("https://localhost:44338/api/v1/Employees/" + id)
        .then((res) => {
          console.log(res);
          this.$toast.success(
            "Xóa dữ liệu thành công! Hệ thống dang tải lại dữ liệu!",
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
            "https://localhost:44338/api/v1/Employees/" + this.employeeCheck[i]
          )
          .then((res) => {
            console.log("res" + res);
            this.$toast.success(
            "Xóa dữ liệu thành công!",
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

    // eventBus.$on("pagination", (page) => {
    //   this.pageIndex = page;
    //   this.filterEmployees(
    //     this.pageIndex,
    //     this.pageSize,
    //     this.keyword,
    //     this.departmentId,
    //     this.positionId
    //   );
    // });

    // Lấy dữ liệu
    this.getEmployeesByFilter(
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
      axios //http://cukcuk.manhnv.net/v1/Employees
        .get("https://localhost:44338/api/v1/Employees") //
        .then((res) => {
          vm.employees = res.data;
          // debugger; //eslint-disable-line
          // this.$toast.info("Load dữ liệu thành công!", {
          //   position: "bottom-right",
          //   timeout: 2000,
          //   closeOnClick: true,
          //   pauseOnFocusLoss: true,
          //   pauseOnHover: true,
          //   draggable: true,
          //   draggablePercent: 0.6,
          //   showCloseButtonOnHover: false,
          //   hideProgressBar: true,
          //   closeButton: "button",
          //   icon: true,
          //   rtl: false,
          // });
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
      eventBus.$emit("reloadDropdown");
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

    /** ------------------------------------------------------------
     * Xóa nhân viên khi chọn check box
     * CreatedBy: LNTHAO (05/08)
     */
    btnDeleteAll() {
      eventBus.$emit("openPopUpDeleteMany", this.employeeCheck);
    },
    /**----------------------------------------
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
    /** -----------------------------
     * Format trạng thái hoạt động
     * CreatedBy: LNTHAO (06/08)
     */
    formatWorkStatus(value) {
      switch (value) {
        case 0:
          return "Đang thử việc";
        case 1:
          return "Đang làm việc";
        case 2:
          return "Đang nghỉ phép";
        case 3:
          return "Đã nghỉ việc";
        default:
          return "";
      }
    },

    /**--------------------------------
     * Hàm xóa nhiều nhân viên
     * CreatedBy: LNTHAO (12/8/2021)
     */
    async btnDeleteOnClick() {
      for (var i = 0; i < this.employeeCheck.length; i++) {
        // if (this.isChecked[i]) {
        await axios
          .delete(
            "https://localhost:44338/api/v1/Employees/" +
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
    /**-----------------------------------
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

    /**--------------------------------------------------------
     * Lọc dữ liệu trong bảng theo dropdown và filter
     * Author : LNT(17/8)
     */
    getEmployeesByFilter() {
      var self = this; // LINK:
      axios
        .get(
          `https://localhost:44338/api/v1/Employees/filter?pageIndex=${
            (this.pageIndex - 1) * this.pageSize
          }
        &pageSize=${this.pageSize}&positionId=${this.positionId}&departmentId=${
            this.departmentId
          }&keysearch=${this.keysearch}`
        )
        .then((res) => {
          self.employees = res.data;
          // debugger; // eslint-disable-line
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**---------------------------------------------------
     * Hàm set value position để filter
     * CreateBy:LNT (20/8/2021)
     */
    getValPosition(position) {
      this.positionId = position;
      console.log(this.positionId);
      this.getEmployeesByFilter(
        this.pageIndex,
        this.pageSize,
        this.positionId,
        this.departmentId,
        this.keysearch
      );
    },

    /**---------------------------------------------------
     * Hàm set value department để filter
     * CreateBy:LNT (20/8/2021)
     */
    getValDepartment(department) {
      this.departmentId = department;
      console.log(this.departmentId);
      this.getEmployeesByFilter(
        this.pageIndex,
        this.pageSize,
        this.positionId,
        this.departmentId,
        this.keysearch
      );
    },

    /**----------------------------------------------------
     * Hàm bắt sự kiện click nút xóa trên input search
     * CreateBy: LNT (20/08/2021)
     */
    clearValueInput() {
      this.keysearch = "";
      this.isClose = true;
      // load lại table
      this.loadData();
    },

    /**-----------------------------------------------------------
     * Hàm bắt sự kiện hiển thị nút xóa khi nhập vào input search
     * khi có text thì search theo text
     * CreateBy: LNT (20/08/2021)
     */
    openIconDelete() {
      if (this.keysearch == "") {
        this.isClose = true;
        this.loadData();
      } else {
        this.isClose = false;
        this.getEmployeesByFilter(
          this.pageIndex,
          this.pageSize,
          this.positionId,
          this.departmentId,
          this.keysearch
        );
      }
    },

    /**----------------------------------------------------------
     * Phân trang
     * CreateBy: LNT (20/08/2021)
     */
    paging(indexPage) {
      this.pageIndex = indexPage;
      this.getEmployeesByFilter(
        this.pageIndex,
        this.pageSize,
        this.positionId,
        this.departmentId,
        this.keysearch
      );
    },

    /**---------------------------------------------------------------
     * Hàm reload table và các control filter
     * CreateBy: LNT (20/08/2021)
     */
    reloadTableAndFilter() {
      var self = this;
      // binding data
      axios
        .get("https://localhost:44338/api/v1/Employees")
        .then((res) => {
          self.employees = res.data;
          self.amountPage = res.data.length;
          self.$refs.textDropdownPostion.setTextDefault();
          self.$refs.textDropdownDepartment.setTextDefault();
          self.keysearch = "";
          self.isClose = true;
          self.$refs.resetPaging.resetPaging();
        })
        .catch((res) => {
          console.log(res);
        });
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
.btn-Del-active {
  opacity: 1;
  background-color: red;
}
.clear-search-icon {
  height: 16px;
  width: 16px;
  z-index: 101;
  position: absolute;
  right: 16px;
  background-image: url(../../assets/icon/x.svg);
  background-repeat: no-repeat;
  background-size: contain;
}

.clear-search-icon:hover {
  cursor: pointer;
  background-color: #ccc;
  border-radius: 50%;
}
.icon-delete-close {
  display: none;
}
</style>