var formMode; // formMode = 1 : Thêm mới || formMode = 0 : Sửa thông tin
class BaseJS {
    constructor() {
        this.loadData();
        this.initEvents();
    }

    /**---------------------------------------
    * Tải dữ liệu cho bảng nhân viên từ API
    * Author: LNTHAO (20/07/2021)
    */
     loadData() {
        $("table #tbListDataEmployee").empty();
        // Lấy thông tin các cột
        var colums = $('table thead th'); // Đọc số lượng cột
        $.ajax(
            {
                url: "http://cukcuk.manhnv.net/v1/Employees", // viết hoa !== viết thường
                method: "GET",
                dataType: "json", // Tránh lỗi từ vòng lặp $.each
                async: false,
            }
        ).done(function (res) {
            $.each(res, function (index, obj) {
                var tr = $(`<tr employeeId = '${obj.EmployeeId}'></tr>`);
                $.each(colums, function (index, item) {
                    var td = $(`<td title = "` + obj[$(item).attr('fieldName')] + `"></td>`);
                    var fieldName = $(item).attr('fieldName');
                    var value = obj[fieldName];
                    var formatType = $(item).attr('formatType');
                    var textAlignType = $(item).attr('textAlignType');
                    switch (formatType) {
                        case "ddmmyyyy":
                            value = formatDate(value);
                            break;
                        case "Money":
                            value = formatMoney(value);
                            break;
                        default:
                            break;
                    }
                    switch (textAlignType) {
                        case "Center":
                            td.addClass('text-align-center');
                            break;
                        case "Right":
                            td.addClass("text-align-right");
                            break;
                        case "Left":
                            td.addClass("text-align-left");
                            break;
                        default:
                            break;
                    }
                    td.append(value);
                    $(tr).append(td);
                })
                $('table tbody').append(tr);
            })
        }).fail(function (res) {

        })
        var a = $('#tbListDataEmployee tr').length;
        document.getElementById('employeeTotal').innerHTML = a;
    }


    getDataUrl() {

    }

    setDataUrl() {

    }

