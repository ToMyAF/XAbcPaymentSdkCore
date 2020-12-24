using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAbcPaymentSdkCore.Util;

namespace XAbcPaymentSdkCore.Response
{
    public class OrderStatusQueryResponse:AbcResponse
    {
        public QueryResponse TrxResponse { get; set; }
    }
    public class QueryResponse
    {
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

        public string Order { get; set; }
    }
    public class QueryResponDetail
    {
        public string PayTypeID { get; set; }

        public string OrderNo { get; set; }

        public string OrderDate { get; set; }

        public string OrderAmount { get; set; }

        public string OrderTime { get; set; }

        public string Status { get; set; }

        public static QueryResponDetail GetInstance(string base64OrderStr)
        {
            byte[] orderBytes = Convert.FromBase64String(base64OrderStr);            
            string orderDetailJson = Encoding.GetEncoding("gb2312").GetString(orderBytes);
            return JsonParseUtil.Deserialize<QueryResponDetail>(orderDetailJson);
        }
    }
}
