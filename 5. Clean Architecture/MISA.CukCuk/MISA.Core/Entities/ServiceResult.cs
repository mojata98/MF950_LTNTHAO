using MISA.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Thông tin trả về có hợp lệ hay không?
        /// CreatedBy: LNT (15/08)
        /// </summary>
        public bool IsValid { get; set; } = true;
        /// <summary>
        /// Dữ liệu trả về
        /// CreatedBy: LNT (15/08)
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Thông báo trả về
        /// CreatedBy: LNT (15/08)
        /// </summary>
        public string Message { get; set; }
        //----------------------------------------
        /// <summary>
        /// Status code trả về
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// Thông báo cho client
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        /// Message trả về cho Dev
        /// </summary>
        public List<string> DevMessage { get; set; }

        /// <summary>
        /// Thông tin khác
        /// </summary>
        public string MoreInfo { get; set; }
        #region Constructor
        public ServiceResult()
        {
            this.ResultCode = (int)EnumServiceResult.Success;
            this.DevMessage = new List<string>();
            this.UserMessage = null;
            this.MoreInfo = null;
            this.Data = null;
        }
        #endregion

        #region Method
        /// <summary>
        /// Gán log thực hiện thành công
        /// </summary>
        /// <param name="serviceResult"></param>
        /// <param name="data"></param>
        public void SetSuccess(ServiceResult serviceResult, object data)
        {
            serviceResult.ResultCode = (int)EnumServiceResult.Success;
            serviceResult.DevMessage.Add(Properties.Resource.Dev_Success_Msg);
            serviceResult.UserMessage = Properties.Resource.User_Success_Msg;
            serviceResult.Data = data;
        }

        /// <summary>
        /// Gán log thực hiện thất bại
        /// </summary>
        /// <param name="serviceResult"></param>
        public void SetNoContent(ServiceResult serviceResult)
        {
            serviceResult.ResultCode = (int)EnumServiceResult.NoContent;
            serviceResult.DevMessage.Add(Properties.Resource.Dev_Error_Msg);
            serviceResult.UserMessage = Properties.Resource.User_Info_Msg;
        }

        /// <summary>
        /// Gán log lỗi máy chủ
        /// </summary>
        /// <param name="serviceResult"></param>
        public void SetInternalServerError(ServiceResult serviceResult)
        {
            serviceResult.ResultCode = (int)EnumServiceResult.InternalServerError;
            serviceResult.UserMessage = Properties.Resource.User_Error_Msg;
        }
        /// <summary>
        /// Gán log lỗi request
        /// </summary>
        /// <param name="serviceResult"></param>
        public void SetBadRequest(ServiceResult serviceResult)
        {
            serviceResult.ResultCode = (int)EnumServiceResult.BadRequest;
            serviceResult.UserMessage = Properties.Resource.User_Info_Msg;
        }
        #endregion
    }
}
