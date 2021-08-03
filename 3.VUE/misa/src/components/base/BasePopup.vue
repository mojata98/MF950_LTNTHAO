<template>
    <div class="popup-container" :class="{'popup-hidden':isShow}">
        <div class="popup-header">
            <div class="btn-close">
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
                    <div class="popup-message">Bạn có chắc chắn muốn đóng <b>"Thông tin chung của thủ tục 603"</b> hay không?</div>
                </div>               
            </div>
        </div>
        <div class="popup-footer">
            <div class="button btnContinue">Tiếp tục nhập</div>
            <div class="button btnClose">Đóng</div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Popup',
}
</script>

<style scoped>
@import '../../css/base/popup.css';

.popup-hidden{
    display: none;
}
</style>