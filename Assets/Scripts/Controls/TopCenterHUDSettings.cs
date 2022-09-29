using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCenterHUDSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetNameSelectedObject(string nameSelected){
        this.GetComponentInChildren<UnityEngine.UI.Text>().text = "hello";
    }
}
