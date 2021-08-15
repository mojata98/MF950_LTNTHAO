import message from './message'
import $ from 'jquery'

const common = {
  /**
   * Sẽ được gọi đến khi ấn hủy hoặc thoát form dialog, làm cho tool-tip không hiện nữa
   *  CreatedBy: LNTHAO 10/8/2021
   */
  turnOffValidate() {
    console.log($('.input-item input[type=text]'));
    var array = $('.input-item input[type=text]');
    console.log(array.length);
    console.log(array[1]);
    for (let i = 0; i < array.length; i++) {
      array[i].style.border = "";
      array[i].nextElementSibling.style.display = "none";
    }
  },

  /**
   * Sẽ được gọi đến khi check validate dữ liệu nếu dữ liệu không đúng
   * @param {*} inputs các elements inputs
   * @param {*} value key được đặt trên các thẻ input (ref)
   * @param {*} message thông báo lỗi cho người dùng biết
   * CreatedBy: LNTHAO 10/8/2021
   */
  turnOnValidate(inputs, value, message) {
    inputs[value].style.border = "1px solid #F65454";
    inputs[value].nextElementSibling.style.display = "block";
    inputs[value].nextElementSibling.innerText = message;
    $(inputs[value]).attr('validate', false)
  },


  /**
   * validate dữ liệu
   * @param {*} inputs các element inputs có chứa ref
   * @param {*} value dữ liệu của ref được gán trên thẻ input
   * @returns true - đã check validate và dữ liệu đúng hết, false - dữ liệu đang sai
   * createdBy: LNTHAO 10/8/2021
   */
  isValidateInput(inputs, value) {
    // check bắt buộc nhập
    console.log("value " + value);
    console.log("inputs[value] " + inputs[value]);
    console.log("inputs[value].value " + inputs[value].value);
    if (!inputs[value].value) {
      common.turnOnValidate(inputs, value, message.VALIDATE_MSG_NO_SUCCESS);
      return false;
    }
    if (value == "Email") {
      if (!common.isEmail(inputs[value].value)) {
        common.turnOnValidate(inputs, value, message.VALIDATE_FORMAT_MSG_NO_SUCCESS);
        return false;
      }
    }
    if (value == "IdentityNumber") {
      if (!common.isIdentityNumber(inputs[value].value)) {
        common.turnOnValidate(inputs, value, message.VALIDATE_FORMAT_MSG_NO_SUCCESS);
        return false;
      }
    }
    var div;
    $(inputs[value]).css("border", "");
    div = $(inputs[value]).next()[0];
    $(div).css("display", 'none')
    $(inputs[value]).attr('validate', true)
  },

  /**
     * Định dạng cho email - File cũ
     * CreateBy LNTHAO (22/7/2021)
     */
  isEmail(email) {
    //eslint-disable-next-line
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
      return false;
    } else {
      return true;
    }
  },
  /**
   * Định dạnh cho số chứng minh thư nhân dân
   * CreateBy LNTHAO (22/7/2021)
   */
  isIdentityNumber(cmt) {
    //eslint-disable-next-line
    var regex = /^([0-9]{9}|[0-9]{12})+$/;
    if (!regex.test(cmt)) {
      return false;
    } else {
      return true;
    }
  },

}

export default common;