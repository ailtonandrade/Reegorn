using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Threading;

public class SessionControl : AbstractControl
{
    public static SessionModel dataList;
    void Start()
    {
    }

    void Update()
    {
        loadDataListPlayers();
        loadDataListEnvironments();
    }

    private static void loadDataListPlayers()
    {
        if (dataList.players.Count > 0)
        {

            foreach (CharacterModel character in dataList.players)
            {
                if (character.name != CharacterSettings.name)
                {
                    GameObject c = GameObject.Find(character.name);
                    if (c != null)
                    {
                        c.transform.position = new Vector3(character.positionX, character.positionY, character.positionZ);
                        c.transform.rotation = Quaternion.Euler(0, character.rotation, 0);
                    }
                    else
                    {
                        GameObject characterPrefab = Resources.Load<GameObject>("Res_Character/CharacterSession");
                        GameObject p = (GameObject)Instantiate(characterPrefab, new Vector3(character.positionX, character.positionY, character.positionZ), Quaternion.Euler(0, character.rotation, 0));
                        buildPrefabSettings(p, character);
                    }
                }
            }
        }

    }
    private void loadDataListEnvironments()
    {
        if (dataList.environments.Count > 0)
        {
            foreach (ObjectDataModel envObj in dataList.environments)
            {
                if (envObj.name != null)
                {
                    GameObject env = GameObject.Find(envObj.id);
                    if (env != null)
                    {
                        env.transform.position = new Vector3(envObj.positionX, envObj.positionY, envObj.positionZ);
                        env.transform.rotation = Quaternion.Euler(0, envObj.rotation, 0);
                    }
                    else
                    {
                        GameObject prefab = loadResource(envObj);
                        GameObject p = instantiateResource(prefab, envObj);
                        buildPrefabSettings(p, envObj);
                    }
                }
            }
        }
    }

    private void instantiateDataListCreatures(SessionModel session)
    {

    }

    private void instantiateDataListInfos(SessionModel session)
    {

    }

    private static void UpdateCharacter(CharacterModel character, GameObject ToUpdate)
    {

    }

    private static void SpawnCharacter(CharacterModel character, GameObject prefab)
    {

    }
    private static GameObject loadResource(ObjectDataModel envObj)
    {
        return Resources.Load<GameObject>("Res_Environment/" + envObj.name);
    }
    private static GameObject instantiateResource(GameObject prefab, ObjectDataModel envObj)
    {
        return (GameObject)Instantiate(prefab, new Vector3(envObj.positionX, envObj.positionY, envObj.positionZ), Quaternion.Euler(0, envObj.rotation, 0), GameObject.Find("Objects").transform);
    }
    private static void buildPrefabSettings(GameObject g, ObjectDataModel obj)
    {
        g.name = obj.name;
        g.GetComponent<ObjectData>().id = obj.id;
        g.GetComponent<ObjectData>().hp = obj.hp;
    }
    private static void buildPrefabSettings(GameObject g, CharacterModel obj)
    {
        g.name = obj.name;
        g.GetComponent<ObjectData>().id = obj.id;
        g.GetComponent<ObjectData>().hp = obj.hp;
    }
}
