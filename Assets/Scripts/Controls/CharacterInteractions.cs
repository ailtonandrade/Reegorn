using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
using UnityEngine.UI;
using TMPro;

public class CharacterInteractions : MonoBehaviour
{
    public TextMeshPro NameSelectedObject;
    public int objClickedId;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void ObjectInteracted(ObjectsModel obj){
        SetHUDTopCenter(obj.Name,obj.Hp);
        Logger(obj.Id,obj.Name,obj.InternalId);
    }
    public void Logger(int? id,string? name,string? internalId){
        print(id);
        print(name);
        print(internalId);
    }
    public void SetHUDTopCenter(string name, string? hp){
        TextMeshPro element = GameObject.Find("HUD")
                        .gameObject.transform.GetChild(0)
                        .gameObject.transform.GetChild(0).gameObject.transform.GetComponent<TextMeshPro>();
        element.SetText(name);
        //GameObject.Find("HPSelectedObject").GetComponent<Text>().text = hp;
    }
}
