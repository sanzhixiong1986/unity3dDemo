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

    static IData json_decode(string json)
    {
        IData data = null;
        data = JsonConvert.DeserializeObject<IData>(json);
        return data;
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
    static public IData decode_cmd(int proto_type ,string json)
    {
        if (proto_type == (int) proto_man.MyEnum.PROTO_JSON)
        {
            return json_decode(json);
        }

        return null;
    }
}
