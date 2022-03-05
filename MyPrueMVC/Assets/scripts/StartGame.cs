using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using WebSocketSharp;

using Newtonsoft.Json;

public class StartGame : MonoBehaviour
{
    private WebSocket ws;
    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://localhost:6081");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from "+((WebSocket)sender).Url+", Data : "+e.Data);
        };
    }
    private void Update()
    {
        if(ws == null)
        {
            return;
        }

        MyData myData = new MyData();
        myData.Level = 1;
        string json = JsonConvert.SerializeObject(myData);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send(json);
        }  
    }   
}

