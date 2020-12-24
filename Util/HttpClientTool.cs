using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace XAbcPaymentSdkCore.Util
{
    public static class HttpClientTool
    {

        public static string PostCall(NetHttpParams netParam)
        {
            string result = string.Empty;
            //请求被中止: 未能创建 SSL/TLS 安全通道
            HttpWebRequest req = null;
            switch (netParam.NetParamType)
            {

                case ParamsType.Header:
                    req = (HttpWebRequest)WebRequest.Create($"{netParam.URL}");
                    req.Headers.Add(GetWebHeaderCollection(netParam.SpecialParams));
                    break;
                case ParamsType.QueryParams:
                    string theUrl = netParam.UrlEncoding ? HttpUtility.UrlEncode($"{netParam.URL}?{KeyValueHandle(netParam.SpecialParams)}") : $"{netParam.URL}?{KeyValueHandle(netParam.SpecialParams)}";
                    req = (HttpWebRequest)WebRequest.Create(theUrl);
                    break;
                case ParamsType.NoParams:
                    req = (HttpWebRequest)WebRequest.Create($"{netParam.URL}");
                    break;
                default:
                    break;
            }
            if (netParam.URL.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                ServicePointManager.ServerCertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => { return true; };
            }
            req.Method = GetNetType(netParam._NetType);
            req.ContentType = $"{GetContentType(netParam._ContentType)}{netParam.Charset}";
            //0613增加
            req.KeepAlive = true;
            req.ProtocolVersion = HttpVersion.Version11;
            ServicePointManager.DefaultConnectionLimit = netParam.Limit;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.Expect100Continue = false;
            #region 添加Post 参数
            byte[] data = netParam.NetEncoding.GetBytes(netParam.Body);
            req.ContentLength = data.Length;
            
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }
            
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            if (req != null)
            {
                req.Abort();
                req = null;
            }
            if (resp != null)
            {
                resp.Close();
            }
            //URL转码
            return result; //HttpUtility.UrlDecode(result, netParam.NetEncoding);
        }

        public static string PostCall(NetHttpParams netParam, Encoding streamreadencode)
        {
            string result = string.Empty;
            //请求被中止: 未能创建 SSL/TLS 安全通道
            HttpWebRequest req = null;
            switch (netParam.NetParamType)
            {

                case ParamsType.Header:
                    req = (HttpWebRequest)WebRequest.Create($"{netParam.URL}");
                    req.Headers.Add(GetWebHeaderCollection(netParam.SpecialParams));
                    break;
                case ParamsType.QueryParams:
                    string theUrl = netParam.UrlEncoding ? HttpUtility.UrlEncode($"{netParam.URL}?{KeyValueHandle(netParam.SpecialParams)}") : $"{netParam.URL}?{KeyValueHandle(netParam.SpecialParams)}";
                    req = (HttpWebRequest)WebRequest.Create(theUrl);
                    break;
                case ParamsType.NoParams:
                    req = (HttpWebRequest)WebRequest.Create($"{netParam.URL}");
                    break;
                default:
                    break;
            }
            if (netParam.URL.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                ServicePointManager.ServerCertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => { return true; };
            }
            req.Method = GetNetType(netParam._NetType);
            req.ContentType = $"{GetContentType(netParam._ContentType)}{netParam.Charset}";
            //0613增加
            req.KeepAlive = true;
            req.ProtocolVersion = HttpVersion.Version11;
            ServicePointManager.DefaultConnectionLimit = netParam.Limit;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.Expect100Continue = false;
            #region 添加Post 参数
            byte[] data = netParam.NetEncoding.GetBytes(netParam.Body);
            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }

            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, streamreadencode))
            {
                result = reader.ReadToEnd();
            }
            if (req != null)
            {
                req.Abort();
                req = null;
            }
            if (resp != null)
            {
                resp.Close();
            }
            //URL转码
            return result;
        }

        #region Http枚举解析
        /// <summary>
        /// 获取请求类型
        /// </summary>
        /// <param name="netType"></param>
        /// <returns></returns>
        private static string GetNetType(NetType netType)
        {
            switch (netType)
            {
                case NetType.POST:
                    return "POST";
                case NetType.GET:
                    return "GET";
                case NetType.DELETE:
                    return "DELETE";
                case NetType.PUT:
                    return "PUT";
                default:
                    return null;
            }
        }
        /// <summary>
        /// 请求体格式
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        private static string GetContentType(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.Application_WWW:
                    return "application/x-www-form-urlencoded;";
                case ContentType.Application_Json:
                    return "application/json;";
                case ContentType.textplain:
                    return "text/plain";
                case ContentType.textjson:
                    return "text/json;";
                case ContentType.textxml:
                    return "text/xml;";
                case ContentType.application_xml:
                    return "application/xml;";
                default:
                    return null;
            }
        }
        #endregion

        #region Http辅助方法
        /// <summary>
        /// 键值对请求参数拼接
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string KeyValueHandle(IDictionary<string, object> param)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string key in param.Keys)
            {
                sb.Append(key + "=" + param[key] + "&");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        /// <summary>
        /// Http请求头参数添加
        /// </summary>
        /// <param name="HeaderParameter"></param>
        /// <returns></returns>
        private static WebHeaderCollection GetWebHeaderCollection(IDictionary<string, object> HeaderParameter)
        {
            WebHeaderCollection webHeader = new WebHeaderCollection();
            foreach (string key in HeaderParameter.Keys)
            {

                webHeader.Add(key, HeaderParameter[key].ToString());
            }
            return webHeader;
        }
        #endregion
    }
    /// <summary>
    /// HttpRequestType
    /// </summary>
    public enum NetType
    {
        POST = 1,
        GET = 2,
        PUT = 3,
        DELETE = 4
    }
    /// <summary>
    /// 请求参数类型
    /// </summary>
    public enum ParamsType
    {
        Header = 0,
        QueryParams = 1,
        NoParams = 2
    }
    /// <summary>
    /// HttpContentType
    /// </summary>
    public enum ContentType
    {
        Application_WWW = 1,
        Application_Json = 2,
        textplain = 3,
        textxml = 4,
        textjson = 5,
        application_xml = 6
    }
    public class NetHttpParams
    {
        public string URL { get; set; }

        public ParamsType NetParamType { get; set; }

        public string Body { get; set; }

        public Encoding NetEncoding { get; set; } = Encoding.UTF8;

        public NetType _NetType { get; set; }

        public ContentType _ContentType { get; set; }

        public string Charset { get; set; }

        public IDictionary<string, object> SpecialParams { get; set; }

        public bool UrlEncoding { get; set; } = false;

        public int Limit { get; set; } = 200;
    }
}
