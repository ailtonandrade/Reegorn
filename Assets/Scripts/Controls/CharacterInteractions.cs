using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
using UnityEngine.UI;
using TMPro;

public class CharacterInteractions : MonoBehaviour
{
    public int objClickedId;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {



    }
    public void ObjectInteracted(ObjectsModel obj){
        SetHUDTopCenter(obj.Name,obj.Hp);
        Logger(obj.Id,obj.Name,obj.InternalId);
    }
    public void Logger(int? id,string? name,string? internalId){
        print($"{id} - {name} - {internalId}");
        print(AuthenticateService.session);

    }
    public void SetHUDTopCenter(string name, string? hp){
        GameObject TopCenterHUD = GameObject.Find("TopCenterHUD");

        TopCenterHUD.GetComponent<TopCenterHUDSettings>()
        .SetNameSelectedObject(name);

        TopCenterHUD.GetComponent<TopCenterHUDSettings>()
        .SetHpSelectedObject(hp);
    }
}
