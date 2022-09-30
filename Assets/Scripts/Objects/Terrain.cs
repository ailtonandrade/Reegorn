using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Terrain : MonoBehaviour
{
    EnvironmentObjectsService service = new EnvironmentObjectsService();
    public int Id = 0;
    public string InternalId = "A21S5";
    public string Name = "Terrain";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    async void OnMouseDown()
    {
        ObjectsModel infos = new ObjectsModel();
        infos.Id = Id;
        infos.InternalId = InternalId;
        infos.Name = Name;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteractions>().ObjectInteracted(infos);

    }
}
