using UnityEngine;

public  class Factory : MonoBehaviour
{
    public  bool isStoped {get; set;}

    public virtual void CreateResource()
    {
    }
}