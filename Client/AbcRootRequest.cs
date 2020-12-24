using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAbcPaymentSdkCore.Request;

namespace XAbcPaymentSdkCore.Client
{
    public class AbcRootRequest<T,TRsp> where TRsp : Response.AbcResponse where T : AbcTrxRequest<TRsp>
    {
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Message")]
        public MessageInfo<T, TRsp> MessageInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Signature-Algorithm")]
        public string SignatureAlgorithm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Signature { get; set; }
    }
    public class MessageInfo<T,TRsp> where TRsp : Response.AbcResponse where T : AbcTrxRequest<TRsp>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Version => "V3.0.0";
        /// <summary>
        /// 
        /// </summary>
        public string Format => "JSON";
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Merchant")]
        public MerchantInfo MerchantInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T TrxRequest { get; set; }
    }
    public class MerchantInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string ECMerchantType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MerchantID { get; set; }
    }
}
