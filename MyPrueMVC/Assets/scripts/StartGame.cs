using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using WebSocketSharp;



public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        new ApplicationFacade(this.gameObject);
        NetMgr.getInstace().connet_to_server();
    }
}

