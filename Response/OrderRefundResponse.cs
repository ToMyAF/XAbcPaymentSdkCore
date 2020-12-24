using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Response
{
    public class OrderRefundResponse:AbcResponse
    {
        public RefundDetail TrxResponse { get; set; }
    }
    public class RefundDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReturnCode { get; set; }
        /// <summary>
        /// 受理成功
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrxType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NewOrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrxAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VoucherNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HostDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HostTime { get; set; }

        [Newtonsoft.Json.JsonProperty("iRspRef")]
        public string IRspRef { get; set; }
    }
}
