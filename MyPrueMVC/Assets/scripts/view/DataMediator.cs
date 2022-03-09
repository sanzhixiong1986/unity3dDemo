using System.Collections;
using System.Collections.Generic;
using model.vo;
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
        _netMgr = NetMgr.getInstace();
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
        
        if (_netMgr != null)
        {
            RoomEnter idata = new RoomEnter();
            idata.stype = 1;
            idata.ctype = 1;
            idata.body = new Human();
            idata.body.uname = "sanzhixiong";
            idata.body.usex = 0;
            _netMgr.send_data(idata);
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
            Debug.Log("Msg_AddLevel=============="+notification.Body);
            
                Level_text.text = "进入房间成功 ";
            //Level_text.text = (notification.Body as MyData).Level.ToString();
            break;
        }
    }
}