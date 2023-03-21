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
    public static WebSocket ws;


    public async static void SyncSession(string local, CharacterModel character)
    {
        try
        {
            validateCharacterData(character);
            ws = connectWebSocket();

            SceneControl.Push(local, 1000);
            SendCharacter(ws);

            ws.OnMessage += async (sender, e) =>
            {
                try
                {
                    if (await validateSessionData(e.Data))
                    {
                        UpdateCommon();
                        //Logger("All Players of Session Info : " + DateTime.Now);
                        SendCharacter(ws);
                    }
                }
                catch (Exception ex)
                {
                    Logger("Erro ao obter informações da sessão.");
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
            SceneControl.Push("Home", 1000);
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
    private static void validateCharacterData(CharacterModel character)
    {
        try
        {
            Logger(ToJson(character));
            CharacterSettings.acc = character.acc;
            CharacterSettings.name = character.name;
            CharacterSettings.hp = character.hp;
            CharacterSettings.local = character.local;
            CharacterSettings.world = character.world;
            CharacterSettings.idSession = character.idSession;
            CharacterSettings.positionX = character.positionX;
            CharacterSettings.positionY = character.positionY;
            CharacterSettings.positionZ = character.positionZ;
            CharacterSettings.rotation = character.rotation;
        }
        catch
        {
            Logger("Erro ao obter informações da sessão.");
            Logout(ws);
        }

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
    private async static Task<bool> validateSessionData(string data)
    {
        try
        {
            Logger(data);
            SessionModel dataList = JsonConvert.DeserializeObject<SessionModel>(data);
            loadSessionObjects(dataList);

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao carregar dados da sessão");
        }
    }
    private static void loadSessionObjects(SessionModel dataList)
    {
        SessionControl.dataList = dataList;

        Logger(ToJson(dataList.players));
    }
}
