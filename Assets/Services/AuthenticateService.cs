using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AuthenticateService : MonoBehaviour
{
    public static string tokenSession;

    public async Task loginAsync(UserModel user)
    {
        user.UserName = "andrade01";
        user.AccessKey = "123456";
        
        try
        {
            UtilService.ShowLoading();
            var response = await UtilService.Post(UtilService.Uri("auth"),UtilService.Content(user));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string contents = await response.Content.ReadAsStringAsync();
                var _content = JObject.Parse(contents)["token"];
                if(JObject.Parse(contents)["token"] != null){
                    tokenSession = contents;
                    SceneControl.Push("MainLand","Home");
                    Debug.Log("Usuário Autenticado!");
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Debug.Log("Usuário ou senha inválidos");
            }
            else
            {
                Debug.Log("Falha na conexão = " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
          UtilService.HideLoading();
        }

    }

}
