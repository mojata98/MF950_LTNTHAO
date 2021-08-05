<template>
    <div>
        <div class="content-table">
            <table class="table table-striped" style="width: 100%;" id="tbListDataEmployee">
                <thead>
                    <tr>
                        <th scope="col" fieldName = "Checkbox" textAlignType = "Center"><input type="checkbox" class="checkbox"></th>
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
                        <th scope="col" fieldName = "Action" textAlignType = "Center"></th>
                    </tr>
                </thead>
                <tbody >
                    
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Table',
}
</script>

<style scoped>
@import '../../css/base/table.css';
</style>