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
          <div class="popup-icon popup-icon-warning"></div>
        </div>
        <div class="popup-message-contain">
          <div class="popup-message">
            Bạn có chắc chắn muốn đóng <b>"Thông tin nhân viên"</b> hay không?
          </div>
        </div>
      </div>
    </div>
    <div class="popup-footer">
      <div class="button btnContinue" @click="btnClosePopupForm()">Tiếp tục nhập</div>
      <div class="button btnClose" @click="btnCloseModalForm()">Đóng</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Popup",

  props: {
    isHidePopup: {
      // chi duoc doc khong duoc sua
      type: Boolean,
      default: true,
      // required: true,
    },

    isHide:{ // chi duoc doc khong duoc sua 
        type: Boolean,
        default: false,
        // required: true,
    },
  },

  methods: {
    btnCloseModalForm() {
      // this.isHide = true; // khôg nên có
      this.$emit("isHideUpdated", true);//????
      this.$emit("isHidePopupUpdated", true);
    },

    btnClosePopupForm(){
      this.$emit("isHidePopupUpdated", true);
    },
  },
};
</script>

<style scoped>
.popup-hidden {
  display: none;
}
</style>