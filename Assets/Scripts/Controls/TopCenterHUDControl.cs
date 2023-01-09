using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopCenterHUDControl : AbstractControl
{
    public void SetNameSelectedObject(string? nameSelected){
        GameObject.Find("NameSelectedObject").GetComponent<TextMeshProUGUI>().text = nameSelected;
    }
    public void SetHpSelectedObject(string? hpSelected){
        GameObject.Find("HPSelectedObject").GetComponent<TextMeshProUGUI>().text = hpSelected;
    }
}
