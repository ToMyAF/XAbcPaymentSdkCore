using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public class OrderRefundRequest : AbcTrxRequest<Response.OrderRefundResponse>
    {
        [Newtonsoft.Json.JsonIgnore]
        public override string TrxName => "单笔退款";

        public override string TrxType => "Refund";

        public override string PaymentType => "";

        public override string PaymentLinkType => "";

        public string OrderDate { get; set; }

        public string OrderTime { get; set; }

        public string MerRefundAccountNo { get; set; }

        public string MerRefundAccountName { get; set; }

        public string OrderNo { get; set; }

        public string NewOrderNo { get; set; }

        public string CurrencyCode => "156";

        public string TrxAmount { get; set; }

        public string RefundType { get; set; }

    }
}
