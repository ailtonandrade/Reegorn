using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Terrain : ObjectDataModel
{

    void Start()
    {
        this.id = 0;
        this.internalId = "A21S5";
        this.name = "Terrain";
    }

    async void OnMouseDown()
    {   
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainLandControl>().ObjectSelectedTopCenterHUD(this);

    }
}
