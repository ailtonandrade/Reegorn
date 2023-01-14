using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using WebSocketSharp;

public class SessionService : AbstractControl
{
    private static WebSocket ws;

    public static async void SyncSession(string session, string characterJson)
    {

        try
        {

            Common.token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYW5kcmFkZTAxIiwibmJmIjoxNjczNzE5MTA1LCJleHAiOjE2NzM3MTkxMzUsImlhdCI6MTY3MzcxOTEwNX0.F7jHUKxGTaYwimdHAI1lOr1XG6rvLQJbiwzr_qwh69Q";
            ws = new WebSocket("ws://localhost:1236/syncsession");
            ws.SetCookie(new WebSocketSharp.Net.Cookie("token", Common.token));
            ws.Connect();
            SceneControl.Push(JsonParam(characterJson, "idSession"));
            await Task.Delay(1000);
            ws.Send(characterJson);
            ws.OnMessage += (sender, e) =>
            {
                try
                {
                    Logger("uodated : " + CharacterSettings.getJson());
                    ws.Send(CharacterSettings.getJson());
                }
                catch (Exception ex)
                {
                    Logger(ex.Message);
                    ws.Close();
                    Logout();
                    SceneControl.Push("Home");

                }

            };
            ws.OnClose += (sender, e) =>
            {
                ws.Close();
                Logout();
                SceneControl.Push("Home");
            };
        }
        catch (HttpRequestException e)
        {
            Logger(e.InnerException.Message);
            Logout();
            SceneControl.Push("Home");
        }
    }
    private static string updateCharacterData()
    {
        CharacterSettings ch = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterSettings>();

        string resp = ToJson(ch);
        return ToJson(resp);
    }
}
