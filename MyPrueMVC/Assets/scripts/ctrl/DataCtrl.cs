using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PureMVC.Interfaces;
using PureMVC.Patterns.Command;

public class DataCtrl : SimpleCommand
{
    public override void Execute(INotification notification){
        //接受数据改变的地方
        Debug.Log("12j3lk1jl3k2jlk13ljj1l3k2j");
        Debug.Log(notification.Name);
    }
}
