using System.Collections;
using System.Collections.Generic;
using model.proxy;
using model.vo;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns.Command;

public class DataCtrl : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //接受数据改变的地方
        Debug.Log(notification.Body);
        ResponseVo res = proto_man.decode_cmd(0, (string)notification.Body);
        RoomProxy roomProxy = Facade.RetrieveProxy(RoomProxy.NAME) as RoomProxy;
        switch (res.stype)
        {
            case 1:
                roomProxy.setResVo(res);
                break;
        }
    }
}
