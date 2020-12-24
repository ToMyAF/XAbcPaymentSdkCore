using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAbcPaymentSdkCore.Request;
using XAbcPaymentSdkCore.Response;
using XAbcPaymentSdkCore.Util;

namespace XAbcPaymentSdkCore.Client
{
    public class DefaultAbcClient : IClient
    {
        private MerchantParameter _mp;
        public DefaultAbcClient(MerchantParameter mp)
        {
            _mp = mp;
        }

        public string SrcRequestContent { get; private set; }
        public string SrcResponseContent { get; private set; }

        public AbcRootResponse<TRsp> Execute<T, TRsp>(AbcRootRequest<T, TRsp> req)
            where T : AbcTrxRequest<TRsp>
            where TRsp : AbcResponse
        {
            //1.设定商户信息
            req.MessageInfo.MerchantInfo = new MerchantInfo 
            {
                MerchantID = _mp.MerchantID,
                ECMerchantType = AbcConstact.ECMerchantType
            };
            //2.生成业务数据Json
            string jsonData = JsonParseUtil.ToJson(req.MessageInfo);
            //3.生成签名
            string sign = SignXUtil.GenerateSignature(_mp, jsonData);
            req.SignatureAlgorithm = AbcConstact.SignatureAlgorithm;
            req.Signature = sign;
            //4.生成最终上送数据Json
            var finalJsonData = SrcRequestContent = JsonParseUtil.ToJson(req);
            //5.请求农行支付平台并获取返回结果
            NetHttpParams httpParams = new NetHttpParams 
            {
                NetParamType = ParamsType.NoParams,
                Charset = "utf-8",
                _NetType = NetType.POST,
                UrlEncoding = false,
                _ContentType = ContentType.Application_WWW,
                NetEncoding = Encoding.UTF8,
                Body = finalJsonData,
                URL = _mp.URL
            };
            string rspSrcData = SrcResponseContent = HttpClientTool.PostCall(httpParams,Encoding.GetEncoding("GB2312"));
            //6.验证签名(验证失败会抛出异常)
            var verifyResult =  SignXUtil.VerifySign(_mp, rspSrcData);
            AbcRootResponse<TRsp> rspBean = JsonParseUtil.Deserialize<AbcRootResponse<TRsp>>(rspSrcData);
            if (!verifyResult.Key)
            {
                rspBean.RspMsgBean.Message.ErrorMessage = verifyResult.Value.Message + verifyResult.Value.DetailMessage;
            }
            return rspBean;
        }
    }
}
