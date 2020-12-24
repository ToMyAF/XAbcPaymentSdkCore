using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using XAbcPaymentSdkCore.Client;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace XAbcPaymentSdkCore.Util
{
    public static class SignXUtil
    {
		public static string GenerateSignature(MerchantParameter mc, string msg)
		{
            using (SHA1Managed sha1Managed = new SHA1Managed())
            {
				byte[] rgbHash = sha1Managed.ComputeHash(Encoding.UTF8.GetBytes(msg));
				byte[] data = mc.MerchantKey.SignHash(rgbHash,HashAlgorithmName.SHA1,RSASignaturePadding.Pkcs1);
				Base64 base64 = new Base64();
				string signStr = base64.encode(data);
				return signStr;
			}
		}
		public static KeyValuePair<bool,TrxException> VerifySign(MerchantParameter mc, string rspContent)
		{
            try
            {
				JObject rspJobj = JObject.Parse(rspContent);
				//使用原生字符串截取方式避免特殊字符转译
				string rspmsgCotent = JsonParseUtil.GetKeyValue(rspContent,"Message");
				if (string.IsNullOrEmpty(rspmsgCotent))
				{
					throw new TrxException("1301", "网上支付平台的响应报文不完整", "无[Message]段！");
				}
				string signAlgo = rspJobj["MSG"]["Signature-Algorithm"]?.ToString();
				//string signAlgo = rspData.RspMsgBean.SignatureAlgorithm;
				if (string.IsNullOrEmpty(signAlgo))
				{
					throw new TrxException("1301", "网上支付平台的响应报文不完整", "无[Signature-Algorithm]段！");
				}
				string signatureStr = rspJobj["MSG"]["Signature"]?.ToString();
				//string signatureStr = rspData.RspMsgBean.Signature;
				if (string.IsNullOrEmpty(signatureStr))
				{
					throw new TrxException("1301", "网上支付平台的响应报文不完整", "无[Signature]段！");
				}
				byte[] signature = Convert.FromBase64String(signatureStr);

				//RSACryptoServiceProvider rsacryptoServiceProvider =  (RSACryptoServiceProvider)mc.TrustpayCertificate.PublicKey.Key;
				//HashAlgorithm halg = new SHA1CryptoServiceProvider();
				//if (!rsacryptoServiceProvider.VerifyData(Encoding.GetEncoding("gb2312").GetBytes(rspmsgCotent), halg, signature))
				//{
				//	return new KeyValuePair<bool, TrxException>(false,new TrxException("1302", "网上支付平台的响应报文签名验证失败"));
				//}
				//NET Core使用
				/*
				 * 需要改用 System.Security.Cryptography.RSA.Create() 工厂方法，使用它之后，在 Windows 上创建的是 System.Security.Cryptography.RSACng 的实例，在 Mac 与 Linux 上创建的是 System.Security.Cryptography.RSAOpenSsl 的实例，它们都继承自 System.Security.Cryptography.RSA 抽象类。
				 */
				RSA rsa = RSA.Create();
				rsa.ImportRSAPublicKey(mc.TrustpayCertificate.GetPublicKey(), out int read);
                if (!rsa.VerifyHash(Encoding.GetEncoding("gb2312").GetBytes(rspmsgCotent), signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1))
                {
					return new KeyValuePair<bool, TrxException>(false, new TrxException("1302", "网上支付平台的响应报文签名验证失败"));
				}	 
				return new KeyValuePair<bool, TrxException>(true, null);
			}
			catch (TrxException trxerr)
			{
				return new KeyValuePair<bool, TrxException>(false, new TrxException("1302", $"签名验证失败-[{ trxerr.Message}] [{trxerr.DetailMessage}]"));
			}
			catch (Exception err)
            {
				return new KeyValuePair<bool, TrxException>(false, new TrxException("1302", "签名验证失败 - " + err.Message));
            }

		}

	}
}
