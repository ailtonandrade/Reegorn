using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HUDRegisterControl : AbstractControl
{
    void Start()
    {
        onClickButtonCloseRegister();
    }
    void onClickButtonCloseRegister()
    {
        GameObject.Find("CloseRegisterModal").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject objetoEncontrado = GameObject.Find("RegisterModal");
            Destroy(objetoEncontrado, 0f);
        });
    }
}
