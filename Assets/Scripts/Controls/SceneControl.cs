using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : SessionService
{
    public static async void PushDrop(string? sceneLoad,string? sceneUnload){
        if(!string.IsNullOrEmpty(sceneLoad)){
            SceneManager.LoadScene(sceneLoad, LoadSceneMode.Single);
            await SyncSession(sceneLoad);

        }
        
        if(!string.IsNullOrEmpty(sceneUnload))
            SceneManager.UnloadSceneAsync(sceneUnload);
    }
    public static async Task PushDropAccAsync(string? sceneLoad,string? param,string? sceneUnload){
        switch(sceneLoad){
            case "SELECT_CHARACTER" :{
                ObjectDataModel obj = new ObjectDataModel();
                obj.Session = "SELECT_CHARACTER";
                obj.Name = param;
                List<CharacterModel> response = await getCharacterList(obj);
                //TODO BUILD LIST CHARACTER(RESPONSE)
                SceneManager.LoadScene(sceneLoad, LoadSceneMode.Single);
                SceneManager.UnloadSceneAsync(sceneUnload);

                break;
            }
            case "MainLand" :{
                break;
            }
        }
        
        
    }
}