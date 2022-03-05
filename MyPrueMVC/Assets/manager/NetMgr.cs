using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using WebSocketSharp;

enum State
{
    Disconnected,   //断开
    Connecting,     //正在链接
    Connected,      //链接成功
}

public class NetMgr : MonoBehaviour
{
    // Start is called before the first frame update
    private string url = "ws://127.0.0.1:6081";
    private int state = (int)State.Disconnected;
    private WebSocket ws = null;
    public static NetMgr Instance = null;

    private void  setState(int state)
    {
        this.state = state;
    }
    void Start()
    {
        if (NetMgr.Instance == null)
        {
            NetMgr.Instance = this;
            return;
        }

        this.setState((int)State.Disconnected);
    }

    
    public void connet_to_server()
    {
        if (this.state != (int) State.Disconnected) {
            return;
        }
        
        this.setState((int)State.Connecting);
        this.ws = new WebSocket(url);
        this.ws.Connect();

        this.ws.OnMessage += (sender, e) =>
        {
            //收到数据的部分
        };

        this.ws.OnOpen += (sender, args) =>
        {
            //链接刚打开的部分
            this.setState((int) State.Connected);
            //通知command接受到对应的信息
        };

        this.ws.OnClose += (sender, args) =>
        {
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
    public void send_data(string json)
    {
        if (this.state != (int) State.Disconnected)
        {
            return;
        }
        
        this.ws.Send(json);
    }

    // Update is called once per frame
    void Update()
    {
        //多链接
        if (this.state != (int)State.Disconnected)
        {
            return;
        }
        this.connet_to_server();//做链接
    }
}
