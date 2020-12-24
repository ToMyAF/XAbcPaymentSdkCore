using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace XAbcPaymentSdkCore.Client
{
	public class MerchantParameter
	{
		public string MerchantNotifyURL { get; set; }

		public  string KeyStoreType { get; set; }

		public  string TrustPayNewLine { get; set; }

		public  string URL { get; set; }

		//public  string TrustPayIETrxURL { get; set; }

		public  string MerchantErrorURL { get; set; }

		public X509Certificate2 TrustpayCertificate => GetCertificate(this.AbcPulicCertPath);


		public string MerchantID { get; set; }

		public RSA MerchantKey => GetMerchantPrivateKeyByFile(this.MerchantPfxPath, this.MerchantPfxPass);

		public string MerchantPfxPath { get; set; }

		public string MerchantPfxPass { get; set; }

		public string AbcPulicCertPath { get; set; }

		public string AbcTrustStorePath { get; set; }

		public string AbcTrustStorePassword { get; set; }

		private X509Certificate2 GetCertificate(string certFile)
		{
			try
			{
				return new X509Certificate2(certFile);
			}
			catch (Exception ex)
			{
				throw new TrxException("1002", "无法读取证书文档[" + certFile + "]！");
			}
		}
		private RSA GetMerchantPrivateKeyByFile(string pfxfile,string pwd)
		{
			X509Certificate2 x509Certificate = null;
			try
			{
				x509Certificate = new X509Certificate2(pfxfile, pwd, X509KeyStorageFlags.MachineKeySet);
				DateTime certDate = Convert.ToDateTime(x509Certificate.GetExpirationDateString());
				if (certDate < DateTime.Now)
				{
					throw new TrxException("1999", $"{pfxfile}证书已过期失效");
				}
				return x509Certificate.GetRSAPrivateKey();
			}
			catch (Exception ex)
			{
				throw new TrxException("1999", $"无法读取{pfxfile}证书文档", ex.Message + ex.StackTrace);
			}
		}
	}
}
