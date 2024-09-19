using System;
using System.Collections;
using MainMechanic.FactoryResources;
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
    private ResourceMover _resourceMover;
    private void Awake()
    {
        _resourceMover = new ResourceMover();
    }

    public override void CreateResource()
    {
        var resourceCountInWareHouse = _manufacturedWareHouse._consumableResources.Count;
        var resourcesCopacity = _manufacturedWareHouse._storageСapacity;
        isWorking  = resourceCountInWareHouse < resourcesCopacity;
        if (isWorking && isCreatingFinish)
        {
            StartCoroutine(MakeResourceCoroutine(timeToMake));
            debugInfo = $"Factory is Working!!!";
        }
        else 
        {
            debugInfo = $"Factory stop working because WareHouse is filled!";
        }
       
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
        isCreatingFinish = true;
    }

    private void DisplayResourceAddin()
    {
        GameObject iron = Instantiate(_ironPrefab,gameObject.transform);
        StartCoroutine(_resourceMover.MoveResource(iron, _manufacturedWareHouse.gameObject.transform.position, _speed));
    }

   
}