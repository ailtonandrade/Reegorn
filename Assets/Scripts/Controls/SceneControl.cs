using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : SyncService
{
    // Start is called before the first frame update
    public static void PushDrop(string? sceneLoad,string? sceneUnload){
        if(!string.IsNullOrEmpty(sceneLoad)){
            SceneManager.LoadScene(sceneLoad, LoadSceneMode.Single);
            getAllObj(sceneLoad);

        }
        
        if(!string.IsNullOrEmpty(sceneUnload))
            SceneManager.UnloadSceneAsync(sceneUnload);
    }
}