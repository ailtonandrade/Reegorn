using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionModel : MonoBehaviour
{
    public int Id {get;set;}
    public List<GameObject> listPlayersInSession {get;set;} 
    public string InternalId {get;set;}
    public string Name {get;set;}
    public string Hp {get;set;}
    public string positionX {get;set;}
    public string positionY {get;set;}
    public string positionZ {get;set;}
    public string rotation {get;set;}
     
}
