using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePurple : ObjectModel
{
    // Start is called before the first frame update
    void Start()
    {
        this.Id = 1;
        this.InternalId = "B21S5";
        this.Name = "CubePurple";
    }

    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainLandControl>().ObjectSelectedTopCenterHUD(this);
    }
}
