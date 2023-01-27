using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag(Common.playerTag).GetComponent<HUDMainControl>().ObjectSelectedTopCenterHUD(this.gameObject);
    }
}
