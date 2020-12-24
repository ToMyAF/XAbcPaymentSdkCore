using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Request
{
    public class AbcOrderInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string PayTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExpiredDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// 农行掌银二维码
        /// </summary>
        public string QRPayCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode => AbcConstact.CurrencyCode;
        /// <summary>
        /// 
        /// </summary>
        public string ReceiverAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InstallmentMark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InstallmentCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InstallmentNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BuyIP { get; set; }
        /// <summary>
        /// 订单说明
        /// </summary>
        public string OrderDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("orderTimeoutDate")]
        public string OrderTimeoutDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SplitAccInfoItem> SplitAccInfoItems { get; set; }
    }
    public class SplitAccInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string SplitMerchantID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SplitAmount { get; set; }
    }
    public class OrderItem
    {
        /// <summary>
        /// 测试二级商户1
        /// </summary>
        public string SubMerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SubMerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SubMerMCC { get; set; }
        /// <summary>
        /// 测试
        /// </summary>
        public string SubMerchantRemarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 中国移动IP卡
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UnitPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Qty { get; set; }
        /// <summary>
        /// 测试商品
        /// </summary>
        public string ProductRemarks { get; set; }
        /// <summary>
        /// 充值类
        /// </summary>
        public string ProductType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductDiscount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductExpiredDate { get; set; }
    }
}
