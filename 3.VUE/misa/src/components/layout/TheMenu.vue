<template>
    <div class="menu">
        <div class="menu-item">
            <div class="menu-icon menu-icon-dashboard"></div>
            <div class="menu-item-text">Tổng quan</div>
        </div>
        <div class="menu-item">
            <div class="menu-icon menu-icon-report">
            </div>
            <div class="menu-item-text">Báo cáo</div>
        </div>

        <div class="menu-item">
            <div class="menu-icon menu-icon-dashboard"></div>
            <div class="menu-item-text">Mua hàng</div>
        </div>
        <div class="menu-item">
            <div class="menu-icon menu-icon-employee"></div>
            <div class="menu-item-text"><a href="customer.html">Danh mục khách hàng</a></div>
        </div>
        <div class="menu-item menu-item-active">
            <div class="menu-icon menu-icon-employee"></div>
            <div class="menu-item-text"><a href="employee.html">Danh mục nhân viên</a></div>
        </div>
        <div class="menu-item">
            <div class="menu-icon menu-icon-setting"></div>
            <div class="menu-item-text">Thiết kế hệ thống</div>
        </div>
        <div class="zoom-out-menu">
            <i class="fas fa-chevron-right" onclick="showMenu()" id="icon-right-menu" style="display: none;"></i>
            <i class="fas fa-chevron-left" onclick="zoomMenu()" id="icon-left-menu"></i>
        </div>
    </div>
</template>

<script>
export default {
    name: 'TheMenu',
}
</script>

<style scoped>
@import '../../css/layout/menu.css';
</style>