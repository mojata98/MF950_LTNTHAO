/** --------------------------------------------
* Format dữ liệu ngày tháng sang ngày/tháng/năm
* @param {any} date  bất cứ dữ liệu nào 
* CreatedBy: LNTHAO (20/07/2021)
*/
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";
    } else {
        var day = date.getDate();
        month = date.getMonth() + 1;
        year = date.getFullYear();
        day = day < 10 ? "0" + day : day;
        month = month < 10 ? "0" + month : month;
        var result = day + "/" + month + "/" + year;
        return result;
    }

}


/** --------------------------------
 * Định dạng dữ liệu tiền tệ
 * @param {Number} money Số tiền
 * CreatedBy: LNTHAO (20/07/2021)
 */
function formatMoney(datamoney) {
    if (datamoney) {
        var num = datamoney.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return num;
    } else {
        return "";
    }

}

/** ----------------------------------------------------------------------------------------
 * Kiểm tra dữ liệu dạng email, chuẩn hóa đầu ra của dữ liệu email nếu hợp lệ
 * @param {any} email 
 * @returns 
 * Author: LNTHAO (23/07/2021)
 */
function formatEmail(email) {
    var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    if (String(email).match(mailformat)) {
        return email.toLowerCase();
    }
    else {
        return false;
    }
}

/** -----------------------------------------------------------------------
 * Kiểm tra dữ liệu dạng Số điện thoại
 * @param {any} phoneNumber 
 * @returns 
 */
function formatPhoneNumber(phoneNumber) {
    var phoneFormat = /^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/;
    if(String(phoneNumber).match(phoneFormat)) {
      return true;
    }  
    else {  
      return false;
    }

}

/** -----------------------------------------------------------------------
 * Kiểm tra dữ liệu nhập vào của  CMND <= 12 số
 * @param {any} identityCode 
 * @returns 
 */
function formatIdentityCode(identityCode){
    if (isNumber(identityCode)){
        if (String(identityCode).length > 12){
            return false;
        }
        else{
            return true;
        }
    }
    else{
        return false;
    }
}

/** -------------------------------------------------------------------------
 * Kiểm tra dữ liệu nhập vào có phải số hay không
 * @param {any} n 
 * @returns 
 */
function isNumber(n) { return !isNaN(parseFloat(n)) && !isNaN(n - 0) }