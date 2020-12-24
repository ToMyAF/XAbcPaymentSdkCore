using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Response
{
    public class AbcQrPaymentResponse:AbcResponse
    {
        public string PaymentURL { get; set; }
    }
}
