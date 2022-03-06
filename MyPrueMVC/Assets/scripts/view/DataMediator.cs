using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;

using Newtonsoft.Json;

public class DataMediator :Mediator{

    public new const string NAME = "dataMediator";

    //ui
    private Text Level_text;
    private Button AddLevel_btn;
    private NetMgr _netMgr = null;

    public DataMediator(GameObject gameObject):base(NAME){
        Level_text = gameObject.transform.Find("Level_Text").GetComponent<Text>();
        AddLevel_btn = gameObject.transform.Find("Add_btn").GetComponent<Button>();
        _netMgr = GameObject.Find("net").GetComponent<NetMgr>();
        //发送事件
        AddLevel_btn.onClick.AddListener(onClickEvent);
    }

    private string crateJson()
    {
        MyData myData = new MyData();
        return JsonConvert.SerializeObject(myData);
    }

    private void onClickEvent(){
        Debug.Log("DataMediator clickEvent"+_netMgr);
        // SendNotification("Reg_StartDataCommand");//发送事件
        if (_netMgr)
        {
            MyData myData = new MyData();
            myData.stype = 1;
            myData.ctype = 2;
            myData.body = "helloworld";
            _netMgr.send_data(myData);
        }
        
    }

    //坚挺事件
    public override string[] ListNotificationInterests(){
        List<string> listResults = new List<string>();
        listResults.Add("Msg_AddLevel");
        
        return listResults.ToArray();
    }

    //处理坚挺事件
    public override void HandleNotification(INotification notification){
        
        switch(notification.Name){
            case "Msg_AddLevel":
            Debug.Log("Msg_AddLevel==============");
                //Level_text.text = (notification.Body as MyData).Level.ToString();
            break;
        }
    }
}