using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using WebSocketSharp;

using Newtonsoft.Json;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        new ApplicationFacade(this.gameObject);
        this.gameObject.AddComponent<NetMgr>();
    }
}

