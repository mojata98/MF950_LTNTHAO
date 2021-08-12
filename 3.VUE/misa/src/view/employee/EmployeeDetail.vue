<template>
  <div>
    <div class="modal" id="modal" :class="{ 'm-dialog-hidden': isHideForm }">
      <div class="modal-content">
        <!-- ========================================================Header================================================================ -->
        <div class="modal-header">
          <div class="title-hold">
            <div class="form-title">Thông tin nhân viên</div>
          </div>
          <button type="button" class="btn-close button" id="btn-close">
            <div class="btn-close-icon" v-on:click="btnCloseForm()"></div>
          </button>
        </div>
        <!-- ========================================================Body================================================================ -->
        <div
          class="modal-content-hold-scroll"
          style="overflow-y: auto; display: block; height: 536px"
        >
          <form action="#" class="form">
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
                    <ValidationProvider
                      rules="required"
                      name="Mã nhân viên"
                      v-slot="{ errors }"
                    >
                      <input
                        type="text"
                        id="txtEmployeeCode"
                        required
                        class="text-box-default"
                        autofocus
                        tabindex="1"
                        v-model="employee.EmployeeCode"
                        ref="EmployeeCode"
                        
                      />
                      <span>{{ errors[0] }}</span>
                    </ValidationProvider>
                  </div>

                  <div class="input">
                    <label for="fullName" class="title-input"
                      >Họ và tên (<span class="required">*</span>)</label
                    >
                    <ValidationProvider
                      rules="required"
                      name="Họ và tên"
                      v-slot="{ errors }"
                    >
                      <input
                        type="text"
                        id="txtFullName"
                        required
                        class="text-box-default"
                        tabindex="2"
                        v-model="employee.FullName"
                        v-bind:class="{ 'border-error': hasError, 'border-default': noError }"
                      />
                      <span>{{ errors[0] }}</span>
                    </ValidationProvider>
                  </div>

                  <div class="input">
                    <label for="birthOfDay" class="title-input date"
                      >Ngày sinh</label
                    >
                    <datepicker
                    v-model="employee.DateOfBirth"
                    :format="'DD/MM/YYYY'"
                    :value-type="'YYYY-MM-DD'"
                    style="width: 100%; height: 42px;"
                    >
                    <input
                      type="date"
                      id="txtDateOfBirth"
                      class="text-box-default"
                      tabindex="3"
                      v-model="employee.DateOfBirth"
                    />
                    </datepicker>
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
                      >Số CMTND/ Căn cước (<span class="required">*</span
                      >)</label
                    >
                    <ValidationProvider
                      rules="required"
                      name="CMND/Căn cước"
                      v-slot="{ errors }"
                    >
                      <input
                        type="text"
                        id="txtIdentityNumber"
                        required
                        class="text-box-default"
                        tabindex="5"
                        v-model="employee.IdentityNumber"
                      />
                      <span>{{ errors[0] }}</span>
                    </ValidationProvider>
                  </div>
                  <div class="input">
                    <label for="dayOfCMTND" class="title-input"
                      >Ngày cấp
                    </label>
                    <datepicker
                    v-model="employee.IdentityDate"
                    :format="'DD/MM/YYYY'"
                    :value-type="'YYYY-MM-DD'"
                    style="width: 100%; height: 42px;"
                    >
                    <input
                      type="date"
                      id="txtIdentityDate"
                      class="text-box-default"
                      tabindex="6"
                      v-model="employee.IdentityDate"
                    />
                    </datepicker>
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
                    <ValidationProvider
                      rules="required"
                      name="Email"
                      v-slot="{ errors }"
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
                      <span>{{ errors[0] }}</span>
                    </ValidationProvider>
                  </div>
                  <div class="input">
                    <label for="phone" class="title-input"
                      >Số điện thoại(<span class="required">*</span>)</label
                    >
                    <ValidationProvider
                      rules="required"
                      name="Số điện thoại"
                      v-slot="{ errors }"
                    >
                      <input
                        type="text"
                        id="txtPhoneNumber"
                        required
                        class="text-box-default"
                        tabindex="9"
                        v-model="employee.PhoneNumber"
                      />
                      <span>{{ errors[0] }}</span>
                    </ValidationProvider>
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
                        v-mask="'##.###.###'"
                      />
                      <span class="icon">(VNĐ)</span>
                    </div>
                  </div>
                  <div class="input">
                    <label for="dayOfJoin" class="title-input"
                      >Ngày gia nhập công ty</label
                    >
                    <datepicker
                    v-model="employee.JoinDate"
                    :format="'DD/MM/YYYY'"
                    :value-type="'YYYY-MM-DD'"
                    style="width: 100%; height: 42px;"
                    >
                    <input
                      type="date"
                      id="txtJoinDate"
                      required
                      class="text-box-default"
                      tabindex="14"
                      v-model="employee.JoinDate"
                    />
                    </datepicker>
                  </div>

                  <div class="input">
                    <label for="general" class="title-input"
                      >Tình trạng công việc</label
                    >
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
        </div>
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

    <BasePopup @closeDetailForm="btnCancelForm()" />
  </div>
