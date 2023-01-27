using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataModel : MonoBehaviour
{
    public string? id { get; set; }
    public string? internalId { get; set; }
    public string? name { get; set; }
    public long? hp { get; set; }
    public float positionX { get; set; }
    public float positionY { get; set; }
    public float positionZ { get; set; }
    public float rotation { get; set; }
    public string? world { get; set; }
    public string? local { get; set; }
     
}