    initEvents() {
        /**----------------------------------------------------------------------
         * Mở form thêm nhân viên, tạo sẵn mã NV, reset các trường thông tin cũ
         * Author: LNTHAO (21/07/2021)
         */
        $('#btnAdd').click(function () {
            formMode = 1;
            $('#dlgEmployeeDetail').show();
            $('#dlgEmployeeDetail input').val(null);
            $('#dlgEmployeeDetail .dropdown-list').hide();
            $('#dlgEmployeeDetail .dropdown-value').text(null);
            $('#dlgEmployeeDetail .icon-down').removeClass('move-up');
            $('#dlgEmployeeDetail input').removeClass('border-red');
            //lấy mã nhân viên mới và thực hiện binding vào input mã nhân viên
            try {
                $.ajax({
                    url: "http://cukcuk.manhnv.net/v1/Employees/NewEmployeeCode",
                    method: "GET",
                }).done(res => {
                    $('#txtEmployeeCode').val(res);
                    $('#txtEmployeeCode').focus();
                }).fail(res => {
                    console.log(res);
                })
            } catch (error) {
                console.log(error);
            }
        })

        /**-------------------------------
         * Load lại dữ liệu cho bảng
         * Author: LNTHAO (21/07/2021)
         */
        $("#btnRefresh").click(function () {
            location.reload();
        })

        /**----------------------------------------------------
        * Hàm thoát, hủy khỏi form dialog thông tin nhân viên
        * Author: LNTHAO (21/7/2021)
        */
        $("#btnCancel").click(function () {
            $('#dlgEmployeeDetail').hide();
            $('#dlgEmployeeDetail').parent().parent().find('.dropdown-item').removeClass('active');
            $('#dlgEmployeeDetail').parent().parent().find('.dropdown-list').hide();
            $('#dlgEmployeeDetail').parent().parent().find('.icon-down').removeClass('move-up');
        })

        /**----------------------------------------------------
        * Hàm thoát, hủy khỏi form dialog thông tin nhân viên
        * Author: LNTHAO (21/7/2021)
        */
        $("#btnExit").click(function () {
            $('#dlgEmployeeDetail').hide();
            $('#dlgEmployeeDetail').parent().parent().find('.dropdown-item').removeClass('active');
            $('#dlgEmployeeDetail').parent().parent().find('.dropdown-list').hide();
            $('#dlgEmployeeDetail').parent().parent().find('.icon-down').removeClass('move-up');
        })

        /**---------------------------------
        * Save - Lưu toàn bộ dữ liệu
        * Author: LNTHAO (22/7/2021)
        */
         $("#btnSave").click(function () {
            if ($('#txtEmployeeCode').val() == "" || $('#txtFullName').val() == "" ||
                $('#txtIdentityNumber').val() == "" || $('#txtEmail').val() == "" || $('#txtPhoneNumber').val() == "") {
                alert("Nhập thiếu trường thông tin bắt buộc");
                if ($('#txtEmployeeCode').val() == "") {
                    $('#txtEmployeeCode').addClass("border-red");
                }
                if ($('#txtFullName').val() == "") {
                    $('#txtFullName').addClass("border-red");
                }
                if ($('#txtIdentityNumber').val() == "") {
                    $('#txtIdentityNumber').addClass("border-red");
                }
                if ($('#txtEmail').val() == "") {
                    $('#txtEmail').addClass("border-red");
                }
                if ($('#txtPhoneNumber').val() == "") {
                    $('#txtPhoneNumber').addClass("border-red");
                }
            }
            else {
                // thu thập dữ liệu =) build thành object nhân viên
                let employee = {
                    "EmployeeId": "8efe3ae6-eb14-11eb-94eb-42010a8c0002",
                    "EmployeeCode": "NV01545",
                    "FirstName": null,
                    "LastName": null,
                    "FullName": "Mai Quỳnh",
                    "Gender": 0,
                    "DateOfBirth": null,
                    "PhoneNumber": "+844796868786",
                    "Email": "nho12@gmail.com",
                    "Address": null,
                    "IdentityNumber": "009988998899",
                    "IdentityDate": null,
                    "IdentityPlace": "HN",
                    "JoinDate": null,
                    "MartialStatus": null,
                    "EducationalBackground": null,
                    "QualificationId": null,
                    "DepartmentId": null,
                    "PositionId": null,
                    "WorkStatus": null,
                    "PersonalTaxCode": "23434343434",
                    "Salary": 1000000.0,
                    "PositionCode": null,
                    "PositionName": null,
                    "DepartmentCode": null,
                    "DepartmentName": null,
                    "QualificationName": null,
                    "GenderName": null,
                    "EducationalBackgroundName": null,
                    "MartialStatusName": null,
                    "CreatedDate": "2021-07-22T17:45:09",
                    "CreatedBy": null,
                    "ModifiedDate": "2021-07-22T18:01:04",
                    "ModifiedBy": null
                };
                if (formMode == 1 && isDuplicateIdentityNumber($('#txtIdentityNumber').val()) == false ) {
                    alert("Mã chứng minh thư/căn cước đã bị trùng");
                }
                else {// cập nhật dữ liệu
                    var salary = reFormatMoney($('#txtSalary').val());
                    employee.EmployeeCode = $('#txtEmployeeCode').val();
                    employee.FullName = $('#txtFullName').val();
                    employee.DateOfBirth = $('#txtDateOfBirth').val();
                    employee.Gender = $('#txtGender').attr('value');
                    employee.IdentityNumber = $('#txtIdentityNumber').val();
                    employee.IdentityDate = $('#txtIdentityDate').val();
                    employee.IdentityPlace = $('#txtIdentityPlace').val();
                    employee.Email = $('#txtEmail').val();
                    employee.PhoneNumber = $('#txtPhoneNumber').val();
                    employee.PositionId = $('#txtPositionName').attr('value');
                    employee.DepartmentId = $('#txtDepartmentName').attr('value');
                    employee.PersonalTaxCode = $('#txtPersonalTaxCode').val();
                    employee.Salary = salary;
                    employee.JoinDate = $('#txtJoinDate').val();
                    employee.WorkStatus = $('#txtWorkStatus').attr('value');
                    console.log(employee);
                    let tmethod = 'POST';
                    let turl = 'http://cukcuk.manhnv.net/v1/Employees';
                    if (formMode == 0) {
                        tmethod = 'PUT';
                        turl = `http://cukcuk.manhnv.net/v1/Employees/${employeeId}`;
                    }
                    $.ajax(
                        {
                            url: turl,
                            method: tmethod,
                            data: JSON.stringify(employee),
                            dataType: "json",
                            contentType: "application/json",
                        }
                    ).done(res => {
                        if (formMode == 0) {
                            alert("Sửa thành công");
                        }
                        else {
                            alert("Thêm mới thành công");
                        }
                        $('#dlgEmployeeDetail').hide();
                        location.reload();
                    }).fail(function (res) {
                        switch (res.status) {
                            case 500:
                                alert("Có lỗi, vui lòng liên hệ MISA!");
                                break;
                            case 400:
                                alert("Dữ liệu không hợp lệ!");
                                break;
                            default: break;
                        }
                    })
                }
            }
        })

        
    }

    

    

}

