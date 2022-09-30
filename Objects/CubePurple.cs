using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePurple : MonoBehaviour
{
    public ObjectsModel infos;
    // Start is called before the first frame update
    void Start()
    {
        infos.Id = 1;
        infos.InternalId = "B21S5";
        infos.Name = "CubePurple";
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
