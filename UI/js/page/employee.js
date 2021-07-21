$(document).ready(function () {
    // new EmployeeJS();
    loadData();
})

/**--------------------------------------
 * Class quản lý các sự kiện cho Emloyee
 * CreatedBy: LNTHAO (20/07/2021)
 */
// class EmployeeJS extends BaseJS{
//     constructor() {
//         // this.loadData();
//         super();
//     }
//     // /**--------------------------------------
//     // * Load dữ liệu cho trang Employee
//     // * CreatedBy: LNTHAO (20/07/2021)
//     // */
//     // loadData() {
//     //     //lấy dữ liệu về
//     // $.ajax({
//     //     url: "http://cukcuk.manhnv.net/v1/Employees",
//     //     method: "GET",
//     //     data: ''// Tham số sẽ truyền lên cho API qua body request ( nếu ko có có thể bỏ qua)
//     //     // datatype : json
//     //     // contentType: 'json' //kiểu dữ liệu trả về 
//     //     // async : True, đồng bộ/ bất đồng bộ   
//     // }).done(function (res) {
//     //     // Xử lý dữ liệu
//     //     // Hiển thị dữ liệu lên table 
//     //     var data = res;
//     //     $.each(data, function (index, item) {
//     //         var dateOfBirth = item["DateOfBirth"];
//     //         var salary = item["Salary"];
//     //         var dateStr = formatDate(dateOfBirth);
//     //         var money = formatMoney(salary);
//     //         var checkbox = `<input type = "checkbox"/>`;
//     //         if (item.WorkStatus > 5) {
//     //             var checkbox = `<input type = "checkbox" checked/>`;
//     //         }
//     //         var tr = $(`<tr>
//     //                         <td class="text-align-center" style="max-width: 60px " >`+ checkbox + `</td>
//     //                         <td class="text-align-left" style="max-width: 100px" title = "item.EmployeeCode">`+ item.EmployeeCode + `</td>
//     //                         <td class="text-align-left" style="max-width: 150px" title = "`+ item['FullName'] + `">` + item['FullName'] + `</td>
//     //                         <td class="text-align-center" style="max-width: 60px " title = "`+ item['GenderName'] + `">` + item['GenderName'] + `</td>
//     //                         <td class="text-align-center" style="max-width: 100px" title = "`+ dateStr + `">` + dateStr + `</td>
//     //                         <td class="text-align-left" style="max-width: 100px" title = "`+ item['PhoneNumber'] + `">` + item['PhoneNumber'] + `</td>
//     //                         <td class="text-align-left" style="max-width: 100px" title = "`+ item['PhoneNumber'] + `">` + item['Email'] + `</td>
//     //                         <td class="text-align-left" style="max-width: 150px" title = "`+ item['PositionName'] + `">` + item['PositionName'] + `</td>
//     //                         <td class="text-align-left" style="max-width: 150px" title = "`+ item['DepartmentName'] + `">` + item['DepartmentName'] + `</td>
//     //                         <td class="text-align-right" style="max-width: 100px" title = "`+ money + `">` + money + `</td>
//     //                         <td class="text-align-left" style="max-width: 100px" title = "`+ item['WorkStatus'] + `">` + item['WorkStatus'] + `</td>

//     //                     </tr>`);
//     //         $('table tbody').append(tr);
//     //         debugger;
//     //     })
//     // }).fail(function (res) {
//     //     // API trả về lỗi - đưa ra thông báo lỗi cụ thể : tùy theo HttpCode - 400, 404, 500
//     //     // Thông thường thì:
//     //     // Mã 400: BadRequest- lỗi dữ liệu đầu vào từ client
//     //     // 404: Địa chỉ url không hợp lệ
//     //     // 500: Lỗi từ phía backend (bên server) 
//     //     alert("Có lỗi xảy ra vui lòng liên hệ MISA")
//     // })
//     // //binding dữ liệu
//     // }
//     // /**--------------------------------------
//     // * Thêm mới nhân viên
//     // * CreatedBy: LNTHAO (20/07/2021)
//     // */
//     // add() {

//     // }
//     // /**--------------------------------------
//     // * Sửa thông tin nhân viên
//     // * CreatedBy: LNTHAO (20/07/2021)
//     // */
//     // edit() {

//     // }
//     // /**--------------------------------------
//     // * Xóa thông tin nhân viên
//     // * CreatedBy: LNTHAO (20/07/2021)
//     // */
//     // delete() {

//     // }
// }