</template>

<script>
import axios from "axios";
import BasePopup from "../../components/base/BasePopup.vue";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
import eventBus from "../../js/eventBus";
import { ValidationProvider, extend } from "vee-validate";
// import DatePicker from 'vue2-datepicker';
// import 'vue2-datepicker/index.css';
// import $ from 'jquery';
// import moment from 'moment';

extend("required", {
  validate(value) {
    return {
      required: true,
      valid: ["", null, undefined].indexOf(value) === -1,
    };
  },
  computesRequired: true,
});

export default {
  components: {
    BasePopup,
    BaseDropdown,
    ValidationProvider,
    // DatePicker,
  },

  created() {
    /**
     * Nhận sự kiện mở form NV và lấy mã NV mới
     * CreatedBy: LNTHAO (11/08)
     */
    eventBus.$on("openModalForm", (value) => {
      this.isHideForm = value;
      this.$nextTick(function () {
        this.$refs.EmployeeCode.focus();
      });
      axios
        .get("http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode")
        .then((res) => {
          this.employee.EmployeeCode = res.data;
          this.$refs.EmployeeCode.value = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
    });
    /**
     * Nhận sự kiện đóng PopUp và Form NV khi chọn Đóng trong PopUP
     * CreatedBy: LNTHAO (10/08)
     */
    eventBus.$on("closePopUpAndModalForm", (value) => {
      this.isHideForm = value;
    });
    /**
     * Nhận sự kiện mở Form NV khi nhấn nút Edit
     * CreatedBy: LNTHAO (11/08)
     */
    eventBus.$on("openModalFormToEdit", (value) => {
      this.isHideForm = value;
      this.$nextTick(function () {
        this.$refs.EmployeeCode.focus();
      });
    })
  },
  methods: {
    /**
     * Đóng form nhân viên khi ấn nút Hủy
     * CreatedBy: LNTHAO (01/08)
     */
    btnCancelForm() {
      this.isHideForm = true;
    },
    /**
     * Đóng Popup khi nhấn nút X
     * CreatedBy: LNTHAO (01/08)
     */
    btnCloseForm() {
      this.isHidePopup = false;
      eventBus.$emit("openPopUp", this.isHidePopup);
    },
    /**
     * Lưu dữ liệu - Thêm mới dữ liệu
     * Author: LNTHAO (01/08/2021)
     */
    async btnSave() {
      if (this.mode == 0) {
        let vm = this;
        // Thêm mới nhân viên
        await axios
          .post(`http://cukcuk.manhnv.net/v1/Employees`, vm.employee)
          .then((res) => {
            this.$toast.success(
              "Thêm mới thành công! \nVui lòng đợi trong giây lát để hệ thống tải lại dữ liệu!",
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
            console.log(res);
            this.isHideForm = true;
            this.$emit("loadData");
          })
          .catch((res) => {
            this.$toast.error("Dữ liệu nhập không hợp lệ!", {
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
            });
            console.log(res);
          });
        vm.employee = {};// Bị dính lỗi validate lần 2

      } else {
        let vm = this;
        // Sửa thông tin nhân viên
        await axios
          .put(
            `http://cukcuk.manhnv.net/v1/Employees/${vm.employeeId}`,
            vm.employee
          )
          .then((res) => {
            this.$toast.success(
              "Sửa thông tin thành công! \nVui lòng đợi trong giây lát để hệ thống tải lại dữ liệu!",
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
            console.log(res);
            this.isHideForm = true;
            this.$emit("loadData");
          })
          .catch((res) => {
            console.log(res);
          });
      }
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
  },
  setup() {},
  props: {
    employeeId: {
      type: String,
    },
    mode: {
      type: Number,
      required: true,
      default: 0, // 0 - Thêm mới, 1 - Sửa thông tin
    },
    employeeCode: {
      type: String,
    },
  },
  data() {
    return {
      employee: {},
      isHidePopup: true,
      isHideForm: true,
      value: "",
      hasError: false,
      noError: true,
    };
  },
  watch: {
    /**------------------------------
     * Lấy dữ liệu cho bảng từ API
     * Author: LNTHAO (29/07/2021)
     */
    employeeId: function (value) {
      let vm = this;
      axios
        .get(`http://cukcuk.manhnv.net/v1/Employees/${value}`)
        .then((res) => {
          vm.employee = res.data;
          console.log(vm.employee);
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

    employeeCode: function (value) {
      if (this.mode == 0) {
        let vm = this;
        vm.employee.employeeCode = value;
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
@import "../../css/base/popup.css";

.border-error {
  border-color: red;
}

.border-default {
  border-color: #ccc;
}

.border-right {
  border-color: #01b075;
}
</style>