using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class BroadcastingService : MonoBehaviour
{
    public static async Task sendChLocalPos(Vector3 _pos, float _rot)
    {
        try{
          var response = UtilService.Post(UtilService.Uri("brdcst/brod-ch-lo"),UtilService.Content(BrodChLo.parse(_pos,_rot)).Result;
          string contents = await response.Content.ReadAsStringAsync();
          Debug.Log("Posição Nova Enviada");
          await Task.Delay(10000);
        }catch (HttpRequestException e){
            Debug.Log(e.InnerException.Message);
        }
    }
}