/**--------------------------------------
* Load dữ liệu cho trang Employee
* CreatedBy: LNTHAO (20/07/2021)
*/
function loadData() {
    // clean table
    $('tbody').empty();
    //lấy dữ liệu về
    $.ajax({
        url: "http://cukcuk.manhnv.net/v1/Employees",
        method: "GET",
        data: ''// Tham số sẽ truyền lên cho API qua body request ( nếu ko có có thể bỏ qua)
        // datatype : json
        // contentType: 'json' //kiểu dữ liệu trả về 
        // async : True, đồng bộ/ bất đồng bộ   
    }).done(function (res) {
        // Xử lý dữ liệu
        // Hiển thị dữ liệu lên table 
        var data = res;
        $.each(data, function (index, item) {
            var dateOfBirth = item["DateOfBirth"];
            var salary = item["Salary"];
            var dateStr = formatDate(dateOfBirth);
            var money = formatMoney(salary);
            var checkbox = `<input type = "checkbox"/>`;
            if (item.WorkStatus > 5) {
                var checkbox = `<input type = "checkbox" checked/>`;
            }
            var tr = $(`<tr employeeId = '${item.EmployeeId}'>
                            <td class="text-align-center" style="max-width: 60px " >`+ checkbox + `</td>
                            <td class="text-align-left" style="max-width: 100px" title = "item.EmployeeCode">`+ item.EmployeeCode + `</td>
                            <td class="text-align-left" style="max-width: 150px" title = "`+ item['FullName'] + `">` + item['FullName'] + `</td>
                            <td class="text-align-center" style="max-width: 60px " title = "`+ item['GenderName'] + `">` + item['GenderName'] + `</td>
                            <td class="text-align-center" style="max-width: 100px" title = "`+ dateStr + `">` + dateStr + `</td>
                            <td class="text-align-left" style="max-width: 100px" title = "`+ item['PhoneNumber'] + `">` + item['PhoneNumber'] + `</td>
                            <td class="text-align-left" style="max-width: 100px" title = "`+ item['PhoneNumber'] + `">` + item['Email'] + `</td>
                            <td class="text-align-left" style="max-width: 150px" title = "`+ item['PositionName'] + `">` + item['PositionName'] + `</td>
                            <td class="text-align-left" style="max-width: 150px" title = "`+ item['DepartmentName'] + `">` + item['DepartmentName'] + `</td>
                            <td class="text-align-right" style="max-width: 100px" title = "`+ money + `">` + money + `</td>
                            <td class="text-align-left" style="max-width: 100px" title = "`+ item['WorkStatus'] + `">` + item['WorkStatus'] + `</td>                           
                        </tr>`);
            $('table tbody').append(tr);
            debugger;
        })
    }).fail(function (res) {
        // API trả về lỗi - đưa ra thông báo lỗi cụ thể : tùy theo HttpCode - 400, 404, 500
        // Thông thường thì:
        // Mã 400: BadRequest- lỗi dữ liệu đầu vào từ client
        // 404: Địa chỉ url không hợp lệ
        // 500: Lỗi từ phía backend (bên server) 
        alert("Có lỗi xảy ra vui lòng liên hệ MISA")
    })
    //binding dữ liệu
}
//--------------------------------------------------------------------



/** ----------------------------
 * Ẩn hiện form thêm mới khi ấn vào nút X/nút Hủy/nút Thêm mới nhân viên
 * Author: LNTHAO (21/07/2021)
 */
$('#add-btn').click(function () {
    $('#modal').show();
    $('input[required]').addClass('border-default');
    $('#modal input').val(null);

    // Lấy mã nhân viên mới đưa vào form mỗi lần thêm mới
    $.ajax(
        {
            url: "http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode",
            method: "GET",
        }
    ).done(res => {
        $('#txtEmployeeCode').val(res);
        $('#txtEmployeeCode').focus();
    }).fail(res => {
        alert("Xảy ra lỗi, vui lòng liên hệ MISA");
    })
})

$('#btn-close').click(function () {
    $('#modal').hide();
})

$('#btn-cancel').click(function () {
    $('#modal').hide();
})
// ---------------------------------




/** ----------------------------
 * Validate các ô nhập vào
 * Author: LNTHAO (21/07/2021)
 */
$('input[required]').blur(function () {
    //Kiểm tra thông tin có nhập vào hay không
    let value = $(this).val();
    if (value == '') {
        // Thay đổi border của input sang trạng thái lỗi
        $('input[required]').removeClass('border-default');
        $(this).addClass('border-red');
        $(this).attr('title', 'Thông tin bắt buộc nhập');
    }
    else {
        $(this).removeClass('border-red');
        $(this).css('background-color', '#ffffff');
        $(this).removeAttr('title');
    }
})

// ---------------------------------




/** ----------------------------
 * Validate email
 * Author: LNTHAO (21/07/2021)
 */
function ValidateEmail(inputText) {
    var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (inputText.value.match(mailformat)) {
        // alert("Mail đúng!");
        // document.form1.text1.focus();
        return true;
    }
    else {
        // alert("Vui lòng nhập địa chỉ mail hợp lệ!");
        // document.form1.text1.focus();
        return false;
    }
}
//------------------------------------



// $('#txtEmployeeEmail').blur(function () {
//     let value = $('txtEmployeeEmail').val();
//     if (value){
//         if (ValidateEmail(value)){
//             alert("Mail đúng!");
//         } else{
//             alert("Vui lòng nhập địa chỉ mail hợp lệ!");
//         }
//     }    
//     else{

