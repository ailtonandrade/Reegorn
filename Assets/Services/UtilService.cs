using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
public class UtilService
{
    private static string url = "http://localhost:5221/";

    //CONTENT GENERATOR
    public static HttpContent GenContent(System.Object? obj, string? text)
    {
        if (obj != null)
        {
            string json = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }
        if (string.IsNullOrEmpty(text))
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpContent;
        }
        return null;
    }
    //URI GENERATOR
    public static Uri GenUri(string uri)
    {
        return new Uri(url + uri);
    }
    //REQUESTS
    public static Task<HttpResponseMessage> GenPostAsync(Uri uri, HttpContent content)
    {
        return new HttpClient().PostAsync(uri, content);
    }
    public static Task<HttpResponseMessage> GenGetAsync(string parameters)
    {
        return new HttpClient().GetAsync(url + parameters);
    }
}
