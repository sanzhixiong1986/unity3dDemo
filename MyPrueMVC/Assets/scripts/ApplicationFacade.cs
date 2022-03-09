using System.Collections;
using System.Collections.Generic;
using model.proxy;
using UnityEngine;

using PureMVC.Patterns.Facade;

public class ApplicationFacade : Facade
{
    public ApplicationFacade(GameObject gameObject): base("ApplicationFacade"){
        //定义对应的关系
        RegisterCommand("Reg_StartDataCommand",()=>{return new DataCtrl();});
        //试图注册
        RegisterMediator(new DataMediator(gameObject));
        // RegisterMediator(NetMgr.getInstace());
        //数据注册
        RegisterProxy(new DataProxy());
        //聊天的数据处理
        RegisterProxy(new RoomProxy());
    }
}
