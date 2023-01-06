using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrodChLo
{
    public string posX {get;set;}
    public string posY {get;set;}
    public string posZ {get;set;}
    public string rot {get;set;}
}

public static BrodChLo parse(Vector3 pos,float rot){
this.posX = _pos.x.ToString("N3");
this.posY = _pos.y.ToString("N3");
this.posZ = _pos.z.ToString("N3");
this.rot = _rot.ToString("N3"); 
}
