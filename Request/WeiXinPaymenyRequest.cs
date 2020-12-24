using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public class WeiXinPaymenyRequest : AbcTrxRequest<Response.WeiXinPaymentResponse>
    {
        [Newtonsoft.Json.JsonIgnore]
        public override string TrxName => "微信被扫";

        public override string TrxType => AbcConstact.TrxType_WeiXin;

        public override string PaymentType => AbcConstact.PaymentType_WeiXin;

        public override string PaymentLinkType => AbcConstact.PaymentLinkType_WeiXin;

       
    }
}
