<template>
  <div>
    <div class="modal" id="modal" :class="{ 'm-dialog-hidden': isHide }">
      <div class="modal-content">
        <button type="button" class="btn-close button" id="btn-close">
          <div class="btn-close-icon" v-on:click="btnCloseForm()"></div>
          <!-- <i class="fas fa-times "></i> -->
          <!-- </div>               -->
        </button>
        <form action="#" class="form">
          <div class="form-title">Thông tin nhân viên</div>
          <div class="form-content">
            <div class="avatar-employee">
              <div class="avatar">
                <input type="file" id="avatar" hidden />
              </div>
              <div class="text">
                (Vui lòng chọn ảnh có định dạng .jpg. .jpeg. .png. .gif.)
              </div>
            </div>
            <!-- ========================================================General Information================================================================ -->
            <div class="info-employee">
              <div class="form-info">
                <div class="infomation-title">
                  <span class="text"> A. Thông tin chung: </span>
                </div>
                <div class="input">
                  <label for="id" class="title-input"
                    >Mã nhân viên (<span class="required">*</span>)</label
                  >
                  <input
                    type="text"
                    id="txtEmployeeCode"
                    required
                    class="text-box-default"
                    autofocus
                    tabindex="1"
                    v-model="employee.EmployeeCode"
                  />
                </div>
                <div class="input">
                  <label for="fullName" class="title-input"
                    >Họ và tên (<span class="required">*</span>)</label
                  >
                  <input
                    type="text"
                    id="txtFullName"
                    required
                    class="text-box-default"
                    tabindex="2"
                    v-model="employee.FullName"
                  />
                  <span class="tooltiptext">Định dạng không hợp lệ.</span>
                </div>
                <div class="input">
                  <label for="birthOfDay" class="title-input date"
                    >Ngày sinh</label
                  >
                  <input
                    type="date"
                    id="txtDateOfBirth"
                    class="text-box-default"
                    tabindex="3"
                    v-model="employee.DateOfBirth"
                  />
                </div>

                <div class="input">
                    <label for="general" class="title-input">Giới tính</label>
                    <BaseDropdown
                    id="txtGender" 
                    tabindex="4"
                    nameDropdown="filter-gender"
                    dropdownType="dropdown-gender drdialog"
                    dropdownValue="txtGender"
                    itemId="Gender"
                    itemName="GenderName"
                    :selectedId="employee.Gender + ''"
                    v-model="employee.Gender"
                    />
                </div>

                <div class="input">
                  <label
                    for="CMTND"
                    class="title-input identityCode"
                    title="Số CMTND/ Căn cước"
                    >Số CMTND/ Căn cước (<span class="required">*</span>)</label
                  >
                  <input
                    type="text"
                    id="txtIdentityNumber"
                    required
                    class="text-box-default"
                    tabindex="5"
                    v-model="employee.IdentityNumber"
                  />
                </div>
                <div class="input">
                  <label for="dayOfCMTND" class="title-input">Ngày cấp </label>
                  <input
                    type="date"
                    id="txtIdentityDate"
                    class="text-box-default"
                    tabindex="6"
                    v-model="employee.IdentityDate"
                  />
                </div>
                <div class="input custom-input" id="txtIdentityPlace1">
                  <label for="addressOfCMTND" class="title-input"
                    >Nơi cấp</label
                  >
                  <input
                    type="text"
                    id="txtIdentityPlace"
                    class="text-box-default"
                    tabindex="7"
                    v-model="employee.IdentityPlace"
                  />
                </div>
                <div class="input" style="display: none; position: fixed">
                  <label for="dayOfCMTND" class="title-input"></label>
                  <input
                    type="date"
                    id="dayOfCMTND1"
                    class="text-box-default"
                  />
                </div>
                <div class="input">
                  <label for="email" class="title-input"
                    >Email(<span class="required">*</span>)</label
                  >
                  <input
                    type="text"
                    id="txtEmail"
                    placeholder="example@domain"
                    required
                    class="text-box-default"
                    tabindex="8"
                    v-model="employee.Email"
                  />
                </div>
                <div class="input">
                  <label for="phone" class="title-input"
                    >Số điện thoại(<span class="required">*</span>)</label
                  >
                  <input
                    type="text"
                    id="txtPhoneNumber"
                    required
                    class="text-box-default"
                    tabindex="9"
                    v-model="employee.PhoneNumber"
                  />
                </div>
                <!-- ========================================================Information Title================================================================ -->
                <div class="infomation-title">
                  <span class="text"> B. Thông tin công việc: </span>
                </div>

                <div class="input">
                    <label for="general" class="title-input">Vị trí</label>
                    <BaseDropdown
                    tabindex="10"
                    id="txtPositionName"
                    nameDropdown="filter-dlgposition"
                    dropdownType="dropdown-position drdialog"
                    myUrl="v1/Positions"
                    dropdownValue="txtPositionName"
                    itemName="PositionName"
                    itemId="PositionId"
                    :selectedId="employee.PositionId"
                    v-model="employee.PositionId"
                    />
                </div>

                <div class="input">
                    <label for="general" class="title-input">Phòng ban</label>
                    <BaseDropdown
                    tabindex="11"
                    id="txtDepartmentName"
                    nameDropdown="filter-dlgdepartment"
                    dropdownType="dropdown-department drdialog"
                    itemId="DepartmentId"
                    itemName="DepartmentName"
                    :selectedId="employee.DepartmentId"
                    v-model="employee.DepartmentId"
                    myUrl="api/Department"
                    dropdownValue="txtDepartmentName"
                    />
                </div>

                <div class="input taxCode">
                  <label for="taxCode" class="title-input"
                    >Mã số thuế cá nhân</label
                  >
                  <input
                    type="text"
                    id="txtPersonalTaxCode"
                    class="text-box-default"
                    tabindex="12"
                    v-model="employee.PersonalTaxCode"
                  />
                </div>
                <div class="input salary-base">
                  <label for="salary" class="title-input"
                    >Mức lương cơ bản</label
                  >
                  <div class="salary">
                    <input
                      type="text"
                      id="txtSalary"
                      class="text-box-default"
                      tabindex="13"
                      v-model="employee.Salary"
                    />
                    <span class="icon">(VNĐ)</span>
                  </div>
                </div>
                <div class="input">
                  <label for="dayOfJoin" class="title-input"
                    >Ngày gia nhập công ty</label
                  >
                  <input
                    type="date"
                    id="txtJoinDate"
                    required
                    class="text-box-default"
                    tabindex="14"
                    v-model="employee.JoinDate"
                  />
                </div>

                <div class="input">
                    <label for="general" class="title-input"
                      >Tình trạng công việc</label>
                    <BaseDropdown
                    tabindex="15"
                    id="txtWorkStatus"
                    nameDropdown="filter-status"
                    dropdownType="dropdown-status drdialog"
                    dropdownValue="txtWorkStatus"
                    itemId="WorkStatus"
                    itemName="WorkStatusName"
                    :selectedId="employee.WorkStatus + ''"
                    v-model="employee.WorkStatus"
                    />
                </div>
              </div>
            </div>
          </div>
        </form>
        <!-- ========================================================Footer================================================================ -->
        <div class="modal-footer">
          <button
            class="btn-cancel button"
            tabindex="16"
            id="btn-cancel"
            v-on:click="btnCancelForm()"
          >
            Hủy
          </button>
          <button
            class="btn-save button-icon button"
            tabindex="17"
            v-on:click="btnSave()"
          >
            <span class="icon-left"></span>
            <span class="text" id="btn-save">Lưu</span>
          </button>
        </div>
      </div>
    </div>

    <BasePopup
      v-bind:isHidePopup="isHidePopup"
      @isHidePopupUpdated="isHidePopup = $event"
    />
  </div>
