class BaseJS {
    constructor() {
        this.loadData();
    }
  
    loadData() {
        // Lấy thông tin các cột
        var colums = $('table thead th'); // Đọc số lượng cột
        $.ajax(
            {
                url: "http://cukcuk.manhnv.net/v1/Employees", // viết hoa !== viết thường
                method: "GET",
                dataType: "json", // Tránh lỗi từ vòng lặp $.each
            }
        ).done(function(res) {
            $.each(res, function(index, obj) {
                var tr = $(`<tr employeeId = '${obj.EmployeeId}'></tr>`);
                $.each(colums, function(index, item) {
                    var td = $(`<td title = "`+obj[$(item).attr('fieldName')]+`"></td>`);
                    var fieldName = $(item).attr('fieldName');
                    var value = obj[fieldName];
                    var formatType = $(item).attr('formatType');
                    var textAlignType = $(item).attr('textAlignType');
                    switch (formatType) {
                        case "ddmmyyyy" :
                            value = formatDate(value);
                            break;
                        case "Money" :
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
        }).fail(function(res) {

        })
    }
}