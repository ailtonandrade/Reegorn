using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrange : ObjectDataModel
{
    // Start is called before the first frame update
    void Start()
    {
        this.Id = 2;
        this.InternalId = "C21S5";
        this.Name = "CubeOrange";
    }

    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainLandControl>().ObjectSelectedTopCenterHUD(this);
    }
}
