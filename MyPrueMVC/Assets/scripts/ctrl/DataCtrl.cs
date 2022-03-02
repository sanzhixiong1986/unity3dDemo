using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns.Command;

public class DataCtrl : SimpleCommand
{
    public override void Execute(INotification notification){
        //接受数据改变的地方
        DataProxy dataProxy = Facade.RetrieveProxy(DataProxy.NAME) as DataProxy;
        dataProxy.AddLevel(5);
    }
}
