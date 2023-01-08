using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SessionService : AbstractControl
{
    public static async Task<SceneModel> SyncScene(string scene)
    {
        try{
          var response = Post("brdcst/brod-scene",scene);
          string response = await response.Content.ReadAsStringAsync();
          SceneModel sceneData = JsonConvert.DeserializeObject<SceneModel>(response);
          
          Logger("-- Cena Sincronizada: "+   DateTime.Now);
          await Task.Delay(5000);
          return sceneData;
        }catch (HttpRequestException e){
            Logger(e.InnerException.Message);
        }
    }
}
