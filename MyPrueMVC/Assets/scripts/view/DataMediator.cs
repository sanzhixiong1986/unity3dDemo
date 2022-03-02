using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;

public class DataMediator :Mediator{

    public new const string NAME = "dataMediator";

    //ui
    private Text Level_text;
    private Button AddLevel_btn;

    public DataMediator(GameObject gameObject):base(NAME){
        Level_text = gameObject.transform.Find("Level_Text").GetComponent<Text>();
        AddLevel_btn = gameObject.transform.Find("Add_btn").GetComponent<Button>();

        //发送事件
        AddLevel_btn.onClick.AddListener(onClickEvent);
    }

    private void onClickEvent(){
        Debug.Log("DataMediator clickEvent");
        SendNotification("Reg_StartDataCommand");//发送事件
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
            Debug.Log("Msg_AddLevel");
                Level_text.text = (notification.Body as MyData).Level.ToString();
            break;
        }
    }
}