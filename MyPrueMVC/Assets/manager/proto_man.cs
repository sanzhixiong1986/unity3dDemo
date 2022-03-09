using System.Collections;
using System.Collections.Generic;
using model.vo;
using UnityEngine;

using Newtonsoft.Json;
public class proto_man 
{
    enum MyEnum
    {
        PROTO_JSON,
        PROTO_BUF,
    }
    
    //加密
    static string encrtpt_cmd(string strr_of_buf)
    {
        return strr_of_buf;
    }
    
    //加密
    static string decrypt(string strr_of_buf)
    {
        return strr_of_buf;
    }

    //打包成json
    static string _json_encode(IData data)
    {
        return JsonConvert.SerializeObject(data);
    }

    static ResponseVo json_decode(string json)
    {
        return (ResponseVo)JsonConvert.DeserializeObject<ResponseVo>(json);
    }

    static public string encode_cmd(IData idata,int proto_type)
    {
        string json = null;
        if (proto_type == 1)
        {
            json = _json_encode(idata);
        }

        return json;
    }
    
    //揭开
    static public ResponseVo decode_cmd(int proto_type ,string json)
    {
        if (proto_type == (int) proto_man.MyEnum.PROTO_JSON)
        {
            if (json == null)
            {
                Debug.LogError("decode_cmd is json idata is error");
            }
            return json_decode(json);
        }

        return null;
    }
}
