using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Proxy;

public class DataProxy :Proxy{

    public new const string NAME = "DataProxy";

    private MyData _mydata;

    public DataProxy():base(NAME){
        _mydata = new MyData();
    }

    public void AddLevel(int level){
        _mydata.Level += level;
        SendNotification("Msg_AddLevel",_mydata);
    }
}