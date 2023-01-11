using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HUDSelectCharacterControl : AbstractControl
{
    [SerializeField] private GameObject List;
    [SerializeField] private GameObject New;
    [SerializeField] private GameObject Play;
    private float posY = 400;
    private float space = 50;
    public void setCharacterList(ObjectDataModel obj)
    {

    }
    public async void getCharacterList(string nameAcc)
    {
        SceneControl.PushDropScene("SelectCharacter", null);

        List<CharacterModel> characterList = await CharacterService.getCharacterList(new ObjectDataModel() { Name = nameAcc });

        New = Resources.Load<GameObject>("Res_HUDSelectCharacter/ItemCharacterSelectNew") as GameObject;
        List = GameObject.Find("ListCharacterSelect");
        Play = Resources.Load<GameObject>("Res_HUDSelectCharacter/ButtonPlay") as GameObject;
        for (int i = 0; i <= 5; ++i)
        {
            if (i == 5)
            {
                Instantiate(Play, new Vector3(List.transform.position.x, posY -= space, List.transform.position.z), Quaternion.identity, List.transform);
                break;
            }

            if (i > characterList.Count - 1)
            {
                Instantiate(New, new Vector3(List.transform.position.x, posY -= space, List.transform.position.z), Quaternion.identity, List.transform);

            }
            else
            {
                GameObject itemCharacter = Resources.Load<GameObject>("Res_HUDSelectCharacter/ItemCharacterSelect") as GameObject;
                Instantiate(itemCharacter, new Vector3(List.transform.position.x, posY -= space, List.transform.position.z), Quaternion.identity, List.transform);

            }

        }

        Logger(ToJson(characterList));
    }
}
