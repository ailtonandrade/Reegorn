using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopCenterHUDControl : AbstractControl
{
    public void SetName(string nameSelected){
        GameObject.Find("NameSelectedObject").GetComponent<TextMeshProUGUI>().text = nameSelected;
    }
    public void SetHp(string hpSelected){
        GameObject.Find("HPSelectedObject").GetComponent<TextMeshProUGUI>().text = hpSelected;
    }
}
