using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class ItemCharacterSelectControl : AbstractControl
{
    public string character;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            try
            {
                UpdateCommon();
                SessionService.SyncSession(JsonParam(character, "local"), JsonConvert.DeserializeObject<CharacterModel>(character));
                Logger("Logging with: " + character);
            }
            catch
            {
                throw new Exception("Erro ao encontrar personagens.");
            }


        });
    }
}
