using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionModel : MonoBehaviour
{
    public int Id {get;set;}
    public List<ObjectModel> listPlayersInSession {get;set;} 
    public string InternalId {get;set;}
    public string Name {get;set;}
    public string Hp {get;set;}
    public string posX {get;set;}
    public string posY {get;set;}
    public string posZ {get;set;}
    public string rot {get;set;}
     
}
