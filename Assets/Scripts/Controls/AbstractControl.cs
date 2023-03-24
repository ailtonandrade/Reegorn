using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using WebSocketSharp;

public class AbstractControl : MonoBehaviour
{
    //POST - OBJECT DATA MODEL
    public static async Task<HttpResponseMessage> Post(string endpoint, UserModel obj)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Common.token);
            HttpResponseMessage response = await client.PostAsync(Endpoint(endpoint), Content(obj));
            await Task.Delay(2000);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {

        }

    }
    //POST - LOGIN
    public static async Task<HttpResponseMessage> Login(string hash, string ipAddress)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.PostAsync(Endpoint("auth"), ContentLogin(hash, ipAddress));
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
    //CONTENT - LOGIN
    public static HttpContent ContentLogin(string hash, string address)
    {
        var obj = new { Hash = hash, IpAddress = address };
        string json = JsonConvert.SerializeObject(obj);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }
    //CONTENT - OBJ
    public static HttpContent Content(UserModel obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }

    //CONTENT - OBJ
    public static HttpContent Content(string txt)
    {
        var obj = new { Content = txt };
        string json = JsonConvert.SerializeObject(obj);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }
    // MONTA ENDPOINTS
    public static Uri Endpoint(string endpoint)
    {
        return new Uri(Common.baseUrl + endpoint);
    }
    public static string EndpointWs(string endpoint)
    {
        return new Uri(Common.baseUrlWs + endpoint).ToString();
    }
    public static void ShowLoading()
    {
        var LoadingModal = Resources.Load<GameObject>("Res_Common/LoadingModal") as GameObject;
        Instantiate(LoadingModal, new Vector3(1, 1, 0), Quaternion.identity);
        //
        //implementar msg detail
    }
    //SHOW MODAL CONFIRM MODAL
    public static async Task<string> ShowConfirmModal(string title, string msg, string msgDetail, bool showYesNo, bool showOk, bool showClose)
    {
        string response = "";
        //INSTANCIA OBJETO DO MODAL
        var AlertConfirmModal = Resources.Load<GameObject>("Res_Common/AlertConfirmModal") as GameObject;
        Instantiate(AlertConfirmModal, new Vector3(1, 1, 0), Quaternion.identity);
        //ATRIBUI TEXTOS NAS AREAS
        AlertConfirmModal.transform.FindChild("Title").GetComponentInChildren<Text>().text = title;
        AlertConfirmModal.transform.FindChild("Msg").GetComponentInChildren<Text>().text = msg;
        AlertConfirmModal.transform.FindChild("MssgDetail").GetComponentInChildren<Text>().text = msgDetail;
        //ATRIBUI BOTOES A VARIÁVEIS E OS VALORES DOS PARÂMETROS
        Button btnYes = AlertConfirmModal.transform.FindChild("Yes").gameObject.SetActive(showYesNo);
        Button btnNo = AlertConfirmModal.transform.FindChild("No").gameObject.SetActive(showYesNo);
        Button btnOk = AlertConfirmModal.transform.FindChild("Ok").gameObject.SetActive(showOk);
        Button btnClose = AlertConfirmModal.transform.FindChild("Close").gameObject.SetActive(showClose);
        //ADD LISTENERS COM RESPOSTA PARA OS BOTOES
        if (showYesNo)
        {
            btnYes.onClick.AddListener(() =>
            {
                response = "YES";
            });
        };
        if (showYesNo)
        {
            btnNo.onClick.AddListener(() =>
            {
                response = "NO";
            });
        };
        if (showOk)
        {
            btnOk.onClick.AddListener(() =>
            {
                response = "OK";
            });
        };
        if (showClose)
        {
            btnClose.onClick.AddListener(() =>
            {
                response = "CLOSE";
            });
        };
        //AGUARDA RESPOSTA PARA DEVOLVER O RETORNO
        while (response == "")
        {
            await Task.Delay(1000);
        }
        return response;
    }

    public static void HideConfirmModal(string detail)
    {
        GameObject.Find("AlertConfirmModal").SetActive(false);
    }
    //SHOW MODAL LOADING COM MENSAGEM
    public static void ShowLoading(string detail)
    {
        var LoadingModal = Resources.Load<GameObject>("Res_Common/LoadingModal") as GameObject;
        Instantiate(LoadingModal, new Vector3(1, 1, 0), Quaternion.identity);
        //
        //implementar msg detail
    }
    //HID MODAL LOADING
    public static void HideLoading()
    {
        try
        {
            GameObject.Find("LoadingModal").SetActive(false);
        }
        catch
        {

        }
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
    public static string ToJson(CharacterSettings obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    public static string ToJson(System.Object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    public static string ToJson(List<SessionModel> obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    //PARSE FLOAT TO STRING
    public static string FormatFloat(float val)
    {
        return val.ToString("N3"); ;
    }
    public static float ParseFloat(string val)
    {
        return float.Parse(val);
    }

    public static void Logout()
    {
        Common.acc = null;
        Common.accessKey = null;
        Common.token = null;
        ErrorModel.IpValid = null;
        ErrorModel.LoginValid = null;
        SceneControl.Push("Home", 1000);

    }
    public static void Logout(WebSocket ws)
    {
        Common.acc = null;
        Common.accessKey = null;
        Common.token = null;
        ErrorModel.IpValid = null;
        ErrorModel.LoginValid = null;
        ws.Close();
        SceneControl.Push("Home", 1000);

    }
    public static void UpdateCommon()
    {
        Common.lastUpdate = DateTime.Now;
    }
    public static void checkConnection()
    {
        if (Common.lastUpdate.AddSeconds(60) < DateTime.Now)
        {
            string msg = "Erro ao obter informações da sessão.";
            ErrorModel.LoginValid = msg;
            Logger(msg);
            Logout(SessionService.ws);
        }
    }
}
