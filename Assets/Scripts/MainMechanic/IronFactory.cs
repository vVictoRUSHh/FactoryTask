using System;
using System.Collections;
using MainMechanic.WareHouse;
using UnityEngine;

public class IronFactory : Factory
{
    public ManufacturedWareHouse _manufacturedWareHouse;
    public float timeToMake;
    public GameObject _ironPrefab;
    private Iron _ironResource;
    private bool isCreatingFinish = true;
    public float _speed;

    [ContextMenu("ADD IRON TO WAREHOUSE")]
    public override void CreateResource()
    {
        var resourceCountInWareHouse = _manufacturedWareHouse._consumableResources.Count;
        var resourcesCopacity = _manufacturedWareHouse._storageСapacity;
        //print(resourceCountInWareHouse);
        isStoped  = resourceCountInWareHouse < resourcesCopacity ? true : false;
        if (isStoped && isCreatingFinish)
        {
            StartCoroutine(MakeResourceCoroutine(timeToMake));
        }
        else print($"Factory stop working because WareHouse is filled!");
    }

    private void Update()
    {
        if (isCreatingFinish)CreateResource();
    }

    private IEnumerator MakeResourceCoroutine(float timeToMake)
    {
        isCreatingFinish = false;
        yield return new WaitForSeconds(timeToMake);
        _ironResource = new Iron();
        _manufacturedWareHouse._consumableResources.Add(_ironResource);
        DisplayResourceAddin();
        //print($"All works{_manufacturedWareHouse._consumableResources.Count}");
        isCreatingFinish = true;
    }

    private void DisplayResourceAddin()
    {
        GameObject iron = Instantiate(_ironPrefab);
        StartCoroutine(MoveResource(iron, _manufacturedWareHouse.transform.position, 1f));
    }

    private IEnumerator MoveResource(GameObject resource, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = gameObject.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            resource.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        resource.transform.position = targetPosition;
        Destroy(resource);
    }
}