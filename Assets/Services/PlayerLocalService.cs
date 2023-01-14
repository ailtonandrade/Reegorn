using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerLocalService : AbstractControl
{
    public static async void  SyncPlayerLocal(ObjectDataModel character)
    {
        try{
          var response =  await Post("brdcst/brod-ch-lo",character);
          string contents = await response.Content.ReadAsStringAsync();
          Logger("-- Sincronizado: "+ DateTime.Now);
        }catch (HttpRequestException e){
            Logger(e.InnerException.Message);
        }
    }
}
