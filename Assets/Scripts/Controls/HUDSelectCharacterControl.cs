using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HUDSelectCharacterControl : AbstractControl
{
    public void setCharacterList(ObjectDataModel obj)
    {

    }
    public static async void getCharacterList(string nameAcc)
    {
        List<CharacterModel> characterList = await SessionService.getCharacterList(new ObjectDataModel() { Name = nameAcc });
        //TODO EXIBIR LISTAGEM NA TELA
        SceneControl.PushDropScene("SelectCharacter","Home");
    }
}
