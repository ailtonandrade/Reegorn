using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class EnvironmentObjectsService : MonoBehaviour
{
    void Start()
    {
        getAllEnvironmentObject();
    }
    public async void getAllEnvironmentObject()
    {
        GameObject.Find("LoadingModal").SetActive(true);
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5221/environment-object");
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var contents = await response.Content.ReadAsStringAsync();
            Debug.Log("Informações de Ojetos de Ambiente Carregadas!");
        }
        else
        {
            Debug.Log("Erro ao carregar Informações de Ojetos de Ambiente");
        }
        GameObject.Find("LoadingModal").SetActive(false);

    }

}
