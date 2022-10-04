using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static void Push(string? sceneLoad,string? sceneUnload){
        if(!string.IsNullOrEmpty(sceneLoad))
            SceneManager.LoadScene(sceneLoad, LoadSceneMode.Single);
        
        if(!string.IsNullOrEmpty(sceneUnload))
            SceneManager.UnloadSceneAsync(sceneUnload);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
