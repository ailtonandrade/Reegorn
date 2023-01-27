using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopLeftHUDControl : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("NameCharacter").GetComponent<TextMeshProUGUI>().text = CharacterSettings.name;
        GameObject.Find("HpCharacter").GetComponent<TextMeshProUGUI>().text = CharacterSettings.hp.ToString();
    }
}
