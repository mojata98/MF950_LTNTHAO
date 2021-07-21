/** --------------------------------------------
* Format dữ liệu ngày tháng sang ngày/tháng/năm
* @param {any} date  bất cứ dữ liệu nào 
* CreatedBy: LNTHAO (20/07/2021)
*/
function formatDate(date){
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
function formatMoney(datamoney){ 
    if (datamoney){
        var num = datamoney.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        return num;
    } else{
        return "";
    }
    
}