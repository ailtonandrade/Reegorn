using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOrange : MonoBehaviour
{
    public ObjectsModel infos;
    // Start is called before the first frame update
    void Start()
    {
        infos.Id = 2;
        infos.InternalId = "C21S5";
        infos.Name = "CubeOrange";
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteractions>().ObjectInteracted(infos);
    }
}
