var formMode;

/**------------------------------------------------------
 * Chuyển dữ liệu ngày tháng sang ngày/tháng/năm
 * @param {any} date bất cứ kiểu dữ liệu gì
 * Author: LNTHAO (19/7/2021)
 */
function formatDate(date) {
    var dateStr = '';
    if (date != null || date != undefined) {
        var date = new Date(date);
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : day;//chuỗi + số ra chuỗi =))
        result = day + '/' + month + '/' + year;
    }
    else {
        result = '';
    }
    return result;
}

/**----------------------------------------------------
 * Hàm định dạng hiển thị tiền tệ
 * @param {Number} money số tiền
 * Author: LNTHAO (26/7/2021) 
 */

function formatMoney(money) {
    if (money != null || money != undefined) {
        // var num = money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return Number(money).toLocaleString('vi');
    }
    else {
        return '';
    }
}

/**-------------------------------------
 * Hàm bỏ các giá trị null cho giới tính
 * @param {String} gender giới tính
 * Author: LNTHAO (19/7/2021) 
 */
function formatGender(gender) {
    var valueG = '';
    for (var i = 0; i < dataGender.length; i++) {
        if (dataGender[i].index == gender) {
            valueG = dataGender[i].value;
            break;
        }
        else {
            valueG = '';
        }
    }

    return valueG;
}

/**--------------------------------------------------------------
 * Hàm click chọn item trong menu làm đổi style cho menu và item
 * Author: LNTHAO (20/7/2021)
 */
$('.menu .menu-item').click(function () {
    $('.menu .menu-item').removeClass('menu-item-active');
    $(this).addClass('menu-item-active');
})

/**------------------------------------------
 * Hiển thị nút x cho input tìm kiếm
 * Author: LNTHAO (20/7/2021)
 */
$('input.icon-search').focus(function () {
    $('button.btn-reset').show();
})

/**----------------------------------------
 * Set lại giá trị input khi click nút x
 * Author: LNTHAO (20/7/2021)
 */
$('.btn-reset').on('click', function(){
    $('input.icon-search').val('');
    $('input.icon-search').attr("placeholder", "Tìm kiếm theo Mã, Tên hoặc Số điện thoại");
    $('button.btn-reset').hide();
});


/**-----------------------------------------
 * Hàm thu nhỏ menu
 * Author: LNTHAO (20/7/2021)
 */
function zoomMenu() {
    $('.menu-item-text').hide();
    $('.menu').addClass("menu-shrink");
    $('.content').addClass("content-expand");
    $('#icon-left-menu').hide();
    $('#icon-right-menu').show();
}

/**---------------------------
 * Hàm mở rộng menu
 * Author: LNTHAO (20/7/2021)
 */
function showMenu() {
    $('.menu').removeClass("menu-shrink");
    $('.menu-item-text').show();
    $('.content').removeClass("content-expand");
    $('#icon-left-menu').show();
    $('#icon-right-menu').hide();
}


/**----------------------------------------
 * Validate dữ liệu
 * Author: LNTHAO (21/7/2021)
 */
$('input[required]').blur(function () {
    let value = $(this).val();
    if (value == '') {
        //thay đổi border sang màu đỏ
        $(this).addClass('border-red');
        $(this).attr('title', "Thông tin bắt buộc phải nhập")
    }
    else {
        $(this).removeClass("border-red")
        $(this).removeAttr('title');
    }
})
$('input[type="email"]').blur(function () {
    let value = $(this).val();
    if (!isEmail(value)) {
        alert("Sai định dạng email!");
        $(this).addClass('border-red');
    }
})
$('#txtIdentityNumber').blur(function () {
    let value = $(this).val();
    if (!isIdentityNumber(value)) {
        alert("Số chứng minh thư phải 9 số, căn cước 12 số!")
        $(this).addClass('border-red');
    }
})

/**-----------------------------
 * Định dạng cho email
 * Author: LNTHAO (22/7/2021)
 */
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

/**----------------------------------
 * Định dạnh cho CMND
 * Author: LNTHAO (22/7/2021)
 */
function isIdentityNumber(cmt) {
    var regex = /^([0-9]{9}|[0-9]{12})+$/;
    if (!regex.test(cmt)) {
        return false;
    } else {
        return true;
    }
}





/**---------------------------
 * Hàm load lại trang
 * Author: LNTHAO (20/7/2021)
 */

// function btnRefresh() {
//     location.reload();
// }

/**----------------------------------------------
 * Hàm kiểm tra có bị trùng mã nhân viên không
 * @param code mã nhân viên  
 * Author: LNTHAO (23/7/2021)
 */
