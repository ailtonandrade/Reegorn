using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SyncService : AbstractControl
{
    public static async Task SyncCharacterLocal(ObjectModel character)
    {
        try{
          var response = Post("brdcst/brod-ch-lo",character);
          string contents = await response.Content.ReadAsStringAsync();
          Logger("-- Sincronizado: "+ DateTime.Now);
          await Task.Delay(10000);
        }catch (HttpRequestException e){
            Logger(e.InnerException.Message);
        }
    }
    
    public static async Task<SceneModel> SyncSchene(string scene)
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
