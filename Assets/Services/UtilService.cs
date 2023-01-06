using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
public class UtilService : MonoBehaviour
{
    private static string url = "http://localhost:5221/";

    //CONTENT GENERATOR
    public static HttpContent Content(System.Object? obj)
    {
            string json = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
    }
    //URI GENERATOR
    public static Uri Uri(string uri)
    {
        return new Uri(url + uri);
    }
    //REQUESTS
    public static Task<HttpResponseMessage> Post(Uri uri, HttpContent content)
    {
        return new HttpClient().PostAsync(uri, content);
    }
    public static Task<HttpResponseMessage> Get(string parameters)
    {
        return new HttpClient().GetAsync(url + parameters);
    }
    
public static void ShowLoading(string? detail)
    {
        GameObject.Find("HUD/HomeScreen/LoadingModal").gameObject.transform.localScale = new Vector3(1, 1, 0);
        //
        //
        //implementar msg detail
    }
    
public static void HideLoading()
    {
        GameObject.Find("LoadingModal").gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
