$(document).ready(function () {
    new CustomerJS();
})

/**--------------------------------------
 * Class quản lý các sự kiện cho Emloyee
 * CreatedBy: LNTHAO (20/07/2021)
 */
class CustomerJS extends BaseJS{
    constructor() {
        // this.loadData();
        super();
    }


















    // /**--------------------------------------
    // * Load dữ liệu cho trang Employee
    // * CreatedBy: LNTHAO (20/07/2021)
    // */
    // loadData() {
    //     //lấy dữ liệu về
    // $.ajax({
    //     url: "http://cukcuk.manhnv.net/v1/Employees",
    //     method: "GET",
    //     data: ''// Tham số sẽ truyền lên cho API qua body request ( nếu ko có có thể bỏ qua)
    //     // datatype : json
    //     // contentType: 'json' //kiểu dữ liệu trả về 
    //     // async : True, đồng bộ/ bất đồng bộ   
    // }).done(function (res) {
    //     // Xử lý dữ liệu
    //     // Hiển thị dữ liệu lên table 
    //     var data = res;
    //     $.each(data, function (index, item) {
    //         var dateOfBirth = item["DateOfBirth"];
    //         var salary = item["Salary"];
    //         var dateStr = formatDate(dateOfBirth);
    //         var money = formatMoney(salary);
    //         var checkbox = `<input type = "checkbox"/>`;
    //         if (item.WorkStatus > 5) {
    //             var checkbox = `<input type = "checkbox" checked/>`;
    //         }
    //         var tr = $(`<tr>
    //                         <td class="text-align-center" style="max-width: 60px " >`+ checkbox + `</td>
    //                         <td class="text-align-left" style="max-width: 100px" title = "`+item.EmployeeCode+`">`+ item.EmployeeCode + `</td>
    //                         <td class="text-align-left" style="max-width: 150px" title = "`+ item['FullName'] + `">` + item['FullName'] + `</td>
    //                         <td class="text-align-center" style="max-width: 60px " title = "`+ item['GenderName'] + `">` + item['GenderName'] + `</td>
    //                         <td class="text-align-center" style="max-width: 100px" title = "`+ dateStr + `">` + dateStr + `</td>
    //                         <td class="text-align-left" style="max-width: 100px" title = "`+ item['PhoneNumber'] + `">` + item['PhoneNumber'] + `</td>
    //                         <td class="text-align-left" style="max-width: 100px" title = "` + item['Email'] + `">` + item['Email'] + `</td>
                            
    //                     </tr>`);
    //         $('table tbody').append(tr);
    //         // debugger;
    //     })
    // }).fail(function (res) {
    //     // API trả về lỗi - đưa ra thông báo lỗi cụ thể : tùy theo HttpCode - 400, 404, 500
    //     // Thông thường thì:
    //     // Mã 400: BadRequest- lỗi dữ liệu đầu vào từ client
    //     // 404: Địa chỉ url không hợp lệ
    //     // 500: Lỗi từ phía backend (bên server) 
    //     alert("Có lỗi xảy ra vui lòng liên hệ MISA")
    // })
    // //binding dữ liệu
    // }
    // /**--------------------------------------
    // * Thêm mới nhân viên
    // * CreatedBy: LNTHAO (20/07/2021)
    // */
    // add() {

    // }
    // /**--------------------------------------
    // * Sửa thông tin nhân viên
    // * CreatedBy: LNTHAO (20/07/2021)
    // */
    // edit() {

    // }
    // /**--------------------------------------
    // * Xóa thông tin nhân viên
    // * CreatedBy: LNTHAO (20/07/2021)
    // */
    // delete() {

    // }
}