function isDuplicateCode(code) {
    $.each(dataEmployees, function (index, item) {
        if (item.EmployeeCode == code) {
            return true;
        }
        else {
            return false;
        }
    })

}

/**------------------------------------------------
 * Hàm kiểm tra có bị trùng CMND
 * @param num số chứng minh thư/căn cước công dân
 * Author: LNTHAO (23/7/2021)
 */
function isDuplicateIdentityNumber(num) {
    $.each(dataEmployees, function (index, item) {
        if (item.IdentityNumber == num) {
            return true;
        }
        else {
            return false;
        }
    })

}


/**-----------------------------------------
 * Hàm chuyển về dạng số thuần để lưu lương
 * @param {string} str 
 * Author: LNTHAO (23/07/2021)
 */
function reFormatMoney(str) {
    str += "";
    if (str != null) {
        str.replaceAll(".", "");
        let onlynumber = '';
        for (let i = 0; i < str.length; i++) {
            if (!isNaN(parseInt(str[i], 10))) {
                onlynumber += str[i];
            }
        }
        return onlynumber;
    }
    return 0;
}

moneyInput($('#txtSalary'));

/**-------------------------------------
 * Định dạng tiền trên form nhân viên
 * @param {*} myinput 
 * @returns 
 * Author: LNTHAO (23/07/2021)
 */
function formatAutoMoney(myinput) {
    myinput += "";
    if (myinput != null) {
        myinput.replaceAll(".", "");
        let onlynumber = '';
        for (let i = 0; i < myinput.length; i++) {
            if (!isNaN(parseInt(myinput[i], 10))) {
                onlynumber += myinput[i];
            }
        }
        return (Number(onlynumber).toLocaleString('vi'));
    }
    return 0;
}

/**------------------------------------
 * Hàm lưu chuỗi input tiền nhập vào
 * @param {*} thismoney 
 * Author: LNTHAO (23/07/2021)
 */
function moneyInput(thismoney) {
    thismoney.on('input', function () {
        let myinput = thismoney.val();
        res = formatAutoMoney(myinput);
        thismoney.val(res);
    })
}

/**----------------------------------------
 * Hàm chuyển đổi định dạng ngày tháng năm
 * @param {*} thisdate 
 * @returns 
 * Author: LNTHAO (23/07/2021)
 */
function formatDataDDMMYY(thisdate){
    date = new Date(thisdate);
    return ("0"+ data.getDate()).slice(-2) + '/' + ("0"+ (date.getMonth()+ 1)).slice(-2) + '/' + date.getFullYear();
}

/**-----------------------------------------
 * Hàm chuyển đổi định dạng ngày tháng năm
 * @param {*} thisdate 
 * @returns 
 * Author: LNTHAO (23/07/2021)
 */
function formatDateMMDDYY(thisdate) {
    date = new Date(thisdate);
    return ("")
}


/**-------------------------------------------------------------------
 * Hiển thị dữ liệu ngày tháng từ database lên form nhân viên khi xem
 * @param {any} date 
 * @returns 
 * Author: LNTHAO (26/07/2021)
 */
 function formatCalendar(date){
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";
    } else {
        var day = date.getDate();
        month = date.getMonth() + 1;
        year = date.getFullYear();
        day = day < 10 ? "0" + day : day;
        month = month < 10 ? "0" + month : month;
        var result = year + "-" + month + "-" + day;
        return result;
    }
}


/**-----------------------------------
 * Định nghĩa cho các workstatus
 * Author: LNTHAO (20/07/2021)
 */
 function loadWorkStatus(indexS) {
    var valueWorkStatus = '';
    for (let i = 0; i < dataWorkStatus.length; i++) {
        if (dataWorkStatus[i].index == indexS) {
            valueWorkStatus = dataWorkStatus[i].value;
            break;
        }
    }
    return valueWorkStatus;
}

/**-----------------------------------
 * Tìm kiếm, lọc thông tin trong bảng
 * Author: LNTHAO (20/07/2021)
 */
