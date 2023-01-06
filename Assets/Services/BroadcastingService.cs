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
    public static async Task sendMovChLo(Vector3 _pos, float _rot)
    {
        
        BrodChLo BrodChLo = new BrodChLo();
        BrodChLo.posX = _pos.x.ToString("N3");
        BrodChLo.posY = _pos.y.ToString("N3");
        BrodChLo.posZ = _pos.z.ToString("N3");
        BrodChLo.rot = _rot.ToString("N3"); 
        string contents = "";
        try
        {
        var response = UtilService.GenPostAsync(UtilService.GenUri("brdcst/brod-ch-lo"),
                                                      UtilService.GenContent(BrodChLo,null)).Result;
        contents = await response.Content.ReadAsStringAsync();
        Debug.Log("Posição Nova Enviada");
        await Task.Delay(10000);
        }catch (HttpRequestException e){
            Debug.Log(e.InnerException.Message);
        }
    }
}
