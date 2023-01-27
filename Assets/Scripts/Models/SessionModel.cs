using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionModel
{
    public long? id;
    public string? local;
    public string? world;
    public List<CharacterModel>? players;
    public List<CreatureModel>? creatures;
    public List<ObjectDataModel>? environments;
    public List<InfoSessionModel>? info;

}
