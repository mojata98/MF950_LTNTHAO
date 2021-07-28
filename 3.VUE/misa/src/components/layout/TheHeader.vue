<template>
    <div class="header">
        <div class="header-left">
            <div class="toggle"></div>
            <div class="logo"></div>
        </div>
        <div class="header-right">
            <div class="header-title">
                <div class="filter-store">
                    <label class="dropdown store" date-type="store" style="width: 200px; font-size: 15px;border: none;">
                        <div class="dropdown-header-wrapper">
                            <span class="dropdown-value " style=" padding-left: 0px;">
                                Nhà hàng Biển Đông
                            </span>
                            <i class="fas fa-chevron-down icon-down "></i>
                        </div>
                        <ul class="dropdown-list" style="width: 200px;">
                            <li class="dropdown-item">Nhà Hàng Biển Đông</li>
                            <li class="dropdown-item">Nhà Hàng Biển Tây</li>
                            <li class="dropdown-item">Nhà Hàng Biển Nam</li>
                            <li class="dropdown-item">Nhà Hàng Biển Bắc</li>
                        </ul>
                    </label>
                </div>
            </div>
            <div class="header-info">
                <div class="announce">
                    <i class="far fa-bell"></i>
                </div>
                <div class="avatar"></div>
                <div class="info-name">Mai Anh Bảo</div>
                <div class="option"></div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  name: 'TheHeader',
  
}
</script>

<style scoped>
@import '../../css/layout/header.css';
</style>