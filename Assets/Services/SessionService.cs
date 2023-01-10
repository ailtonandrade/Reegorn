using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class SessionService : AbstractControl
{

    public static async Task<List<CharacterModel>> getCharacterList(ObjectDataModel obj)
    {
        try
        {
            var request = await Post("acc/select-character", obj);
            string response = await request.Content.ReadAsStringAsync();
            await Task.Delay(5000);
            return JsonConvert.DeserializeObject<List<CharacterModel>>(response); ;
        }
        catch (HttpRequestException e)
        {
            Logger(e.InnerException.Message);
        }
        finally
        {
            Logger("-> Lista Sincronizada: " + DateTime.Now);
        }
        return null;
    }
    public static async Task<SessionModel> SyncSession(string session)
    {
        try
        {
            var request = Post("sync/session-elements", session);
            string response = await request.Content.ReadAsStringAsync();
            SessionModel sessionData = JsonConvert.DeserializeObject<SessionModel>(response);

            Logger("-> Sessão Sincronizada: " + DateTime.Now);
            await Task.Delay(5000);
            return sessionData;
        }
        catch (HttpRequestException e)
        {
            Logger(e.InnerException.Message);
        }
        return null;
    }
    public static async Task<List<CharacterModel>> SyncSession(ObjectDataModel obj)
    {
        try
        {
            var request = await Post("acc/select-character", obj);
            string response = await request.Content.ReadAsStringAsync();
            List<CharacterModel> listCharacter = JsonConvert.DeserializeObject<List<CharacterModel>>(response);

            Logger("-> Sessão Sincronizada: " + DateTime.Now);
            await Task.Delay(5000);
            return listCharacter;
        }
        catch (HttpRequestException e)
        {
            Logger(e.InnerException.Message);
        }
        return null;
    }
}
