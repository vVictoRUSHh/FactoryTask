using System;
using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using MainMechanic.WareHouse;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class CopperFactory : Factory
{
    public ManufacturedWareHouse _manufacturedWareHouse;
    public float timeToMake;
    public GameObject _copperPrefab;
    public List<Iron> _ironList;
    private Copper _copperResource;
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
        bool haveEnoughResources = _ironList.Count > 0;
        isWorking  = resourceCountInWareHouse < resourcesCopacity && haveEnoughResources;
        if (isWorking && isCreatingFinish)
        {
            StartCoroutine(MakeResourceCoroutine(timeToMake));
            debugInfo = $"Factory is Working!!!";
        }
        else if (resourceCountInWareHouse >= resourcesCopacity)
            debugInfo = $"Factory stop working because WareHouse is filled!";
        else 
            debugInfo = $"Factory have no resource to creating!";   
    }

    private void Update()
    {
        if (isCreatingFinish)CreateResource();
    }

    private IEnumerator MakeResourceCoroutine(float timeToMake)
    {
        isCreatingFinish = false;
        _ironList.RemoveAt(_ironList.Count-1);
        yield return new WaitForSeconds(timeToMake);
        _copperResource = new Copper();
        _manufacturedWareHouse._consumableResources.Add(_copperResource);
        DisplayResourceAddin();
        isCreatingFinish = true;
    }

    private void DisplayResourceAddin()
    {
        GameObject copper = Instantiate(_copperPrefab,gameObject.transform.position,quaternion.identity);
        StartCoroutine(_resourceMover.MoveResource(copper, _manufacturedWareHouse.gameObject.transform.position, _speed));
    }
}