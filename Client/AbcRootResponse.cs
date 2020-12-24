using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Client
{
    public class AbcRootResponse<T> where T : Response.AbcResponse
    {
        [Newtonsoft.Json.JsonProperty("MSG")]
        public RspMessageRoot<T> RspMsgBean { get; set; }
    }
    public class RspMessageRoot<T> where T: Response.AbcResponse
    {

        /// <summary>
        /// 
        /// </summary>
        public T Message { get; set; }
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
}
