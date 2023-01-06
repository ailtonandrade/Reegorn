using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Terrain : ObjectModel
{

    void Start()
    {
        this.Id = 0;
        this.InternalId = "A21S5";
        this.Name = "Terrain";
    }

    async void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HudControl>().ObjectSelectedTopCenterHUD(this);

    }
}
