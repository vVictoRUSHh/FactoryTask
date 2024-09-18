using System.Collections;
using MainMechanic.WareHouse;
using UnityEngine;

public class IronFactory : Factory
{
    public ManufacturedWareHouse _manufacturedWareHouse;
    public float timeToMake;
    private Iron _ironResource;
    [ContextMenu("ADD IRON TO WAREHOUSE")]
    public override void CreateResource()
    {
        StartCoroutine(MakeResource(timeToMake));
    }

    private IEnumerator MakeResource(float timeToMake)
    {
        yield return new WaitForSeconds(timeToMake);
        _ironResource = new Iron();
        _manufacturedWareHouse._consumableResources.Add(_ironResource);
        print($"All works{_manufacturedWareHouse._consumableResources.Count}");
    }
}