$("#txtSearch").keyup(function () {
    var value = $(this).val().toLowerCase();
    $("table#tbListDataEmployee tbody tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});

/**-----------------------------------------------------------------------
         * Sửa thông tin nhân viên khi double click vào thông tin trong bảng
         * Author: LNTHAO (26/7/2021)
         */
        // var employeeId;
        $('table#tbListDataEmployee').on('dblclick', 'tbody tr', function () {
            try {
                // formMode = 0;
                $('#dlgEmployeeDetail').show();// Note
                //Lấy id
                employeeId = $(this).attr('employeeId');
                $.ajax({
                    url: `http://cukcuk.manhnv.net/v1/Employees/${employeeId}`,
                    method: 'GET',
                }).done(function (res) {

                    console.log(res);
                    var positionId = res.PositionId;
                    var positionName = '';
                    var genderValue = '';
                    var depName = '';
                    var wstatusValue = '';
                    var genderValue = '';
                    if (positionId != null || positionId != undefined) {
                        for (let i = 0; i < dataPosition.length; i++) {
                            if (dataPosition[i].id == positionId) {
                                positionName = dataPosition[i].name;
                                break;
                            }
                            else {
                                positionName = '';
                            }
                        }
                        $('#txtPositionName').attr('value', res['PositionId']);
                        var thisItem = $('#txtPositionName').parent().parent();
                        thisItem.find('.dropdown-item').removeClass('active');
                        thisItem.find(`.dropdown-item[value="${positionId}"]`).addClass('active');
                    }
                    var depId = res.DepartmentId;
                    if (depId != null || depId != undefined) {
                        for (let i = 0; i < dataDepartment.length; i++) {
                            if (dataDepartment[i].id == depId) {
                                depName = dataDepartment[i].name;
                                break;
                            }
                            else {
                                depName = '';
                            }
                        }
                        $('#txtDepartmentName').attr('value', res['DepartmentId']);
                        var thisItem = $('#txtDepartmentName').parent().parent();
                        thisItem.find('.dropdown-item').removeClass('active');
                        thisItem.find(`.dropdown-item[value="${depId}"]`).addClass('active');
                    }
                    var genderIndex = res.Gender;
                    var genderValue = '';
                    if (genderIndex != null || genderIndex != undefined || genderIndex < dataGender.length) {

                        for (let i = 0; i < dataGender.length; i++) {
                            if (dataGender[i].index == genderIndex) {
                                genderValue = dataGender[i].value;
                                break;
                            }
                            else {
                                genderValue = '';
                            }
                        }
                        $('#txtGender').attr('value', res['Gender']);
                        var thisItem = $('#txtGender').parent().parent();
                        thisItem.find('.dropdown-item').removeClass('active');
                        thisItem.find(`.dropdown-item[value="${genderIndex}"]`).addClass('active');
                    }
                    var wstatusIndex = res.WorkStatus;
                    if (wstatusIndex != null || wstatusIndex != undefined || wstatusIndex < dataWorkStatus.length) {
                        wstatusValue = loadWorkStatus(wstatusIndex);
                        $('#txtWorkStatus').attr('value', wstatusIndex);
                        var thisItem = $('#txtWorkStatus').parent().parent();
                        thisItem.find('.dropdown-item').removeClass('active');
                        thisItem.find(`.dropdown-item[value="${wstatusIndex}"]`).addClass('active');
                    }
                    var salary = Number((res['Salary'])).toLocaleString('vi');
                    console.log(salary);
                    $('#txtEmployeeCode').val(res['EmployeeCode']);
                    $('#txtFullName').val(res['FullName']);
                    $('#txtDateOfBirth').val(formatCalendar(res['DateOfBirth']));
                    $('#txtGender').text(genderValue);
                    $('#txtIdentityNumber').val(res['IdentityNumber']);
                    $('#txtIdentityDate').val(formatCalendar(res['IdentityDate']));
                    $('#txtIdentityPlace').val(res['IdentityPlace']);
                    $('#txtEmail').val(res['Email']);
                    $('#txtPhoneNumber').val(res['PhoneNumber']);
                    $('#txtPositionName').text(positionName);
                    $('#txtDepartmentName').text(depName);
                    $('#txtDepartmentName').attr('value', res['DepartmentId']);
                    $('#txtPersonalTaxCode').val(res['PersonalTaxCode']);
                    $('#txtSalary').val(salary);
                    $('#txtJoinDate').val(formatCalendar(res['JoinDate']));
                    $('#txtWorkStatus').text(wstatusValue);
                    $('#dlgEmployeeDetail').show();
                }).fail(function (res) {
                })
            } catch (error) {
                console.log(error);
            }
        })

        /**----------------------------------------------------------------------------
         * Delete - Xóa toàn bộ dữ liệu
         * Author: LNTHAO (25/7/2021) --> Note lại
         */
        $('table#tbListDataEmployee').on('mousedown', 'tbody tr', function (event) {

            try {
                if (event.which == 3) {
                    if (confirm("Bạn có chắc chắn muốn xóa?")) {
                        employeeId = $(this).attr('employeeId');
                        $.ajax({
                            url: `http://cukcuk.manhnv.net/v1/Employees/${employeeId}`,
                            method: 'DELETE',
                        }).done(function (res) {
                            alert("Xóa thành công.");
                            location.reload();                         
                        }).fail(function (res) {
                            alert("Xóa không thành công.");
                        });
                    }
                }
            } catch (error) {
                console.log(error);
            }
        })