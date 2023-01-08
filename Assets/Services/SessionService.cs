using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SessionService : AbstractControl
{
    public static async Task<SceneModel> SyncSession(string session)
    {
        try{
          var response = Post("brdcst/brod-session",scene);
          string response = await response.Content.ReadAsStringAsync();
          SessionModel sessionData = JsonConvert.DeserializeObject<SessionModel>(response);
          
          Logger("-- Sessão Sincronizada: "+   DateTime.Now);
          await Task.Delay(5000);
          return sessionData;
        }catch (HttpRequestException e){
            Logger(e.InnerException.Message);
        }
    }
}
