using System;

namespace XAbcPaymentSdkCore.Client
{
	// Token: 0x02000048 RID: 72
	public class TrxException : Exception
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00011538 File Offset: 0x00010538
		public virtual string Code
		{
			get
			{
				return this.iCode;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00011550 File Offset: 0x00010550
		public override string Message
		{
			get
			{
				return base.Message;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00011568 File Offset: 0x00010568
		public virtual string DetailMessage
		{
			get
			{
				return this.iDetailMessage;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00011580 File Offset: 0x00010580
		public TrxException(string aCode, string aMessage) : base(aMessage)
		{
			this.iCode = aCode.Trim();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000115B0 File Offset: 0x000105B0
		public TrxException(string aCode, string aMessage, string aDetailMessage) : base(aMessage.Trim() + " - " + aDetailMessage.Trim())
		{
			this.iCode = aCode.Trim();
			this.iDetailMessage = aDetailMessage.Trim();
		}

		// Token: 0x04000179 RID: 377
		public const string TRX_EXC_CODE_1000 = "1000";

		// Token: 0x0400017A RID: 378
		public const string TRX_EXC_CODE_1001 = "1001";

		// Token: 0x0400017B RID: 379
		public const string TRX_EXC_CODE_1002 = "1002";

		// Token: 0x0400017C RID: 380
		public const string TRX_EXC_CODE_1003 = "1003";

		// Token: 0x0400017D RID: 381
		public const string TRX_EXC_CODE_1004 = "1004";

		// Token: 0x0400017E RID: 382
		public const string TRX_EXC_CODE_1005 = "1005";

		// Token: 0x0400017F RID: 383
		public const string TRX_EXC_CODE_1006 = "1006";

		// Token: 0x04000180 RID: 384
		public const string TRX_EXC_CODE_1007 = "1007";

		// Token: 0x04000181 RID: 385
		public const string TRX_EXC_CODE_1008 = "1008";

		// Token: 0x04000182 RID: 386
		public const string TRX_EXC_CODE_1100 = "1100";

		// Token: 0x04000183 RID: 387
		public const string TRX_EXC_CODE_1101 = "1101";

		// Token: 0x04000184 RID: 388
		public const string TRX_EXC_CODE_1102 = "1102";

		// Token: 0x04000185 RID: 389
		public const string TRX_EXC_CODE_1103 = "1103";

		// Token: 0x04000186 RID: 390
		public const string TRX_EXC_CODE_1104 = "1104";

		// Token: 0x04000187 RID: 391
		public const string TRX_EXC_CODE_1201 = "1201";

		// Token: 0x04000188 RID: 392
		public const string TRX_EXC_CODE_1202 = "1202";

		// Token: 0x04000189 RID: 393
		public const string TRX_EXC_CODE_1203 = "1203";

		// Token: 0x0400018A RID: 394
		public const string TRX_EXC_CODE_1204 = "1204";

		// Token: 0x0400018B RID: 395
		public const string TRX_EXC_CODE_1205 = "1205";

		// Token: 0x0400018C RID: 396
		public const string TRX_EXC_CODE_1206 = "1206";

		// Token: 0x0400018D RID: 397
		public const string TRX_EXC_CODE_1301 = "1301";

		// Token: 0x0400018E RID: 398
		public const string TRX_EXC_CODE_1302 = "1302";

		// Token: 0x0400018F RID: 399
		public const string TRX_EXC_CODE_1303 = "1303";

		// Token: 0x04000190 RID: 400
		public const string TRX_EXC_CODE_1304 = "1304";

		// Token: 0x04000191 RID: 401
		public const string TRX_EXC_CODE_1999 = "1999";

		// Token: 0x04000192 RID: 402
		public const string TRX_EXC_MSG_1000 = "无法读取商户端配置文件";

		// Token: 0x04000193 RID: 403
		public const string TRX_EXC_MSG_1001 = "商户端配置文件中参数设置错误";

		// Token: 0x04000194 RID: 404
		public const string TRX_EXC_MSG_1002 = "无法读取证书文档";

		// Token: 0x04000195 RID: 405
		public const string TRX_EXC_MSG_1003 = "无法读取商户私钥";

		// Token: 0x04000196 RID: 406
		public const string TRX_EXC_MSG_1004 = "无法写入交易日志文档";

		// Token: 0x04000197 RID: 407
		public const string TRX_EXC_MSG_1005 = "证书过期";

		// Token: 0x04000198 RID: 408
		public const string TRX_EXC_MSG_1006 = "证书格式错误";

		// Token: 0x04000199 RID: 409
		public const string TRX_EXC_MSG_1007 = "配置文件中MerchantID、MerchantCertFile、MerchantCertPassword属性个数不一致";

		// Token: 0x0400019A RID: 410
		public const string TRX_EXC_MSG_1008 = "指定的商户配置编号不合法";

		// Token: 0x0400019B RID: 411
		public const string TRX_EXC_MSG_1100 = "商户提交的交易资料不完整";

		// Token: 0x0400019C RID: 412
		public const string TRX_EXC_MSG_1101 = "商户提交的交易资料不合法";

		// Token: 0x0400019D RID: 413
		public const string TRX_EXC_MSG_1102 = "签名交易报文时发生错误";

		// Token: 0x0400019E RID: 414
		public const string TRX_EXC_MSG_1103 = "无法连线签名服务器";

		// Token: 0x0400019F RID: 415
		public const string TRX_EXC_MSG_1104 = "签名服务器返回签名错误";

		// Token: 0x040001A0 RID: 416
		public const string TRX_EXC_MSG_1201 = "无法连线网上支付平台";

		// Token: 0x040001A1 RID: 417
		public const string TRX_EXC_MSG_1202 = "提交交易时发生网络错误";

		// Token: 0x040001A2 RID: 418
		public const string TRX_EXC_MSG_1203 = "无法接收到网上支付平台的响应";

		// Token: 0x040001A3 RID: 419
		public const string TRX_EXC_MSG_1204 = "接收网上支付平台响应报文时发生网络错误";

		// Token: 0x040001A4 RID: 420
		public const string TRX_EXC_MSG_1205 = "无法辨识网上支付平台的响应报文";

		// Token: 0x040001A5 RID: 421
		public const string TRX_EXC_MSG_1206 = "网上支付平台服务暂时停止";

		// Token: 0x040001A6 RID: 422
		public const string TRX_EXC_MSG_1301 = "网上支付平台的响应报文不完整";

		// Token: 0x040001A7 RID: 423
		public const string TRX_EXC_MSG_1302 = "网上支付平台的响应报文签名验证失败";

		// Token: 0x040001A8 RID: 424
		public const string TRX_EXC_MSG_1303 = "无法辨识网上支付平台的交易结果";

		// Token: 0x040001A9 RID: 425
		public const string TRX_EXC_MSG_1304 = "解压缩交易记录时发生错误";

		// Token: 0x040001AA RID: 426
		public const string TRX_EXC_MSG_1999 = "系统发生无法预期的错误";

		// Token: 0x040001AB RID: 427
		protected internal string iCode = "";

		// Token: 0x040001AC RID: 428
		protected internal string iDetailMessage = "";
	}
}
