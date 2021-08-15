<template>
  <div
    class="popup-container"
    :class="{ 'popup-hidden': isHidePopup }"
    style="
      position: absolute;
      left: 50%;
      top: 50%;
      transform: translate(-50%, -50%);
      z-index: 50;
    "
  >
    <div class="popup-header">
      <div class="btn-close" @click="btnClosePopupForm()">
        <div class="close-icon"></div>
      </div>
    </div>
    <div class="popup-body">
      <div class="popup-title"><b>Đóng Form thông tin chung</b></div>
      <div class="popup-content">
        <div class="popup-icon-contain">
          <div 
          class="popup-icon "
          :class="{ 'popup-icon-warning': isWarning , 'popup-icon-delete': isDelete}"
          ></div>
        </div>
        <div class="popup-message-contain">
          <div class="popup-message">
            <span :class="{ 'hide-message-warning': isMessageWarning }">Bạn có chắc chắn muốn đóng <b>"Thông tin nhân viên"</b> hay không?</span> 
            <span :class="{ 'hide-message-delete': isMessageDelete }">Bạn có chắc chắn muốn xóa Nhân viên có mã <b>{{ message }}</b> hay không?</span> 
            <span :class="{ 'hide-message-delete': isMessageDeleteMany }">Bạn có chắc chắn muốn xóa Nhân viên có mã <b>{{ message }}</b> hay không?</span> 
          </div>
        </div>
      </div>
    </div>
    <div class="popup-footer">
      <div class="button btnContinue" @click="btnClosePopupForm()">
        <span :class="{ 'hide-message-warning': isMessageWarning }">Tiếp tục nhập</span> 
        <span :class="{ 'hide-message-delete': isMessageDelete }">Hủy</span> 
        </div>
      <div class="button " @click="btnCloseModalForm()"
        :class="{ 'btnClose': isWarning , 'btnDelete': isDelete}" 
      >
        <span :class="{ 'hide-message-warning': isMessageWarning }">Đóng</span> 
        <span :class="{ 'hide-message-delete': isMessageDelete }">Xóa</span>
        <span :class="{ 'hide-message-delete-many': isMessageDeleteMany }">Xóa</span>
      </div>
    </div>
  </div>
</template>

<script>
import eventBus from "../../js/eventBus";
import axios from "axios";

export default {
  name: "Popup",

  props: {
    
  },

  created() {
    /**
     * Mở popup dạng warning
     * CreatedBy: LNTHAO (12/08)
     */
    eventBus.$on("openPopUp", (value) => {
      this.isHidePopup = value;
      this.isWarning = true;
      this.isDelete = false;
      this.isMessageWarning = false;
      this.isMessageDelete = true;
      this.isMessageDeleteMany = true;
    });
    /**
     * Mở popup dạng delete
     * CreatedBy: LNTHAO (12/08)
     */
    eventBus.$on("openPopUpDelete", async (value) => {
      this.value = value; // id của NV cần xóa
      this.isHidePopup = false;
      this.isWarning = false;
      this.isDelete = true;
      this.isMessageWarning = true;
      this.isMessageDelete = false;
      this.isMessageDeleteMany = true;
      await axios
        .get(`http://cukcuk.manhnv.net/v1/Employees/${value}`)
        .then((res) => {
          this.employee = res.data;
          console.log(this.employee);
        })
        .catch((res) => {
          console.log(res);
        });
      this.message = this.employee.EmployeeCode;
    });
    /**
     * Mở popup dạng delete nhiều người
     * CreatedBy: LNTHAO (12/08)
     */
    eventBus.$on("openPopUpDeleteMany", async (value) => {
      this.idDelete = value; // id của NV cần xóa
      this.isHidePopup = false;
      this.isWarning = false;
      this.isDelete = true;
      this.isMessageWarning = true;
      this.isMessageDelete = true;
      this.isMessageDeleteMany = false;
      for (let index = 0; index < this.idDelete.length; index++) {
        await axios
        .get(`http://cukcuk.manhnv.net/v1/Employees/${this.idDelete[index]}`)
        .then((res) => {
          this.employee = res.data;
          console.log(this.employee);
        })
        .catch((res) => {
          console.log(res);
        });
        this.codeDelete[index] = this.employee.EmployeeCode;
      }
      for (let index = 0; index < this.codeDelete.length - 1; index++) {
        this.message += this.codeDelete[index] + ", ";
      }
      this.message += this.codeDelete[this.codeDelete.length - 1];
      console.log(this.message);
    });
    /**
     * Đóng popup khi ấn Hủy hoặc dấu X
     * CreatedBy: LNTHAO (12/08)
     */
    eventBus.$on("closePopUp", (value) => {
      this.isHidePopup = value;
    });
  
  },

  methods: {
    /**
     * Đóng PopUp khi nhấn vào nút X hoặc Tiếp tục nhập
     * CreatedBy: LNTHAO (10/08)
     */
    btnClosePopupForm(){
      eventBus.$emit("closePopUp", true);
    },
    /**
     * Đóng PopUp và Modal Form khi nhấn nút Đóng
     * CreatedBy: LNTHAO (10/08)
     */
    btnCloseModalForm() {
      eventBus.$emit("closePopUp", true);
      if (this.isWarning){
        this.isHideForm = true;
        eventBus.$emit("closePopUpAndModalForm", this.isHideForm);
        
      }
      else if (!this.isMessageDelete){
        eventBus.$emit("deletePerson", this.employee.EmployeeId);
      }
      else if (!this.isMessageDeleteMany) {
        eventBus.$emit("deleteAllChecked", this.idDelete);
      }
      this.message = "";
    },
  },

  data() {
    return {
      isHidePopup: true,
      isHideForm: true,
      isWarning: false,
      isDelete: false,
      isMessageWarning: true,
      isMessageDelete: true,
      isMessageDeleteMany: true,
      value: "",
      employee: {},
      message: "",
      idDelete: [],
      codeDelete: [],
    }
  },
};
</script>

<style scoped>
.popup-hidden {
  display: none;
}
.hide-message-warning{
  display: none;
}
.hide-message-delete{
  display: none;
}
.hide-message-delete-many{
  display: none;
}
</style>