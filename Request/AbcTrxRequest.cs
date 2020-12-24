using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public abstract class AbcTrxRequest<T> where T:Response.AbcResponse
    {

        [Newtonsoft.Json.JsonIgnore]
        public abstract string TrxName { get; }
        /// <summary>
        /// 
        /// </summary>
        public abstract string TrxType { get; }
        /// <summary>
        /// 
        /// </summary>
        public abstract string PaymentType { get; }
        /// <summary>
        /// 
        /// </summary>
        public abstract string PaymentLinkType { get;}

        /// <summary>
        /// 
        /// </summary>
        public string ReceiveAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveAccName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NotifyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ResultNotifyURL { get; set; }
        /// <summary>
        /// 附言
        /// </summary>
        public string MerchantRemarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsBreakAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SplitAccTemplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LimitPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CommodityType { get; set; }

        [Newtonsoft.Json.JsonProperty("Order")]
        public AbcOrderInfo OrderInfo { get; set; }


    }
}
