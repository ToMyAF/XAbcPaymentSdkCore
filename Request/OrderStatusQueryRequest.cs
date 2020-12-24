using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public class OrderStatusQueryRequest : AbcTrxRequest<Response.OrderStatusQueryResponse>
    {
        [Newtonsoft.Json.JsonIgnore]
        public override string TrxName => "订单状态查询";

        public override string TrxType => "Query";

        public override string PaymentType => "";

        public override string PaymentLinkType => "";

        public string OrderNo { get; set; }

        public string QueryDetail { get; set; }

        public string PayTypeID { get; set; }
    }
}
