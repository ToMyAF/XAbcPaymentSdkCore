using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Response
{
    public class WeiXinPaymentResponse:AbcResponse
    {
        public string PaymentURL { get; set; }

        public string QRURL { get; set; }

        public string HostDate { get; set; }

        public string HostTime { get; set; }

        public string PrePayID { get; set; }
        /// <summary>
        /// 微信-支付平台商户订单号
        /// </summary>
        public string ThirdOrderNo { get; set; }
    }
}
