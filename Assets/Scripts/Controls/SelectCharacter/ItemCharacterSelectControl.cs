using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ItemCharacterSelectControl : AbstractControl
{
    public string character;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            Logger("Logging with: " + character);
            SessionService.SyncSession(JsonParam(character,"idSession"),character);
        });
    }
}
