using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  CharacterSettings : AbstractControl
{
    public static float positionX;
    public static float positionY;
    public static float positionZ;
    public static float rotation;
    // Start is called before the first frame update
    void Start()
    {
        positionX = 0;
        positionY = 11;
        positionZ = 0;
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static string getJson(){
        return ToJson(new {positionX,positionY,positionZ,rotation});
    }
}
