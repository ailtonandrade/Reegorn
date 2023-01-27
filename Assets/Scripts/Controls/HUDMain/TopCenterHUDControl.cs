using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopCenterHUDControl : AbstractControl
{
    public void SetName(string name){
        GameObject.Find("NameSelectedObject").GetComponent<TextMeshProUGUI>().text = name;
    }
    public void SetHp(long? hp){
        GameObject.Find("HPSelectedObject").GetComponent<TextMeshProUGUI>().text = hp.ToString();
    }
}
