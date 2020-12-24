using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace XAbcPaymentSdkCore
{
    public class AbcConstact
    {
        /*-------------微信被扫-----------------*/
        public const string TrxType_WeiXin = "UnifiedOrderReq";
        public const string PaymentType_WeiXin = "8";
        public const string PaymentLinkType_WeiXin = "1";
        public const string PayTypeID_WeiXin = "MICROPAY";

        /*-------------支付宝被扫-----------------*/
        public const string TrxType_Ali = "AliPayOrderReq";
        public const string PaymentType_Ali = "9";
        public const string PaymentLinkType_Ali = "1";
        public const string PayTypeID_Ali = "ALI_PAY";

        /*-------------农行掌银被扫-----------------*/
        public const string TrxType_AbcQr = "ABCQRPayReq";
        public const string PaymentType_AbcQr = "A";
        public const string PaymentLinkType_AbcQr = "1";
        public const string PayTypeID_AbcQr = "ImmediatePay";

        /*-------------单笔退款-----------------*/
        

        /*-------------订单查询-----------------*/
        public const string PayTypeID_Query_Pay = "ImmediatePay";
        public const string PayTypeID_Query_Refund = "Refund";
        public const string QueryDetail = "0";
        /*-------------其他配置-----------------*/
        public const string SignatureAlgorithm = "SHA1withRSA";
        public const string CurrencyCode = "156";
        public const string ECMerchantType = "EBUS";
        public const string SuccessReturnCode = "0000";
        public static readonly string ISHA1OID = CryptoConfig.MapNameToOID("SHA1");
        public const string NotifyType = "1";
        public const string CommodityType = "0202";
        public const string InstallmentMark = "0";
        public const string IsBreakAccount = "0";
    }
}
