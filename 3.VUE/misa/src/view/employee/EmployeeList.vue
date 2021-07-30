<template>
  <div class="content">
        <div class="content-title">
            <div class="content-title-text">Danh sách nhân viên</div>
            <div class="button-new" id="btnAdd" > <!--onclick="btnAddOnClick();"-->
                <div class="button-icon"></div>
                <div class="button-value" @click="btnAddOnClick()">Thêm nhân viên</div>
            </div>
        </div>
        <div class="filter">
            <div class="filter-search">
                <input type="text" placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
                    onfocus="this.placeholder = ''" style="width: 270px;" class="icon-search
                        input-search" tabindex="1" name="inputSearch" id="txtSearch">
                <button class="btn-reset" style="display: none;">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none"
                        stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                        class="feather feather-x">
                        <line x1="18" y1="6" x2="6" y2="18"></line>
                        <line x1="6" y1="6" x2="18" y2="18"></line>
                    </svg>
                </button>
            </div>
            <div class="filter-department" tabindex="2">
                <label class="dropdown dropdown-department" name="department">
                    <div class="dropdown-header-wrapper">
                        <span class="dropdown-value" id="drdValueDepartment">
                            Tất cả phòng ban
                        </span>
                        <i class="fas fa-chevron-down icon-down"></i>
                    </div>
                    <ul class="dropdown-list">
                    </ul>
                </label>
            </div>
            <div class="filter-position" id="pos">
                <label class="dropdown dropdown-position" name="position" style="margin-left: 16px;">
                    <div class="dropdown-header-wrapper">
                        <span class="dropdown-value" id="drdValuePosition">
                            Tất cả vị trí
                        </span>
                        <i class="fas fa-chevron-down icon-down"></i>
                    </div>
                    <ul class="dropdown-list">
                    </ul>
                </label>
            </div>
            <div class="refresh" id="btnRefresh"> <!--onclick="btnRefresh()"-->
                <div class="button-refresh">
                </div>
            </div>
        </div>
        <div class="content-table">
            <table class="table table-striped" style="width: 100%;" id="tbListDataEmployee">
                <thead>
                    <tr>
                        <th scope="col" fieldName = "EmployeeCode" textAlignType = "Left">Mã nhân viên</th>
                        <th scope="col" fieldName = "FullName" textAlignType = "Left">Họ và tên</th>
                        <th scope="col" fieldName = "GenderName" textAlignType = "Left">Giới tính</th>
                        <th scope="col" class="text-align-center" fieldName = "DateOfBirth" textAlignType = "Center" formatType = "ddmmyyyy">Ngày sinh</th>
                        <th scope="col" fieldName = "PhoneNumber" textAlignType = "Left">Điện thoại</th>
                        <th scope="col" style="width: 100px;" fieldName = "Email" textAlignType = "Left"><span style="width: 100px;">Email</span></th>
                        <th scope="col" fieldName = "PositionName" textAlignType = "Left">Chức vụ</th>
                        <th scope="col" fieldName = "DepartmentName" textAlignType = "Left">Phòng ban</th>
                        <th scope="col" class="text-align-right" fieldName = "Salary" textAlignType = "Right" formatType = "Money">Mức lương cơ bản</th>
                        <th scope="col" fieldName = "WorkStatus" textAlignType = "Left">Tình trạng công việc</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="employee in employees" :key="employee.EmployeeId" v-on:dblclick="fixInfor(employee.EmployeeId)">
                        <td>{{employee.EmployeeCode}}</td>
                        <td>{{employee.FullName}}</td>
                        <td>{{employee.GenderName}}</td>
                        <td>{{employee.DateOfBirth}}</td>
                        <td>{{employee.PhoneNumber}}</td>
                        <td>{{employee.Email}}</td>
                        <td>{{employee.PositionName}}</td>
                        <td>{{employee.DepartmentName}}</td>
                        <td>{{employee.Salary}}</td>
                        <td>{{employee.WorkStatus}}</td>                        
                    </tr>
                </tbody>
            </table>
        </div>
        <!-------------------------------------------------------FOOTER-------------------------------------------------------->
        <div class="footer ">
            <div class="footer-left ">Hiển thị <b id="employeeTotal">1-10/1000</b> nhân viên</div>
            <div class="pagination ">
                <div class="footer-middle ">
                    <a href="# " class="pagination-firstpage "></a>
                    <a href="# " class="pagination-prevpage "></a>
                    <a href="# " class="page-number">1</a>
                    <a class="active page-number" href="# ">2</a>
                    <a href="# " class="page-number">3</a>
                    <a href="# " class="page-number">4</a>
                    <a href="# " class="pagination-nextpage "></a>
                    <a href="# " class="pagination-lastpage "></a>
                </div>
            </div>
            <div class="footer-right ">10 nhân viên/trang</div>
        </div>
        <EmployeeDetail v-bind:isHide="isHide" @isHideUpdated = "isHide = $event" />
  </div>
</template>

<script>
import axios from 'axios';
import EmployeeDetail from '../employee/EmployeeDetail.vue';
export default {
    name: "EmployeePage",
    components: {EmployeeDetail},

    /**------------------------------
     * Sinh dữ liệu cho bảng từ API
     * Author: LNTHAO (29/07/2021)
     */
    mounted() {
        var vm = this;
        // Gọi API lấy dữ liệu
        axios.get("http://cukcuk.manhnv.net/v1/Employees").then(res =>{
            console.log(res);
            vm.employees = res.data;
        }).catch(res =>{
            console.log(res);
        })
    },

    methods: {
        btnAddOnClick(){
            this.isHide = false;
        },
        fixInfor(employeeId){
            alert(employeeId);
            this.isHide = false;
            this.employeeId = employeeId;
        },
    },
    data() {
        return {
            employees: [],
            header: [], 
            employeeId: '',
            isHide: true,
        }
    },
};
</script>

<style scoped>
/* @import '../../css/layout/content.css'; */
@import '../../css/layout/modal-form.css';
</style>