using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SceneService : AbstractControl
{
    public static async void getAllObj(string sceneName)
    {
        var response = Post("environment-object",sceneName);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var contents = await response.Content.ReadAsStringAsync();
            Logger(ToJson(contents));
            Logger("Informações de Ojetos de Ambiente Carregadas!");
        }
        else
        {
            Logger("Erro ao carregar Informações de Ojetos de Ambiente");
        }

    }

}
