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
    void Start()
    {
        Common.scene = "MAIN_LAND";
        SyncSession(Common.scene);
    }
    public static void SyncSession(string session)
    {
        try
        {

            Common.token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiYW5kcmFkZTAxIiwibmJmIjoxNjczNDY3NjA4LCJleHAiOjE2NzM0Njc2MzgsImlhdCI6MTY3MzQ2NzYwOH0.DGRjSZslCD4R2rLMWF9bXbVpjylXHwIIarDyllFgf04";
            ws = new WebSocket("ws://localhost:1236/syncsession");
            ws.SetCookie(new WebSocketSharp.Net.Cookie("token",Common.token));
            ws.Connect();

            ws.OnClose += (sender, e) =>
            {
                Logout();
                Push("Home");
            };

            ws.OnMessage += (sender, e) =>
            {
                Logger("mensagem recebida : " + e.Data + "SENDER = " + sender);
                ws.Send(session);
                Logger("mensagem enviada : " + DateTime.Now);
            };
        }
        catch (HttpRequestException e)
        {
            Logger(e.InnerException.Message);
        }
    }

    public static async void SyncSession(ObjectDataModel obj)
    {
        try
        {
            var request = await Post("acc/select-character", obj);
            string response = await request.Content.ReadAsStringAsync();
            List<CharacterModel> listCharacter = JsonConvert.DeserializeObject<List<CharacterModel>>(response);

            Logger("-> Sessão Sincronizada: " + DateTime.Now);
            await Task.Delay(5000);
        }
        catch (HttpRequestException e)
        {
            Logger(e.InnerException.Message);
        }
    }
}
