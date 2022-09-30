using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopCenterHUDSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetNameSelectedObject(string? nameSelected){
        GameObject.Find("NameSelectedObject").GetComponent<TextMeshProUGUI>().text = "hello";
    }
    public void SetHpSelectedObject(string? hpSelected){
        GameObject.Find("HPSelectedObject").GetComponent<TextMeshProUGUI>().text = "14154541";
    }
}