</template>

<script>
import axios from "axios";
import BasePopup from "../../components/base/BasePopup.vue";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
export default {
  components: {
    BasePopup,
    BaseDropdown,
  },
  methods: {
    
    btnCancelForm() {
      // this.isHide = true; // khôg nên có
      this.$emit("isHideUpdated", true);
    },

    btnCloseForm() {
      this.isHidePopup = false;
    },

    /**
     * Lưu dữ liệu - Thêm mới dữ liệu
     * Author: LNTHAO (01/08/2021)
     */
    btnSave() {
      if (this.mode == 0) {
        let vm = this;
        // Gọi API lấy dữ liệu
        axios
          .post(`http://cukcuk.manhnv.net/v1/Employees`, vm.employee)
          .then((res) => {
            alert("Thêm mới thành công.");
            console.log(res);
            this.$emit("loadData");
          })
          .catch((res) => {
            console.log(res);
          });
      } else {
        let vm = this;
        // Gọi API lấy dữ liệu
        axios
          .put(
            `http://cukcuk.manhnv.net/v1/Employees/${vm.employeeId}`,
            vm.employee
          )
          .then((res) => {
            alert("Sửa thành công.");
            console.log(res);
            this.$emit("loadData");
          })
          .catch((res) => {
            console.log(res);
          });
      }
      this.$emit("isHideUpdated", true);
      // window.$forceUpdate();
      // console.log(this);
    },
  },
  setup() {},
  props: {
    isHide: {
      // chi duoc doc khong duoc sua
      type: Boolean,
      default: true,
      required: true,
    },
    employeeId: {
      type: String,
      // default: '',
      // required: true,
    },
    mode: {
      type: Number,
      required: true,
      default: 0, // 0 - Thêm mới, 1 - Sửa thông tin
    },
  },
  data() {
    return {
      employee: {},
      isHidePopup: true,
    };
  },
  watch: {
    /**------------------------------
     * Lấy dữ liệu cho bảng từ API
     * Author: LNTHAO (29/07/2021)
     */
    employeeId: function (value) {
      // alert("watch: " + this.employeeId);
      let vm = this;
      // Gọi API lấy dữ liệu
      axios
        .get(`http://cukcuk.manhnv.net/v1/Employees/${value}`)
        .then((res) => {
          // console.log(res.data);
          vm.employee = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
    },

    mode: function () {
      if (this.mode == 0) {
        this.employee = {};
      }
    },
  },
  computed: {
    testEmployeeId: function () {
      return this.employeeId;
    },
  },
};
</script>

<style scoped>
/* @import '../../css/layout/modal-form.css'; */
@import "../../css/base/popup.css";
</style>