using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
using UnityEngine.UI;
using TMPro;

public class HUDMainControl : AbstractControl
{
    public void ObjectSelectedTopCenterHUD(GameObject obj)
    {
        ObjectData objectData = obj.GetComponent<ObjectData>();

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetName(objectData.name);

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetHp(objectData.hp);
    }
    public void ObjectSelectedTopCenterHUD()
    {
        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
                .SetName("");

        GameObject.Find("TopCenterHUD").GetComponent<TopCenterHUDControl>()
        .SetHp(null);
    }

}

