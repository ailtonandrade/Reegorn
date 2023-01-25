using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
using UnityEngine.UI;
using TMPro;

public class HUDMainLandControl : AbstractControl
{
    public int objClickedId;

    public void ObjectSelectedTopCenterHUD(ObjectDataModel obj){

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetName(obj.name);

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetHp(obj.hp);

        Logger(ToJson(obj));
    }

}

