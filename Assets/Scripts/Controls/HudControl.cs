using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
using UnityEngine.UI;
using TMPro;

public class HudControl : AbstractControl
{
    public int objClickedId;


    public void ObjectSelectedTopCenterHUD(ObjectModel obj){

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetNameSelectedObject(obj.Name);

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetHpSelectedObject(obj.Hp);

        Logger(ToJson(obj));
    }

}
