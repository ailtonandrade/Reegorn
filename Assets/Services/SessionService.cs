using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class SessionService : AbstractControl
{
    public static async Task<SessionModel> SyncSession(string session)
    {
        try{
          var request = Post("sync/session-elements",session);
          string response = await request.Content.ReadAsStringAsync();
          SessionModel sessionData = JsonConvert.DeserializeObject<SessionModel>(response);
          
          Logger("-- Sessão Sincronizada: "+   DateTime.Now);
          await Task.Delay(5000);
          return sessionData;
        }catch (HttpRequestException e){
            Logger(e.InnerException.Message);
        }
        return null;
    }
}
