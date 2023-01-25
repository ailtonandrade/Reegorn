using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePurple : ObjectDataModel
{
    // Start is called before the first frame update
    void Start()
    {
        this.id = 1;
        this.internalId = "B21S5";
        this.name = "CubePurple";
    }

    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainLandControl>().ObjectSelectedTopCenterHUD(this);
    }
}
