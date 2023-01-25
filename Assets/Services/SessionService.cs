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

    public async static void SyncSession(string session, string characterJson)
    {
        try
        {
            validateCharacterData(characterJson);
            ws = connectWebSocket();

            SceneControl.Push(session, 1000);
            SendCharacter(ws);

            ws.OnMessage += (sender, e) =>
            {
                try
                {
                    Logger("Updated : " + CharacterSettings.getJson());
                    SendCharacter(ws);
                }
                catch (Exception ex)
                {
                    Logger(ex.Message);
                    Logout(ws);
                }
            };

            ws.OnClose += (sender, e) =>
            {
                SceneControl.Push("Home", 1000);
            };
        }
        catch (Exception ex)
        {
            Logger(ex.InnerException.Message);
            Logout();
            SceneControl.Push("Home",1000);
        }
    }
    private static void SendCharacter(WebSocket ws)
    {
        ws.Send(CharacterSettings.getJson());
    }
    private static string updateCharacterData()
    {
        CharacterSettings ch = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterSettings>();

        string resp = ToJson(ch);
        return ToJson(resp);
    }
    private static void validateCharacterData(string characterJson)
    {
        CharacterSettings.acc = JsonParam(characterJson, "acc");
        CharacterSettings.name = JsonParam(characterJson, "name");
        CharacterSettings.positionX = ParseFloat(JsonParam(characterJson, "positionX"));
        CharacterSettings.positionY = ParseFloat(JsonParam(characterJson, "positioY"));
        CharacterSettings.positionZ = ParseFloat(JsonParam(characterJson, "positionZ"));
        CharacterSettings.rotation = ParseFloat(JsonParam(characterJson, "rotation"));
    }
    private static WebSocket connectWebSocket()
    {
        WebSocket ws = new WebSocket(EndpointWs("syncsession"));
        ws.SetCookie(new WebSocketSharp.Net.Cookie("token", Common.token));
        try
        {
            ws.Connect();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return ws;
    }
}
