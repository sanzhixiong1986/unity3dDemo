using System;
using System.Collections;
using System.Collections.Generic;
using model.vo;
using UnityEngine;
using UnityEngine.Android;
using BestHTTP;
using BestHTTP.WebSocket;

using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Mediator;


enum State
{
    Disconnected,   //断开
    Connecting,     //正在链接
    Connected,      //链接成功
}

public class NetMgr : Facade
{
    private string url = "ws://127.0.0.1:6081/ws";
    private int state = (int)State.Disconnected;
    private WebSocket ws = null;
    private static NetMgr Instance = null;

    public static NetMgr getInstace()
    {
        if (NetMgr.Instance == null)
        {
            NetMgr.Instance = new NetMgr();
            return NetMgr.Instance;
        }
        return NetMgr.Instance;
    }
    public NetMgr() : base("NetMgr")
    {
        this.setState((int)State.Disconnected);
    }
    // Start is called before the first frame update
    

    private void  setState(int state)
    {
        this.state = state;
    }

    public void connet_to_server()
    {
        Debug.Log("链接成功");
        if (this.state != (int) State.Disconnected) {
            return;
        }
        
        this.setState((int)State.Connecting);
        this.ws = new WebSocket(new Uri(url));
        this.ws.Open();


        this.ws.OnMessage += (sender, e) =>
        {
            
            Debug.Log(e);
            if (e != "1")
            {
                this.SendNotification("Reg_StartDataCommand",e);
            }
        };

        this.ws.OnOpen += (sender) =>
        {
            Debug.Log("与服务器链接");
            //链接刚打开的部分
            this.setState((int) State.Connected);
            //通知command接受到对应的信息
        };

        this.ws.OnClosed += (WebSocket ws, UInt16 code, string message) =>
        {
            Debug.LogError("OnClose");
            //服务器关闭
            if (this.state == (int) State.Connected)
            {
                if (this.ws != null)
                {
                    this.ws.Close();
                    this.ws = null;
                }
                //发送消息command
                this.setState((int)State.Disconnected);
            }
        };

        this.ws.OnError += (sender, args) =>
        {
            Debug.LogError("OnError");
            //出现错误的时候
            //服务器关闭
            if (this.state == (int) State.Connected)
            {
                if (this.ws != null)
                {
                    this.ws.Close();
                    this.ws = null;
                }
                //发送消息command
                this.setState((int)State.Disconnected);
            }
        };
    }

    //发送数据
    public void send_data(IData idata)
    {
        if (this.state == (int) State.Disconnected)
        {
            return;
        }

        string json = proto_man.encode_cmd(idata,1);
        this.ws.Send(json);
    }
}
