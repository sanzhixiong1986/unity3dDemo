using System.Collections;
using System.Collections.Generic;
using model.vo;
using UnityEngine;

public class MyData:IData{
    private int _level = 0;

    private int Stype = 0;

    private int Ctype = 0;

    private string Body = "";
    //等级属性
   
    public int stype
    {
        get => Stype;
        set => Stype = value;
    }
    
    public int ctype
    {
        get => Ctype;
        set => Ctype = value;
    }
    
    public string body
    {
        get => Body;
        set => Body = value;
    }
}