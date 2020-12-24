using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Response
{
    public class AliPaymentResponse:AbcResponse
    {
        public string HostDate { get; set; }


        public string HostTime { get; set; }

        /// <summary>
        /// 支付宝-支付平台商户订单号
        /// </summary>
        public string ThirdOrderNo { get; set; }


        public string QRURL { get; set; }

        public string ThirdReOrderNo { get; set; }

        public string PrePayID { get; set; }

    }
}
