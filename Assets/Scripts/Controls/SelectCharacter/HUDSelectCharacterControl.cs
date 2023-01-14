using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDSelectCharacterControl : AbstractControl
{
    [SerializeField] private GameObject List;
    [SerializeField] private GameObject New;
    [SerializeField] private GameObject Play;
    private float posY = 400;
    private float space = 50;

    public async void getCharacterList(string nameAcc)
    {

        try
        {
            SceneControl.Push("SelectCharacter");
            List<CharacterModel> characterList = await CharacterService.getCharacterList(new ObjectDataModel() { Name = nameAcc });

            List = GameObject.Find("ListCharacterSelect");
            New = Resources.Load<GameObject>("Res_HUDSelectCharacter/ItemCharacterSelectNew") as GameObject;

            if (List != null)
            {
                Play = Resources.Load<GameObject>("Res_HUDSelectCharacter/ButtonPlay") as GameObject;
                for (int i = 0; i <= 5; ++i)
                {
                    if (i == 5)
                    {
                        try
                        {
                            Instantiate(Play ?? New, new Vector3(List.transform.position.x, posY -= space, List.transform.position.z), Quaternion.identity, List.transform);
                            break;
                        }
                        catch
                        {
                        }
                    }

                    if (i > characterList.Count - 1)
                    {
                        try
                        {
                            Instantiate(New, new Vector3(List.transform.position.x, posY -= space, List.transform.position.z), Quaternion.identity, List.transform);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            GameObject itemCharacter = Resources.Load<GameObject>("Res_HUDSelectCharacter/ItemCharacterSelect") as GameObject;
                            buildButtonSettings(itemCharacter, characterList[i]);
                            Instantiate(itemCharacter, new Vector3(List.transform.position.x, posY -= space, List.transform.position.z), Quaternion.identity, List.transform);
                        }
                        catch
                        {
                        }

                    }
                }

                Logger(ToJson("characterList"));
            }
        }
        catch (Exception ex)
        {
            Logger(ToJson("Erro no login!"));

            throw;
        }

    }
    void buildButtonSettings(GameObject btn, CharacterModel characterItem)
    {
        btn.GetComponent<ItemCharacterSelectControl>().character = ToJson(characterItem);
    }

}
