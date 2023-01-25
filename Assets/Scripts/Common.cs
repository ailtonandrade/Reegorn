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
    public static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYW5kcmFkZTAxIiwibmJmIjoxNjc0NTkxNDM1LCJleHAiOjE2NzQ1OTE0NjUsImlhdCI6MTY3NDU5MTQzNX0.aeWAdCLem4JrUiFaUDhqRbSBbW0gN2R_XVaYsKf3Y_M";
    public static string acc;
    public static string accessKey;
    public static string scene;
}
