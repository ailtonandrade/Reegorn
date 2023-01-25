using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrange : ObjectDataModel
{
    // Start is called before the first frame update
    void Start()
    {
        this.id = 2;
        this.internalId = "C21S5";
        this.name = "CubeOrange";
    }

    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainLandControl>().ObjectSelectedTopCenterHUD(this);
    }
}
