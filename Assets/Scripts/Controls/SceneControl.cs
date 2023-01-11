using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : SessionService
{
    public static void PushDrop(string? sceneLoad,string? sceneUnload){
        if(!string.IsNullOrEmpty(sceneLoad)){
            Common.scene = sceneLoad;
            SceneManager.LoadScene(sceneLoad, LoadSceneMode.Single);
            //await SyncSession(sceneLoad);
        }
        if(!string.IsNullOrEmpty(sceneUnload))
            SceneManager.UnloadSceneAsync(sceneUnload);

    }
        public static void Push(string? sceneLoad){
            Common.scene = sceneLoad;
            SceneManager.LoadScene(sceneLoad, LoadSceneMode.Single);
    }
}