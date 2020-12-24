using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public class AliPaymentRequest : AbcTrxRequest<Response.AliPaymentResponse>
    {
        [Newtonsoft.Json.JsonIgnore]
        public override string TrxName => "支付宝被扫";

        public override string TrxType => AbcConstact.TrxType_Ali;

        public override string PaymentType => AbcConstact.PaymentType_Ali;

        public override string PaymentLinkType => AbcConstact.PaymentLinkType_Ali;

        public string TimeoutExpress { get; set; }
    }
}
