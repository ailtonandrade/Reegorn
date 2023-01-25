using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  CharacterSettings : AbstractControl
{
    public static string name;
    public static string acc;
    public static float positionX;
    public static float positionY;
    public static float positionZ;
    public static float rotation;
    public static string idSession;
    public static int isOnline;

    public static string getJson(){
        return ToJson(new {name,acc,positionX,positionY,positionZ,rotation,idSession,isOnline});
    }
}