//     }
// })




/**
 * Thêm mới nhân viên
 * Author: LNTHAO (21/07/2021)
 */
$('#btn-save').click(function () {
    
    let employee = {
        "EmployeeId": "8e6894a6-ea0b-11eb-94eb-42010a8c0002",
        "EmployeeCode": "mf78787",
        "FirstName": null,
        "LastName": null,
        "FullName": "Nguyen Van Q",
        "Gender": 2,
        "DateOfBirth": null,
        "PhoneNumber": "121211",
        "Email": "q@gmail.com",
        "Address": null,
        "IdentityNumber": "12121",
        "IdentityDate": null,
        "IdentityPlace": "",
        "JoinDate": null,
        "MartialStatus": null,
        "EducationalBackground": null,
        "QualificationId": null,
        "DepartmentId": "17120d02-6ab5-3e43-18cb-66948daf6128",
        "PositionId": "548dce5f-5f29-4617-725d-e2ec561b0f41",
        "WorkStatus": 0,
        "PersonalTaxCode": "",
        "Salary": null,
        "PositionCode": "P94",
        "PositionName": "Nhân viên",
        "DepartmentCode": "PB89",
        "DepartmentName": "Phòng đào tạo",
        "QualificationName": null,
        "GenderName": "Không xác định",
        "EducationalBackgroundName": null,
        "MartialStatusName": null,
        "CreatedDate": "2021-07-21T10:08:11",
        "CreatedBy": null,
        "ModifiedDate": null,
        "ModifiedBy": null
    };

    employee.EmployeeCode = $('#txtEmployeeCode').val();
    employee.FullName = $('#txtEmployeeName').val();
    employee.DateOfBirth = $('#txtEmployeeDob').val();
    employee.GenderName = $('#txtEmployeeGender').val();
    employee.IdentityNumber = $('#txtEmployeeCMND').val();
    employee.IdentityDate = $('#dayOfCMTND').val();
    employee.IdentityPlace = $('#txtEmployeePlace').val();
    employee.Email = $('#txtEmployeeEmail').val();
    employee.PhoneNumber = $('#txtEmployeePhoneNumber').val();
    employee.PositionName = $('#txtEmployeePositionName').val();
    employee.DepartmentName = $('#txtEmployeeDepartmentName').val();
    employee.PersonalTaxCode = $('#txtEmployeeTaxCode').val();
    employee.Salary = $('#txtEmployeeSalary').val();
    employee.JoinDate = $('#dayOfJoin').val();
    employee.WorkStatus = $('#txtEmployeeWorkStatus').val();

    $.ajax(
        {
            url: "http://cukcuk.manhnv.net/v1/Employees",
            method: "POST",
            data: JSON.stringify(employee),
            dataType: "json",
            contentType: "application/json",
        }
    ).done(res => {
        alert("Thêm mới thành công.");
        $('#modal').hide();
        loadData();
    }).fail(res => {
        alert("Có lỗi, vui lòng liên hệ MISA!");
    })
})
//----------------------------------------------------------------------------






/**
 * Nút refresh
 * Author: LNTHAO (21/07/2021)
 */
$('#btn-refresh').click(function (){
    loadData();
})
//----------------------------------------



/**
 * Sửa dữ liệu
 * Author: LNTHAO (21/07/2021)
 */
$('table#EmployeeList').on('dblclick','tbody tr', function() {
    try {
        $('#modal').show();

        // Lấy ID
        const employeeID = $(this).attr('employeeId');
        $.ajax(
            {
                url: `http://cukcuk.manhnv.net/v1/Employees/${employeeID}`,
                method: "GET",
            }
        ).done(function(res) {
            $('#txtEmployeeCode').val(res['EmployeeCode']);
            $('#txtEmployeeName').val(res['FullName']);
            $('#txtEmployeeDob').val(res['DateOfBirth']);
            $('#txtEmployeeGender').val(res['GenderName']);
            $('#txtEmployeeCMND').val(res['IdentityNumber']);

            $('#dayOfCMTND').val(res['IdentityDate']);
            $('#txtEmployeePlace').val(res['IdentityPlace']);
            $('#txtEmployeeEmail').val(res['Email']);
            $('#txtEmployeePhoneNumber').val(res['PhoneNumber']);
            $('#txtEmployeePositionName').val(res['PositionName']);

            $('#txtEmployeeDepartmentName').val(res['DepartmentName']);
            $('#txtEmployeeTaxCode').val(res['PersonalTaxCode']);
            $('#txtEmployeeSalary').val(res['Salary']);
            $('#dayOfJoin').val(res['JoinDate']);
            $('#txtEmployeeWorkStatus').val(res['WorkStatus']);
        }).fail(function(res) {

        })
    } catch (error) {
        // Lỗi
    }
})
