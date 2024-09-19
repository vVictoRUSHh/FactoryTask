using UnityEngine;

public  class Factory : MonoBehaviour
{
    public  bool isWorking {get; set;}
    public string debugInfo { get; set; }

    public virtual void CreateResource()
    {
    }
}