using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UnityEngine;

public class Common
{
    public static string baseUrl = "http://localhost:5221/";
    public static string baseUrlWs = "ws://localhost:1236/";
    public static string playerTag = "Player";
    public static DateTime lastUpdate = DateTime.Now;
    public static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYW5kcmFkZTAxIiwibmJmIjoxNjc0NzQxMjkyLCJleHAiOjE2NzQ3NDEzMjIsImlhdCI6MTY3NDc0MTI5Mn0.PTwSvfaq9WEjRj4xDM4qgdzJguhZ77N37Az2i8qqPy";
    public static string acc;
    public static string accessKey;
    public static string scene;
}
