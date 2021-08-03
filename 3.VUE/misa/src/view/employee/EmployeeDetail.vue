<template>
    <div class="modal" id="modal" :class="{'m-dialog-hidden':isHide}" >
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
                                <label for="id" class="title-input" >Mã nhân viên (<span
                                        class="required">*</span>)</label>
                                <input type="text" id="txtEmployeeCode" required class="text-box-default" autofocus tabindex="1" v-model = "employee.EmployeeCode" />
                            </div>
                            <div class="input">
                                <label for="fullName" class="title-input" >Họ và tên (<span
                                        class="required">*</span>)</label>
                                <input type="text" id="txtFullName" required class="text-box-default" tabindex="2" v-model = "employee.FullName"/>
                                <span class="tooltiptext">Định dạng không hợp lệ.</span>
                            </div>
                            <div class="input">
                                <label for="birthOfDay" class="title-input date" >Ngày sinh</label>
                                <input type="date" id="txtDateOfBirth" class="text-box-default" tabindex="3" v-model = "employee.DateOfBirth"/>
                            </div>
                            
                        
                            <div class="input">
                                    <div class="filter-department title-input " tabindex="4" >
                                        <label for="general" class="title-input" >Giới tính</label>
                                        <label class="dropdown dropdown-department dropdownForm" name="department">
                                        <div class="dropdown-header-wrapper ">
                                            <span class="dropdown-value" id="txtGender">
                                                Nam
                                            </span>
                                            <i class="fas fa-chevron-down icon-down"></i>
                                        </div>
                                        <ul class="dropdown-list"></ul>
                                        </label>
                                    </div>
                            </div>
                            <div class="input">
                                <label for="CMTND" class="title-input identityCode" title="Số CMTND/ Căn cước">Số CMTND/ Căn cước (<span
                                        class="required ">*</span>)</label>
                                <input type="text" id="txtIdentityNumber" required class="text-box-default" tabindex="5" v-model = "employee.IdentityNumber"/>
                            </div>
                            <div class="input">
                                <label for="dayOfCMTND" class="title-input">Ngày cấp </label>
                                <input type="date" id="txtIdentityDate" class="text-box-default" tabindex="6" v-model = "employee.IdentityDate"/>
                            </div>
                            <div class="input custom-input" id="txtIdentityPlace1">
                                <label for="addressOfCMTND" class="title-input" >Nơi cấp</label>
                                <input type="text" id="txtIdentityPlace" class="text-box-default" tabindex="7" v-model = "employee.IdentityPlace"/>
                            </div>
                            <div class="input" style="display: none; position: fixed;">
                                <label for="dayOfCMTND" class="title-input"></label>
                                <input type="date" id="dayOfCMTND1" class="text-box-default"/>
                            </div>
                            <div class="input">
                                <label for="email" class="title-input" >Email(<span class="required">*</span>)</label>
                                <input type="text" id="txtEmail" placeholder="example@domain" required class="text-box-default" tabindex="8" v-model = "employee.Email"/>
                            </div>
                            <div class="input">
                                <label for="phone" class="title-input" >Số điện thoại(<span
                                        class="required">*</span>)</label>
                                <input type="text" id="txtPhoneNumber" required class="text-box-default" tabindex="9" v-model = "employee.PhoneNumber"/>
                            </div>
                            <!-- ========================================================Information Title================================================================ -->
                            <div class="infomation-title">
                                <span class="text"> B. Thông tin công việc: </span>
                            </div>
                            
                            <div class="input">
                                <div class="filter-department title-input dropdownForm" tabindex="10" >
                                        <label for="general" class="title-input" >Vị trí</label>
                                        <label class="dropdown dropdown-department dropdownForm" name="department">
                                        <div class="dropdown-header-wrapper">
                                            <span class="dropdown-value" id="txtPositionName">
                                                Giám đốc
                                            </span>
                                            <i class="fas fa-chevron-down icon-down"></i>
                                        </div>
                                        <ul class="dropdown-list"></ul>
                                        </label>
                                    </div>
                            </div>
                            
                            <div class="input">
                                <div class="filter-department title-input dropdownForm" tabindex="11" >
                                        <label for="general" class="title-input" >Phòng ban</label>
                                        <label class="dropdown dropdown-department dropdownForm" name="department">
                                        <div class="dropdown-header-wrapper">
                                            <span class="dropdown-value" id="txtDepartmentName">
                                                Phòng hậu cần
                                            </span>
                                            <i class="fas fa-chevron-down icon-down"></i>
                                        </div>
                                        <ul class="dropdown-list"></ul>
                                        </label>
                                    </div>
                            </div>
                            <div class="input taxCode">
                                <label for="taxCode" class="title-input" >Mã số thuế cá nhân</label>
                                <input type="text" id="txtPersonalTaxCode" class="text-box-default" tabindex="12" v-model = "employee.PersonalTaxCode"/>
                            </div>
                            <div class="input salary-base">
                                <label for="salary" class="title-input" >Mức lương cơ bản</label>
                                <div class="salary">
                                    <input type="text" id="txtSalary" class="text-box-default" tabindex="13" v-model = "employee.Salary"/>
                                    <span class="icon">(VNĐ)</span>
                                </div>
                            </div>
                            <div class="input">
                                <label for="dayOfJoin" class="title-input">Ngày gia nhập công ty</label>
                                <input type="date" id="txtJoinDate" required class="text-box-default" tabindex="14" v-model = "employee.JoinDate"/>
                            </div>
                            
                            <div class="input">
                                <div class="filter-department title-input   " tabindex="15" >
                                        <label for="general" class="title-input" >Tình trạng công việc</label>
                                        <label class="dropdown dropdown-department dropdownForm" name="department">
                                        <div class="dropdown-header-wrapper">
                                            <span class="dropdown-value" id="txtGender">
                                                Đang làm việc
                                            </span>
                                            <i class="fas fa-chevron-down icon-down"></i>
                                        </div>
                                        <ul class="dropdown-list"></ul>
                                        </label>
                                    </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </form>
            <!-- ========================================================Footer================================================================ -->
            <div class="modal-footer">
                <button class="btn-cancel button" tabindex="16" id="btn-cancel" v-on:click="btnCloseForm()">Hủy</button>
                <button class="btn-save button-icon button" tabindex="17" v-on:click="btnSave()">
                    <span class="icon-left"></span>
                    <span class="text" id="btn-save">Lưu</span>
                </button>
            </div>

        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default ({
    methods: {
        btnCloseForm(){
            // this.isHide = true; // khôg nên có 
            this.$emit('isHideUpdated',true);
        },
        /**
         * Lưu dữ liệu - Thêm mới dữ liệu
         * Author: LNTHAO (01/08/2021)
         */
        btnSave(){
            if (this.mode == 0) {
                let vm = this;
                // Gọi API lấy dữ liệu
                axios.post(`http://cukcuk.manhnv.net/v1/Employees`, vm.employee).then(res =>{
                    alert("Thêm mới thành công.");
                    console.log(res);
                }).catch(res =>{
                    console.log(res);
                });
            } else {
                let vm = this;
                // Gọi API lấy dữ liệu
                axios.put(`http://cukcuk.manhnv.net/v1/Employees/${vm.employeeId}`, vm.employee).then(res =>{
                    alert("Sửa thành công.");
                    console.log(res);
                }).catch(res =>{
                    console.log(res);
                });
            }
            this.$emit('isHideUpdated',true);
            window.$forceUpdate();
            console.log(this);
        }
    },
    setup() {
        
    },
    props: {
        isHide:{ // chi duoc doc khong duoc sua 
            type: Boolean,
            default: true,
            required: true
        },
        employeeId:{
            type: String,
            // default: '',
            // required: true,
        },
        mode: {
            type: Number,
            required: true,
            default: 0, // 0 - Thêm mới, 1 - Sửa thông tin
        }
    },
    data() {
        return {
            employee: {},
        }
    },
    watch:{
        /**------------------------------
        * Lấy dữ liệu cho bảng từ API
        * Author: LNTHAO (29/07/2021)
        */
        employeeId: function(value) {
            // alert("watch: " + this.employeeId);
            let vm = this;
            // Gọi API lấy dữ liệu
            axios.get(`http://cukcuk.manhnv.net/v1/Employees/${value}`).then(res =>{
                // console.log(res.data);
                vm.employee = res.data;
            }).catch(res =>{
                console.log(res);
            });
        },

        mode: function(){
            if (this.mode == 0) {
                this.employee = {};
            }
        }
    },
    computed:{
        testEmployeeId: function(){
            return this.employeeId;
        }
    }
})

</script>

<style scoped>
/* @import '../../css/layout/modal-form.css'; */
</style>