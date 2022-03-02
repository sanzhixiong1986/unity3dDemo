﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Patterns.Facade;

public class ApplicationFacade : Facade
{
    public ApplicationFacade(GameObject gameObject): base("ApplicationFacade"){
        //定义对应的关系
        RegisterCommand("Reg_StartDataCommand",()=>{return new DataCtrl();});
        //试图注册
        RegisterMediator(new DataMediator(gameObject));
        //数据注册
        RegisterProxy(new DataProxy());
    }
}
