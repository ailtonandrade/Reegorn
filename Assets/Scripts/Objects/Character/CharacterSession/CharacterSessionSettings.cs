using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSessionSettings : MonoBehaviour
{
    void Start()
    {

    }

    async void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainControl>().ObjectSelectedTopCenterHUD(this.gameObject);

    }
}
