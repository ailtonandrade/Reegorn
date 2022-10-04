using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class AuthenticateService : MonoBehaviour
{
    public static string session;

    public async Task loginAsync(UserModel user)
    {

        GameObject.Find("HUD/HomeScreen/LoadingModal").gameObject.transform.localScale = new Vector3(1, 1, 0);
        try
        {
            var response = await UtilService.GenPostAsync(
                                    UtilService.GenUri("auth"),
                                    UtilService.GenContent(user,null)
                                );

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string contents = await response.Content.ReadAsStringAsync();
                var _content = JObject.Parse(contents)["token"];
                if(JObject.Parse(contents)["token"] != null){
                    session = contents;
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
            GameObject.Find("LoadingModal").gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

    }

}
