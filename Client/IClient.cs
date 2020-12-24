using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Client
{
    public interface IClient
    {
        AbcRootResponse<TRsp>  Execute<T, TRsp>(AbcRootRequest<T,TRsp> req) where TRsp:Response.AbcResponse where T : Request.AbcTrxRequest<TRsp>;

        string SrcRequestContent { get;}

        string SrcResponseContent { get; }
    }
}
