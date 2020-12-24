using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Response
{
    public class AbcResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Merchant")]
        public Client.MerchantInfo MerchantInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnCode { get; set; }
        /// <summary>
        /// 二级商户不存在
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
        public string OrderAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RequestDate { get; set; }
    }
}
