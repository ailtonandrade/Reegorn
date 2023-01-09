using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AbstractControl : ObjectModel
{

    //POST - OBJECT
    public static HttpResponseMessage Post(string endpoint, System.Object obj)
    {
        try
        {
            ShowLoading();
            HttpResponseMessage response = new HttpClient().PostAsync(Endpoint(endpoint), Content(obj)).Result;
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            HideLoading();
        }

    }
    //POST - STRING
    public static HttpResponseMessage Post(string endpoint, string text)
    {
        try
        {
            ShowLoading();
            HttpResponseMessage response = new HttpClient().PostAsync(Endpoint(endpoint), Content(text)).Result;
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            HideLoading();
        }

    }
    //GET
    public static HttpResponseMessage Get(string endpoint)
    {
        try
        {
            ShowLoading();
            HttpResponseMessage response = new HttpClient().GetAsync(endpoint).Result;
        return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            HideLoading();
        }
    }
    //CONTENT - STRING
    public static HttpContent Content(System.Object? obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }
    //CONTENT - OBJ
    public static HttpContent Content(string txt)
    {
        HttpContent httpContent = new StringContent(txt, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }
    // MONTA ENDPOINTS
    public static Uri Endpoint(string endpoint)
    {
        return new Uri(Common.baseUrl + endpoint);
    }
    public static void ShowLoading()
    {
        GameObject.Find("HUD/HomeScreen/LoadingModal").gameObject.transform.localScale = new Vector3(1, 1, 0);
        //
        //implementar msg detail
    }
    //SHOW MODAL LOADING COM MENSAGEM
    public static void ShowLoading(string detail)
    {
        GameObject.Find("HUD/HomeScreen/LoadingModal").gameObject.transform.localScale = new Vector3(1, 1, 0);
        //
        //implementar msg detail
    }
//HID MODAL LOADING
    public static void HideLoading()
    {
        GameObject.Find("LoadingModal").gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
    //LOGGER
    public static void Logger(string content)
    {
        Debug.Log(content);
    }
    //GET JSON PARAM
    public static string JsonParam(string json, string param)
    {
        return JObject.Parse(json)[param].ToString();
    }
    public static string ToJson(System.Object? obj){
        return JsonConvert.SerializeObject(obj);
    }
    //PARSE FLOAT TO STRING
    public static string FormatFloat(float val){
        return val.ToString("N3");;
    }

    public static void PushDropScene(string? sceneLoad, string? sceneUnload)
    {
        SceneControl.PushDrop(sceneLoad, sceneUnload);
    }
}
