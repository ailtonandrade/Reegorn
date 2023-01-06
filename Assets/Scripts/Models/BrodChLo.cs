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
public BrodChLo(){
     }
     
public static BrodChLo parse(Vector3 pos,float rot){
    BrodChLo b = new BrodChLo();
    b.posX = _pos.x.ToString("N3");
    b.posY = _pos.y.ToString("N3");
    b.posZ = _pos.z.ToString("N3");
    b.rot = _rot.ToString("N3"); 
return b;
}
