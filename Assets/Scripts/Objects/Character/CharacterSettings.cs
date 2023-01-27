using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : AbstractControl
{
    public static string name;
    public static float hp;
    public static string acc;
    public static string local;
    public static string world;
    public static float positionX;
    public static float positionY;
    public static float positionZ;
    public static float rotation;
    public static string idSession;
    public static int isOnline;

    public static string getJson()
    {
        return ToJson(new { name, acc, hp, positionX, positionY, positionZ, rotation, idSession, local, world, isOnline });
    }
}
