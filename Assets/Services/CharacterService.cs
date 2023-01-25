using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CharacterService : AbstractControl
{

    public static async Task<List<CharacterModel>> getCharacterList(ObjectDataModel obj)
    {
        try
        {
            var request =await Post("acc/select-character", obj);
            string response = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CharacterModel>>(response);
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
}
