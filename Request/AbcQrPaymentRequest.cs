using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public class AbcQrPaymentRequest : AbcTrxRequest<Response.AbcQrPaymentResponse>
    {
        [Newtonsoft.Json.JsonIgnore]
        public override string TrxName => "农行掌银被扫";

        public override string TrxType => AbcConstact.TrxType_AbcQr;

        public override string PaymentType => AbcConstact.PaymentType_AbcQr;

        public override string PaymentLinkType => AbcConstact.PaymentLinkType_AbcQr;
    }
}
